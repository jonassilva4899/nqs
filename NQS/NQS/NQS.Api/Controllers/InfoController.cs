using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

/// <summary>
/// This controller is an example of API versioning
/// </summary>

namespace Leega.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class InfoController : ControllerBase
    {

        public IConfiguration Configuration { get; }
        public InfoController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        //get info
        [AllowAnonymous]
        [HttpGet]
        [Produces("application/json")]
        public IActionResult ApiInfo()
        {

            var migration = Configuration["ConnectionStrings:UseMigrationService"];
            var seed = Configuration["ConnectionStrings:UseSeedService"];
            var memorydb = Configuration["ConnectionStrings:UseInMemoryDatabase"];

#if DEBUG
            var connstring = Configuration["ConnectionStrings:goobeeteamsDB"];
            //var connstring = Configuration["ConnectionStrings:torkeyisDB"];            
            var botaoSwagger = "<a class='btn btn-outline-primary' role='button' href='/swagger'><b>Swagger API specification</b></a>";
            var controlers = MvcHelper.GetControllerMethodsNames();
            var labelConnString = "<li>Connection String: ";

            var itens = @"<div class='row'>

                    <div class='col-md-3'>
                    <h3>API controlers and methods</h3>
                    <ul>" + controlers + @"</ul>
                    <p></p>
                    </div>
                    <div class='col-md-3'>
                    <h3>API services and patterns</h3>
                    <p><ul><li>Dependency Injection (Net Core feature) </li><li>Repository and Unit of Work Patterns</li><li>Generic services</li><li>Automapper</li><li>Sync and Async calls</li><li>Generic exception handler</li><li>Serilog logging with Console and File sinks</li><li>Seed from json objects</li><li>JWT authorization and authentication</li></ul>
                    </div>
                    <div class='col-md-3'>
                    <h3>API projects</h3>
                    <ul><li>Api</li><li>Domain</li><li>Entity</li></ul>
                    </div>

                    </div>";

#else
                var connstring = string.Empty;
                var botaoSwagger = string.Empty;
                var controlers = string.Empty;
                var labelConnString = string.Empty;
                var itens = string.Empty;
#endif

            var authentication = Configuration["Authentication:UseIndentityServer4"];
            var is4ip = Configuration["Authentication:IndentityServer4IP"];

            return Content("<html><head><link rel='stylesheet' href='https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta.2/css/bootstrap.min.css' integrity='sha384-PsH8R72JQ3SOdhVi3uxftmaW6Vc51MKb0q5P2rRUpPvrszuE4W1povHYgTpBfshb' crossorigin='anonymous'><link rel='stylesheet' href='https://use.fontawesome.com/releases/v5.3.1/css/all.css' integrity='sha384-mzrmE5qonljUremFsqc01SB46JvROS7bZs3IO2EmfFsd15uHvIt+Y8vEf7N7fWAU' crossorigin='anonymous'></head><body>" +

                "<div class='jumbotron'>" +
                "<h1><i class='fab fa-centercode' fa-2x></i>  goobeeteams Api v.1</h1>" +
                "<h4>v.4.6</h4>" +
                 "NET.Core Api REST service started!<br>" +
                 "appsettings.json configuration:<br>" +
                 "<ul><li>NetCore: 3.1</li>" +
                 "<li>Use Migration Service: " + migration + "</li>" +
                 "<li>Use Seed Service: " + seed + "</li>" +
                 "<li>Use InMemory Database: " + memorydb + "</li>" +
                  "<li>Authentication Type: " + (authentication == "True" ? "IS4" : "JWT") + "</li>" +
                  (authentication == "True" ? "<li>IndentityServer4IP: " + is4ip + "</li>" : "") +
                  labelConnString + connstring + "</li></ul>" +
                 botaoSwagger +
                "</div>" +

                itens +
                "</body></html>"
               , "text/html");

        }

    }

    public class MvcHelper
    {
        private static List<Type> GetSubClasses<T>()
        {
            return Assembly.GetCallingAssembly().GetTypes().Where(
                type => type.IsSubclassOf(typeof(T))).ToList();
        }

        public static string GetControllerMethodsNames()
        {
            List<Type> cmdtypes = GetSubClasses<ControllerBase>();
            var controlersInfo = "";
            foreach (Type ctrl in cmdtypes)
            {
                var methodsInfo = "";
                const BindingFlags flags = BindingFlags.Public | BindingFlags.Instance;
                MemberInfo[] methodName = ctrl.GetMethods(flags);
                foreach (MemberInfo method in methodName)
                {
                    if (method.DeclaringType.ToString() == ctrl.UnderlyingSystemType.ToString())
                        methodsInfo += "<li><i>" + method.Name.ToString() + "</i></li>";
                }
                controlersInfo += "<li>" + ctrl.Name.Replace("Controller", "") + "<ul>" + methodsInfo + "</ul></li>";
            }
            return controlersInfo;
        }
    }

}


namespace Leega.Api.Controllers.v2
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class InfoController : ControllerBase
    {

        public IConfiguration Configuration { get; }
        public InfoController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        //get info
        [AllowAnonymous]
        [HttpGet]
        [Produces("application/json")]
        public IActionResult ApiInfo()
        {

            var migration = Configuration["ConnectionStrings:UseMigrationService"];
            var seed = Configuration["ConnectionStrings:UseSeedService"];
            var memorydb = Configuration["ConnectionStrings:UseInMemoryDatabase"];

#if DEBUG
            //var connstring = Configuration["ConnectionStrings:goobeeteamsDB"];
            var connstring = Configuration["ConnectionStrings:torkeyisDB"];
            var botaoSwagger = "<a class='btn btn-outline-primary' role='button' href='/swagger'><b>Swagger API specification</b></a>";
            var controlers = MvcHelper.GetControllerMethodsNames();
            var labelConnString = "<li>Connection String: ";

            var itens = @"<div class='row'>

                    <div class='col-md-3'>
                    <h3>API controlers and methods</h3>
                    <ul>" + controlers + @"</ul>
                    <p></p>
                    </div>
                    <div class='col-md-3'>
                    <h3>API services and patterns</h3>
                    <p><ul><li>Dependency Injection (Net Core feature) </li><li>Repository and Unit of Work Patterns</li><li>Generic services</li><li>Automapper</li><li>Sync and Async calls</li><li>Generic exception handler</li><li>Serilog logging with Console and File sinks</li><li>Seed from json objects</li><li>JWT authorization and authentication</li></ul>
                    </div>
                    <div class='col-md-3'>
                    <h3>API projects</h3>
                    <ul><li>Api</li><li>Domain</li><li>Entity</li></ul>
                    </div>

                    </div>";

#else
                var connstring = string.Empty;
                var botaoSwagger = string.Empty;
                var controlers = string.Empty;
                var labelConnString = string.Empty;
                var itens = string.Empty;
#endif

            var authentication = Configuration["Authentication:UseIndentityServer4"];
            var is4ip = Configuration["Authentication:IndentityServer4IP"];

            return Content("<html><head><link rel='stylesheet' href='https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta.2/css/bootstrap.min.css' integrity='sha384-PsH8R72JQ3SOdhVi3uxftmaW6Vc51MKb0q5P2rRUpPvrszuE4W1povHYgTpBfshb' crossorigin='anonymous'><link rel='stylesheet' href='https://use.fontawesome.com/releases/v5.3.1/css/all.css' integrity='sha384-mzrmE5qonljUremFsqc01SB46JvROS7bZs3IO2EmfFsd15uHvIt+Y8vEf7N7fWAU' crossorigin='anonymous'></head><body>" +

                "<div class='jumbotron'>" +
                "<h1><i class='fab fa-centercode' fa-2x></i>  goobeeteams Api v.1</h1>" +
                "<h4>v.4.6</h4>" +
                 "NET.Core Api REST service started!<br>" +
                 "appsettings.json configuration:<br>" +
                 "<ul><li>NetCore: 3.1</li>" +
                 "<li>Use Migration Service: " + migration + "</li>" +
                 "<li>Use Seed Service: " + seed + "</li>" +
                 "<li>Use InMemory Database: " + memorydb + "</li>" +
                  "<li>Authentication Type: " + (authentication == "True" ? "IS4" : "JWT") + "</li>" +
                  (authentication == "True" ? "<li>IndentityServer4IP: " + is4ip + "</li>" : "") +
                  labelConnString + connstring + "</li></ul>" +
                 botaoSwagger +
                "</div>" +

                itens +
                "</body></html>"
               , "text/html");

        }

    }

    public class MvcHelper
    {
        private static List<Type> GetSubClasses<T>()
        {
            return Assembly.GetCallingAssembly().GetTypes().Where(
                type => type.IsSubclassOf(typeof(T))).ToList();
        }

        public static string GetControllerMethodsNames()
        {
            List<Type> cmdtypes = GetSubClasses<ControllerBase>();
            var controlersInfo = "";
            foreach (Type ctrl in cmdtypes)
            {
                var methodsInfo = "";
                const BindingFlags flags = BindingFlags.Public | BindingFlags.Instance;
                MemberInfo[] methodName = ctrl.GetMethods(flags);
                foreach (MemberInfo method in methodName)
                {
                    if (method.DeclaringType.ToString() == ctrl.UnderlyingSystemType.ToString())
                        methodsInfo += "<li><i>" + method.Name.ToString() + "</i></li>";
                }
                controlersInfo += "<li>" + ctrl.Name.Replace("Controller", "") + "<ul>" + methodsInfo + "</ul></li>";
            }
            return controlersInfo;
        }
    }

}

