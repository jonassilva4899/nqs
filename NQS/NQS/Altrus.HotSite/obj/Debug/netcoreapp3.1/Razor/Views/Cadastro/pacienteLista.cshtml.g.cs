#pragma checksum "C:\nsq_08122020\nqs\NQS\NQS\Altrus.HotSite\Views\Cadastro\pacienteLista.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1ad4f2d14c269b6db78de4fa7525968d0a1cdf81"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cadastro_pacienteLista), @"mvc.1.0.view", @"/Views/Cadastro/pacienteLista.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\nsq_08122020\nqs\NQS\NQS\Altrus.HotSite\_ViewImports.cshtml"
using Leega.UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\nsq_08122020\nqs\NQS\NQS\Altrus.HotSite\_ViewImports.cshtml"
using Leega.UI.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\nsq_08122020\nqs\NQS\NQS\Altrus.HotSite\Views\Cadastro\pacienteLista.cshtml"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1ad4f2d14c269b6db78de4fa7525968d0a1cdf81", @"/Views/Cadastro/pacienteLista.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"756b0c539fb7a53f1fc5543480fb3a3073c5a2e0", @"/_ViewImports.cshtml")]
    public class Views_Cadastro_pacienteLista : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Leega.Dtos.Paciente>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/img/ALTERALOGO_ALT.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("ms-body ms-aside-left-open ms-primary-theme ms-has-quickbar"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<!DOCTYPE html>\r\n<html lang=\"en\">\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1ad4f2d14c269b6db78de4fa7525968d0a1cdf814393", async() => {
                WriteLiteral(@"

    <meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8"">
    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">
    <meta name=""viewport"" content=""width=device-width,initial-scale=1"">
    <title>NQS</title>
    <!-- Iconic Fonts -->
    <link href=""https://fonts.googleapis.com/icon?family=Material+Icons"" rel=""stylesheet"">
    <link href=""../../vendors/iconic-fonts/font-awesome/css/all.min.css"" rel=""stylesheet"">
    <link rel=""stylesheet"" href=""../../vendors/iconic-fonts/flat-icons/flaticon.css"">
    <link rel=""stylesheet"" href=""../../vendors/iconic-fonts/cryptocoins/cryptocoins.css"">
    <link rel=""stylesheet"" href=""../../vendors/iconic-fonts/cryptocoins/cryptocoins-colors.css"">
    <!-- Bootstrap core CSS -->
    <link href=""../../assets/css/bootstrap.min.css"" rel=""stylesheet"">
    <!-- jQuery UI -->
    <link href=""../../assets/css/jquery-ui.min.css"" rel=""stylesheet"">
    <!-- Page Specific CSS (Slick Slider.css) -->
    <link href=""../../assets/css/slick.css"" rel=""style");
                WriteLiteral(@"sheet"">
    <!-- Medboard styles -->
    <link href=""../../assets/css/style.css"" rel=""stylesheet"">

    <!-- Favicon -->
    <link rel=""icon"" type=""image/png"" sizes=""32x32"" href=""../../favicon.ico"">
    <!-- Page Specific Css (Datatables.css) -->
    <link href=""../../assets/css/datatables.min.css"" rel=""stylesheet"">

");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1ad4f2d14c269b6db78de4fa7525968d0a1cdf816808", async() => {
                WriteLiteral(@"



    <!-- Preloader -->
    <div id=""preloader-wrap"">
        <div class=""spinner spinner-8"">
            <div class=""ms-circle1 ms-child""></div>
            <div class=""ms-circle2 ms-child""></div>
            <div class=""ms-circle3 ms-child""></div>
            <div class=""ms-circle4 ms-child""></div>
            <div class=""ms-circle5 ms-child""></div>
            <div class=""ms-circle6 ms-child""></div>
            <div class=""ms-circle7 ms-child""></div>
            <div class=""ms-circle8 ms-child""></div>
            <div class=""ms-circle9 ms-child""></div>
            <div class=""ms-circle10 ms-child""></div>
            <div class=""ms-circle11 ms-child""></div>
            <div class=""ms-circle12 ms-child""></div>
        </div>
    </div>

    

    <!-- Sidebar Navigation Left -->
    <!-- Sidebar Navigation Left -->
    <aside id=""ms-side-nav"" class=""side-nav fixed ms-aside-scrollable ms-aside-left"">

        <!-- Logo -->
        <div class=""logo-sn ms-d-block-lg"">
          ");
                WriteLiteral("  <a class=\"pl-0 ml-0 text-center\" href=\"../Home/index\"> ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "1ad4f2d14c269b6db78de4fa7525968d0a1cdf818217", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@" </a>
        </div>

        <!-- Navigation -->
        <ul class=""accordion ms-main-aside fs-14"" id=""side-nav-accordion"">
            <!-- Dashboard -->
            <!-- Dashboard -->
            <li class=""menu-item"">
                <a href=""#"" class=""has-chevron"" data-toggle=""collapse"" data-target=""#dashboard"" aria-expanded=""false"" aria-controls=""dashboard"">
                    <span><i class=""material-icons fs-16"">dashboard</i>Dashboard </span>
                </a>
                <ul id=""dashboard"" class=""collapse"" aria-labelledby=""dashboard"" data-parent=""#side-nav-accordion"">
                    <li> <a href=""index.html"">Medboard</a> </li>
                </ul>
            </li>
            <!-- Doctor -->
            <li class=""menu-item"">
                <a href=""#"" class=""has-chevron"" data-toggle=""collapse"" data-target=""#Medico"" aria-expanded=""false"" aria-controls=""Medico"">
                    <span><i class=""fas fa-sitemap""></i>Médico</span>
                </a>
              ");
                WriteLiteral(@"  <ul id=""Medico"" class=""collapse"" aria-labelledby=""Medico"" data-parent=""#side-nav-accordion"">
                    <li> <a href=""pages/department/add-department.html"">Adicionar Médico</a> </li>
                    <li> <a href=""pages/department/department-list.html"">Listar Médicos</a> </li>
                </ul>
            </li>
            <!-- Patient -->
            <li class=""menu-item"">
                <a href=""#"" class=""has-chevron"" data-toggle=""collapse"" data-target=""#Paciente"" aria-expanded=""false"" aria-controls=""Paciente"">
                    <span><i class=""fas fa-user""></i>Paciente</span>
                </a>
                <ul id=""Paciente"" class=""collapse"" aria-labelledby=""Paciente"" data-parent=""#side-nav-accordion"">
                    <li> <a href=""../cadastro/Paciente"">Adicionar Paciente</a> </li>
                    <li> <a href=""../cadastro/PacienteLista"">Listar Pacientes</a> </li>
                </ul>
            </li>
            <!-- /Patient -->
            <!-- Funcio");
                WriteLiteral(@"narios -->
            <li class=""menu-item"">
                <a href=""#"" class=""has-chevron"" data-toggle=""collapse"" data-target=""#Funcionario"" aria-expanded=""false"" aria-controls=""Funcionario"">
                    <span><i class=""fas fa-sitemap""></i>Funcionário</span>
                </a>
                <ul id=""Funcionario"" class=""collapse"" aria-labelledby=""Funcionario"" data-parent=""#side-nav-accordion"">
                    <li> <a href=""pages/department/add-department.html"">Adicionar Funcionário</a> </li>
                    <li> <a href=""pages/department/department-list.html"">Listar Funcionários</a> </li>
                </ul>
            </li>
            <!-- /Funcionarios -->
            <!-- Cliente -->
            <li class=""menu-item"">
                <a href=""#"" class=""has-chevron"" data-toggle=""collapse"" data-target=""#Cliente"" aria-expanded=""false"" aria-controls=""Cliente"">
                    <span><i class=""fas fa-sitemap""></i>Cliente</span>
                </a>
                <ul");
                WriteLiteral(@" id=""Cliente"" class=""collapse"" aria-labelledby=""Cliente"" data-parent=""#side-nav-accordion"">
                    <li> <a href=""pages/department/add-department.html"">Adicionar Cliente</a> </li>
                    <li> <a href=""pages/department/department-list.html"">Listar Clientes</a> </li>
                </ul>
            </li>
            <!-- /Cliente -->
            <!-- Clinica -->
            <li class=""menu-item"">
                <a href=""#"" class=""has-chevron"" data-toggle=""collapse"" data-target=""#Clinica"" aria-expanded=""false"" aria-controls=""Clinica"">
                    <span><i class=""fas fa-sitemap""></i>Clinica</span>
                </a>
                <ul id=""Clinica"" class=""collapse"" aria-labelledby=""Clinica"" data-parent=""#side-nav-accordion"">
                    <li> <a href=""pages/department/add-department.html"">Adicionar Clinica</a> </li>
                    <li> <a href=""pages/department/department-list.html"">Listar Clinicas</a> </li>
                </ul>
            </li>
");
                WriteLiteral(@"        </ul>

    </aside>

    <!-- Sidebar Right -->
    <aside id=""ms-recent-activity"" class=""side-nav fixed ms-aside-right ms-scrollable"">

        <div class=""ms-aside-header"">
            <ul class=""nav nav-tabs tabs-bordered d-flex nav-justified mb-3"" role=""tablist"">
                <li role=""presentation"" class=""fs-12""><a href=""#activityLog"" aria-controls=""activityLog"" class=""active"" role=""tab"" data-toggle=""tab""> Activity Log</a></li>
                <li role=""presentation"" class=""fs-12""><a href=""#recentPosts"" aria-controls=""recentPosts"" role=""tab"" data-toggle=""tab""> Settings </a></li>
                <li><button type=""button"" class=""close ms-toggler text-center"" data-target=""#ms-recent-activity"" data-toggle=""slideRight""><span aria-hidden=""true"">&times;</span></button></li>
            </ul>
        </div>
    </aside>

    <!-- Main Content -->
    <main class=""body-content"">

        <!-- Navigation Bar -->
        <nav class=""navbar ms-navbar"">
            <div class=""ms-aside");
                WriteLiteral(@"-toggler ms-toggler pl-0"" data-target=""#ms-side-nav"" data-toggle=""slideLeft"">
                <span class=""ms-toggler-bar bg-white""></span>
                <span class=""ms-toggler-bar bg-white""></span>
                <span class=""ms-toggler-bar bg-white""></span>
            </div>
            <div class=""logo-sn logo-sm ms-d-block-sm"">
                <a class=""pl-0 ml-0 text-center navbar-brand mr-0"" href=""../../index.html""><img src=""https://via.placeholder.com/84x41"" alt=""logo""> </a>
            </div>
            <ul class=""ms-nav-list ms-inline mb-0"" id=""ms-nav-options"">
            </ul>
            <div class=""ms-toggler ms-d-block-sm pr-0 ms-nav-toggler"" data-toggle=""slideDown"" data-target=""#ms-nav-options"">
                <span class=""ms-toggler-bar bg-primary""></span>
                <span class=""ms-toggler-bar bg-primary""></span>
                <span class=""ms-toggler-bar bg-primary""></span>
            </div>
        </nav>


        <!-- Body Content Wrapper -->
        <div ");
                WriteLiteral(@"class=""ms-content-wrapper"">
            <div class=""row"">

                <div class=""col-md-12"">
                    <nav aria-label=""breadcrumb"">
                        <ol class=""breadcrumb pl-0"">
                            <li class=""breadcrumb-item""><a href=""#""><i class=""material-icons"">home</i> Home</a></li>
                            <li class=""breadcrumb-item""><a href=""#"">Paciente</a></li>
                            <li class=""breadcrumb-item active"" aria-current=""page"">Cadastro Paciente</li>
                        </ol>
                    </nav>


");
                WriteLiteral(@"                    <div class=""ms-panel"">
                        <div class=""ms-panel-header ms-panel-custome"">
                            <h6>Cadastro Paciente</h6>
                            <a href=""../cadastro/Paciente""><h6>Adicionar Paciente</h6></a>
                        </div>
                        <div class=""ms-panel-body"">
                            <div class=""table-responsive"">
");
                WriteLiteral(@"                                <table id=""GridPaciente"" class=""table table-striped thead-primary w-100""></table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </main>




    <!-- SCRIPTS -->
    <!-- Global Required Scripts Start -->
    <script src=""../../assets/js/jquery-3.3.1.min.js""></script>
    <script src=""../../assets/js/popper.min.js""></script>
    <script src=""../../assets/js/bootstrap.min.js""></script>
    <script src=""../../assets/js/perfect-scrollbar.js""></script>
    <script src=""../../assets/js/jquery-ui.min.js""></script>
    <!-- Global Required Scripts End -->
    <!-- Page Specific Scripts Start -->
    <script src=""../../assets/js/slick.min.js""></script>
    <script src=""../../assets/js/moment.js""></script>
    <script src=""../../assets/js/jquery.webticker.min.js""></script>
    <script src=""../../assets/js/Chart.bundle.min.js""></script>
    <script src=""..");
                WriteLiteral(@"/../assets/js/Chart.Financial.js""></script>

    <!-- Page Specific Scripts Finish -->
    <!-- Page Specific Scripts Start -->
    <script src=""../../assets/js/datatables.min.js""></script>
    <script src=""../../assets/js/data-tables.js""></script>
    <!-- Page Specific Scripts End -->
    <!-- Medboard core JavaScript -->
    <script src=""../../assets/js/framework.js""></script>

    <!-- Settings -->
    <script src=""../../assets/js/settings.js""></script>

");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n\r\n<script>\r\n\r\n    //alert(dataSet);\r\n    jQuery(document).ready(function () {\r\n        var dataSet = ");
#nullable restore
#line 241 "C:\nsq_08122020\nqs\NQS\NQS\Altrus.HotSite\Views\Cadastro\pacienteLista.cshtml"
                 Write(Html.Raw(JsonConvert.SerializeObject(this.Model)));

#line default
#line hidden
#nullable disable
            WriteLiteral(@";
        dataSet = JSON.stringify(dataSet)
        var obj = JSON.parse(dataSet);
        
        $('#GridPaciente').DataTable({
            data: obj,
            ""language"": {
                ""lengthMenu"": ""Exibe _MENU_ Registros por página"",
                ""search"": ""Procurar"",
                ""paginate"": { ""previous"": ""Retorna"", ""next"": ""Avança"" },
                ""zeroRecords"": ""Nada foi encontrado"",
                ""info"": ""Exibindo página _PAGE_ de _PAGES_"",
                ""infoEmpty"": ""Sem registros"",
                ""infoFiltered"": ""(filtrado de _MAX_ regitros totais)""
            },
            ""processing"": true, // mostrar a progress bar
            //""serverSide"": true, // processamento no servidor
            ""filter"": true, // habilita o filtro(search box)
            ""lengthMenu"": [[3, 5, 10, 25, 50, -1], [3, 5, 10, 25, 50, ""Todos""]],
            ""pageLength"": 10, // define o tamanho da página
            //""ajax"": {
            //    ""url"": ""https://localhost:44391/PA");
            WriteLiteral(@"CIENTE/ListarPacientesGrid"",
            //    ""type"": ""POST"",
            //    ""dataType"": ""json""
            //},
            ""columns"":
             [
                 { ""data"": ""NomeCompleto"", ""title"": ""Nome"", ""autowidth"": true },
                 { ""data"": ""Celular"", ""title"": ""Celular"", ""autowidth"": true },
                    { ""data"": ""Rg"", ""title"": ""Rg"", ""autowidth"": true },
                    {
                        ""render"": function (data, type, full, meta) {
                            return '<a class=""fa-edit"" href=""../cadastro/pacienteEditar/' + full.Id + '"">Edit</a>'; }
                    },  
                    //{
                    //    data: null,
                    //    className: ""center"",
                    //    defaultContent: '<a href=""../cadastro/paciente""  class=""editor_edit"">Edit</a> / <a href=""../cadastro/paciente"" class=""editor_remove"">Deletar</a>'
                    //},
                     //{
                     //   data: ""Id"",
             ");
            WriteLiteral("        //   render: function (data, type, row) {\r\n                     //       return `<button class=\'edit\' >edit</button>`;\r\n                     //   }\r\n             ]\r\n        });\r\n    });\r\n\r\n\r\n</script>\r\n\r\n</html>\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Leega.Dtos.Paciente>> Html { get; private set; }
    }
}
#pragma warning restore 1591
