using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Leega.Entity.UnitofWork;
using Leega.Entity.Context;
using AutoMapper;
using Leega.Domain.Mapping;
using Leega.Domain.Service;
using Amazon.S3;
using CSharpAwsS3ServiceManager.AwsS3;
using Serilog;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Elastic.Apm.NetCoreAll;
using Leega.Api.Controllers;
using Leega.Entity.Repositories.Interfaces;
using Leega.Entity.Repositories;
using Hangfire;
using Newtonsoft.Json;
using System.Configuration;

namespace Leega.Api
{
    public class Startup
    {

        public static IConfiguration Configuration { get; set; }
        public IWebHostEnvironment HostingEnvironment { get; private set; }

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            HostingEnvironment = env;
        }

        public void ConfigureServices(IServiceCollection services)
        {

            Log.Information("Startup::ConfigureServices");

            try
            {
                services.AddControllers(
                opt =>
                {
                    //Custom filters can be added here
                    //opt.Filters.Add(typeof(CustomFilterAttribute));
                    //opt.Filters.Add(new ProducesAttribute("application/json"));
                }
                ).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

                #region "API versioning"
                //API versioning service
                services.AddApiVersioning(
                    o =>
                    {
                        //o.Conventions.Controller<UserController>().HasApiVersion(1, 0);
                        o.AssumeDefaultVersionWhenUnspecified = true;
                        o.ReportApiVersions = true;
                        o.DefaultApiVersion = new ApiVersion(1, 0);
                        o.ApiVersionReader = new UrlSegmentApiVersionReader();
                    }
                    );

                // format code as "'v'major[.minor][-status]"
                services.AddVersionedApiExplorer(
                options =>
                {
                    options.GroupNameFormat = "'v'VVV";
                    //versioning by url segment
                    options.SubstituteApiVersionInUrl = true;
                });
                #endregion

                services.AddHangfire(config =>
                {
                    config.UseSqlServerStorage(Configuration["ConnectionStrings:goobeeteamsDB"]);
                    config.UseSerializerSettings(new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
                });

                //db service
                if (Configuration["ConnectionStrings:UseInMemoryDatabase"] == "True")
                    services.AddDbContext<goobeeteamsContext>(opt => opt.UseInMemoryDatabase("TestDB-" + Guid.NewGuid().ToString()));
                else
                    services.AddDbContext<goobeeteamsContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:goobeeteamsDB"]));

                ConfigurationManager.AppSettings.Set("_dbConnectionMySql", Configuration["ConnectionStrings:DbConnectionMySql"]);

                #region "Authentication"
                if (Configuration["Authentication:UseIndentityServer4"] == "False")
                {
                    //JWT API authentication service
                    services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,
                            ValidIssuer = Configuration["Jwt:Issuer"],
                            ValidAudience = Configuration["Jwt:Issuer"],
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                        };
                    }
                     );
                }
                else
                {
                    //Indentity Server 4 API authentication service
                    services.AddAuthorization();
                    //.AddJsonFormatters();
                    services.AddAuthentication("Bearer")
                    .AddIdentityServerAuthentication(option =>
                    {
                        option.Authority = Configuration["Authentication:IndentityServer4IP"];
                        option.RequireHttpsMetadata = false;
                        //option.ApiSecret = "secret";
                        option.ApiName = "goobeeteams";  //This is the resourceAPI that we defined in the Config.cs in the AuthServ project (apiresouces.json and clients.json). They have to be named equal.
                    });

                }
                #endregion

                #region "CORS"
                // include support for CORS
                // More often than not, we will want to specify that our API accepts requests coming from other origins (other domains). When issuing AJAX requests, browsers make preflights to check if a server accepts requests from the domain hosting the web app. If the response for these preflights don't contain at least the Access-Control-Allow-Origin header specifying that accepts requests from the original domain, browsers won't proceed with the real requests (to improve security).
                services.AddCors(options =>
                {
                    options.AddPolicy("CorsPolicy-public",
                        builder => builder.AllowAnyOrigin()   //WithOrigins and define a specific origin to be allowed (e.g. https://mydomain.com)
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                    //.AllowCredentials()
                    .Build());
                });
                #endregion

                //mvc service
                services.AddMvc(option => option.EnableEndpointRouting = false)
                     .AddNewtonsoftJson(
                        options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                    );

                #region "DI code"
                // DI MySql
                IoC.BootStrapper.RegisterServices(services);

                //general unitofwork injections
                services.AddTransient<IUnitOfWork, UnitOfWork>();

                //services injections
                services.AddTransient(typeof(AccountService<,>), typeof(AccountService<,>));
                services.AddTransient(typeof(UserService<,>), typeof(UserService<,>));
                services.AddTransient(typeof(UsuarioServico<,>), typeof(UsuarioServico<,>));
                services.AddTransient(typeof(LoginServico<,>), typeof(LoginServico<,>));
                services.AddTransient(typeof(PessoaService<,>), typeof(PessoaService<,>));
                services.AddTransient(typeof(EnvioDeEmailService), typeof(EnvioDeEmailService));
                services.AddTransient(typeof(TokenService), typeof(TokenService));
                services.AddTransient(typeof(ClienteService<,>), typeof(ClienteService<,>));
                services.AddTransient(typeof(OrganizacaoService), typeof(OrganizacaoService));
                services.AddTransient(typeof(ApiPublicaService), typeof(ApiPublicaService));

                //...add other services
                //
                services.AddTransient(typeof(IService<,>), typeof(ServicoGenerico<,>));
                services.AddTransient(typeof(IServiceAsync<,>), typeof(GenericServiceAsync<,>));
                services.AddTransient(typeof(IRepository<>), typeof(Repository<>));

                //Repositories
                services.AddTransient<IPessoaRepository, PessoaRepository>();
                services.AddTransient<ITimeRepository, TimeRepository>();
                services.AddTransient<IUsuarioRepository, UsuarioRepository>();
                services.AddTransient<IClienteRepository, ClienteRepository>();
                services.AddTransient<IOrganizacaoRepository, OrganizacaoRepository>();
                services.AddTransient<IOrganizacaoPessoaRepository, OrganizacaoPessoaRepository>();
                services.AddTransient<IOrganizacaoUsuarioRepository, OrganizacaoUsuarioRepository>();
                services.AddTransient<ITimePessoaRepository, TimePessoaRepository>();
                services.AddTransient<IGrupoRepository, GrupoRepository>();
                #endregion

                //data mapper services configuration
                services.AddAutoMapper(typeof(MappingProfile));
                services.AddHttpContextAccessor();

                #region "Swagger API"
                //Swagger API documentation
                services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "goobeeteams API", Version = "v1" });
                    c.SwaggerDoc("v2", new OpenApiInfo { Title = "goobeeteams API", Version = "v2" });

                    //In Test project find attached swagger.auth.pdf file with instructions how to run Swagger authentication
                    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                    {
                        Description = "Authorization header using the Bearer scheme",
                        Name = "Authorization",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.ApiKey
                    });

                    c.AddSecurityRequirement(new OpenApiSecurityRequirement{
                        {
                            new OpenApiSecurityScheme{
                                Reference = new OpenApiReference{
                                    Id = "Bearer", //The name of the previously defined security scheme.
                                	Type = ReferenceType.SecurityScheme
                                }
                            },new List<string>()
                        }
                    });

                    //c.DocumentFilter<api.infrastructure.filters.SwaggerSecurityRequirementsDocumentFilter>();
                });
                #endregion

                #region "AWS BUCKET"

                services.AddAWSService<IAmazonS3>();
                services.AddSingleton<IAwsS3HelperService, AwsS3HelperService>();
                services.Configure<AwsS3BucketOptions>(Configuration.GetSection(nameof(AwsS3BucketOptions)))
                    .AddSingleton(x => x.GetRequiredService<IOptions<AwsS3BucketOptions>>().Value);

                #endregion
            }
            catch (Exception ex)
            {
                Log.Error("Error");
            }
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //app.UseAllElasticApm(Configuration);
            Log.Error("Startup::Configure");
            try
            {
                if (env.EnvironmentName == "Development")
                    app.UseDeveloperExceptionPage();
                else
                    app.UseMiddleware<ExceptionHandler>();

#if DEBUG
                Environment.SetEnvironmentVariable("PROTOCOLO_URL", "http");
#else
                    Environment.SetEnvironmentVariable("PROTOCOLO_URL", "https");
#endif

                app.UseCors("CorsPolicy-public");  //apply to every request
                app.UseAuthentication(); //needs to be up in the pipeline, before MVC
                app.UseAuthorization();

                app.UseMvc();

                //Swagger API documentation
                app.UseSwagger();

                #region "Hangfire"
                TimeZoneInfo hrBrasilia = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");

                app.UseHangfireDashboard();

                var options = new BackgroundJobServerOptions() { WorkerCount = 1 };
                app.UseHangfireServer(options);

#if !DEBUG
                RecurringJob.AddOrUpdate<JobsController>(x => x.VerificaDailies(), Cron.Weekly(DayOfWeek.Monday, 07, 00), hrBrasilia);

                RecurringJob.AddOrUpdate<JobsController>(x => x.VerificaDicasAgileCoach(), Cron.Monthly(02, 05, 00), hrBrasilia);

                 RecurringJob.AddOrUpdate<JobsController>(x => x.VerificaDicasMelhoriaContinua(), Cron.Monthly(01, 05, 00), hrBrasilia);

                //Daily -- Aviso
                RecurringJob.AddOrUpdate<JobsController>("Daily", x => x.ConfiguraAvisoDeDailies(), Cron.Daily(01, 00), hrBrasilia);

                //Retrospectiva -- Aviso
                RecurringJob.AddOrUpdate<JobsController>("Retrospectiva", x => x.ConfiguraAvisoDeRetrospectivas(), Cron.Weekly(DayOfWeek.Monday, 02, 00), hrBrasilia);

                //Planning -- Aviso
                RecurringJob.AddOrUpdate<JobsController>("Planning", x => x.ConfiguraAvisoDePlanning(), Cron.Weekly(DayOfWeek.Monday, 03, 00), hrBrasilia);

                //Review -- Aviso
                RecurringJob.AddOrUpdate<JobsController>("Review", x => x.ConfiguraAvisoDeReview(), Cron.Weekly(DayOfWeek.Monday, 04, 00), hrBrasilia);
#endif
                #endregion

                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "goobeeteams API V1");
                    c.SwaggerEndpoint("/swagger/v2/swagger.json", "goobeeteams API V2");
                    c.DisplayOperationId();
                    c.DisplayRequestDuration();
                });

                //migrations and seeds from json files
                using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    if (Configuration["ConnectionStrings:UseInMemoryDatabase"] == "False" && !serviceScope.ServiceProvider.GetService<goobeeteamsContext>().AllMigrationsApplied())
                    {
                        if (Configuration["ConnectionStrings:UseMigrationService"] == "True")
                            serviceScope.ServiceProvider.GetService<goobeeteamsContext>().Database.Migrate();
                    }
                    //it will seed tables on aservice run from json files if tables empty
                    if (Configuration["ConnectionStrings:UseSeedService"] == "True")
                        serviceScope.ServiceProvider.GetService<goobeeteamsContext>().EnsureSeeded();
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }

        }
    }
}


namespace api.infrastructure.filters
{
    public class SwaggerSecurityRequirementsDocumentFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument document, DocumentFilterContext context)
        {
            document.SecurityRequirements = new List<OpenApiSecurityRequirement>
            {
                new OpenApiSecurityRequirement{
                    {
                        new OpenApiSecurityScheme{
                            Reference = new OpenApiReference{
                                Id = "Bearer", //The name of the previously defined security scheme.
                                Type = ReferenceType.SecurityScheme
                            }
                        },new List<string>()
                    }
                },
                new OpenApiSecurityRequirement{
                    {
                        new OpenApiSecurityScheme{
                            Reference = new OpenApiReference{
                                Id = "Basic", //The name of the previously defined security scheme.
                                Type = ReferenceType.SecurityScheme
                            }
                        },new List<string>()
                    }
                }
             };

        }
    }
}







