#pragma checksum "C:\Users\andre.corte\source\repos\NQS\NQS\NQS.HotSite\Views\Shared\_InternalLayout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0d72c24cab906208945e4ac18a5f1c3496e75992"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__InternalLayout), @"mvc.1.0.view", @"/Views/Shared/_InternalLayout.cshtml")]
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
#line 1 "C:\Users\andre.corte\source\repos\NQS\NQS\NQS.HotSite\_ViewImports.cshtml"
using Leega.HotSite;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\andre.corte\source\repos\NQS\NQS\NQS.HotSite\_ViewImports.cshtml"
using Leega.HotSite.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\andre.corte\source\repos\NQS\NQS\NQS.HotSite\Views\Shared\_InternalLayout.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0d72c24cab906208945e4ac18a5f1c3496e75992", @"/Views/Shared/_InternalLayout.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"abba63441b77c597d03af1c584c42ccbe4bd38fa", @"/_ViewImports.cshtml")]
    public class Views_Shared__InternalLayout : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_Footer.cshtml", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0d72c24cab906208945e4ac18a5f1c3496e759923904", async() => {
                WriteLiteral("\r\n    <meta charset=\"utf-8\">\r\n    <meta content=\"width=device-width, initial-scale=1.0\" name=\"viewport\">\r\n\r\n    <title>NQS</title>\r\n    <meta");
                BeginWriteAttribute("content", " content=\"", 239, "\"", 249, 0);
                EndWriteAttribute();
                WriteLiteral(@"
          name=""A AltruS é uma Startup de Tecnologia Social que tem como missão conectar pessoas e empresas que desejam ajudar às iniciativas sociais que precisam de ajuda."">
    <meta content=""Doação, Doações, altrus"" name=""keywords"">

    <!-- Favicons -->
    <link href=""/assets/img/apple-touch-icon.png"" rel=""apple-touch-icon"">

    <!-- Vendor CSS Files -->
    <link href=""/assets/vendor/bootstrap/css/bootstrap.min.css"" rel=""stylesheet"" />
    <link href=""/assets/vendor/icofont/icofont.min.css"" rel=""stylesheet"" />
    <link href=""/assets/vendor/boxicons/css/boxicons.min.css"" rel=""stylesheet"" />
    <link href=""/assets/vendor/venobox/venobox.css"" rel=""stylesheet"" />
    <link href=""/assets/vendor/owl.carousel/assets/owl.carousel.min.css"" rel=""stylesheet"" />
    <link href=""/assets/vendor/aos/aos.css"" rel=""stylesheet"" />
    <link href=""/assets/lib/datatables/css/jquery.dataTables.min.css"" rel=""stylesheet"" />

    <!-- Template Main CSS File -->
    <link href=""/assets/css/main.css"" rel=""s");
                WriteLiteral("tylesheet\">\r\n    <link");
                BeginWriteAttribute("href", " href=\"", 1296, "\"", 1333, 1);
#nullable restore
#line 27 "C:\Users\andre.corte\source\repos\NQS\NQS\NQS.HotSite\Views\Shared\_InternalLayout.cshtml"
WriteAttributeValue("", 1303, Url.Action("Style","Account"), 1303, 30, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" rel=""stylesheet"" type=""text/css"" />

    <!-- Vendor JS Files -->
    <script src=""/assets/vendor/jquery/jquery.min.js""></script>
    <script src=""/assets/lib/jquery.inputmask/jquery.inputmask.bundle.min.js""></script>
    <script src=""/assets/lib/jquery-validation/dist/jquery.validate.min.js""></script>
    <script src=""/assets/lib/jquery-validation-unobtrusive/jquery.validate.unobtrusive.min.js""></script>
    <script src=""/assets/lib/jquery-validation/dist/additional-methods.min.js""></script>
    <script src=""/assets/lib/jquery-validation/dist/localization/messages_pt_BR.min.js""></script>

    <script src=""/assets/vendor/bootstrap/js/bootstrap.bundle.min.js""></script>
    <script src=""/assets/vendor/jquery.easing/jquery.easing.min.js""></script>
    <script src=""/assets/vendor/isotope-layout/isotope.pkgd.min.js""></script>
    <script src=""/assets/vendor/venobox/venobox.min.js""></script>
    <script src=""/assets/vendor/owl.carousel/owl.carousel.min.js""></script>
    <script src=""/assets/vendor/a");
                WriteLiteral("os/aos.js\"></script>\r\n    <script src=\"/assets/lib/datatables/js/jquery.dataTables.min.js\"></script>\r\n    <script src=\"/assets/js/main.js\"></script>\r\n\r\n    ");
#nullable restore
#line 46 "C:\Users\andre.corte\source\repos\NQS\NQS\NQS.HotSite\Views\Shared\_InternalLayout.cshtml"
Write(RenderSection("Scripts", required: false));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
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
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0d72c24cab906208945e4ac18a5f1c3496e759928225", async() => {
                WriteLiteral("\r\n    <nav class=\"navbar fixed-top navbar-expand-lg header\">\r\n        <a href=\"/home/dashboard\" class=\"navbar-brand logo\"><img");
                BeginWriteAttribute("src", " src=\"", 2699, "\"", 2705, 0);
                EndWriteAttribute();
                WriteLiteral(@" /></a>
        <button class=""navbar-toggler navbar-dark"" type=""button"" data-toggle=""collapse"" data-target=""#navbarToggler"" aria-controls=""navbarToggler"" aria-expanded=""false"">
            <span class=""navbar-toggler-icon"">
                <span class=""icon-bar""></span>
                <span class=""icon-bar""></span>
                <span class=""icon-bar""></span>
            </span>
        </button>
        <div class=""collapse navbar-collapse justify-content-around"" id=""navbarToggler"">
            <ul class=""navbar-nav"">
                <li class=""nav-item""><a class=""nav-link"" href=""/home/transparencia"">Transparência</a></li>
                <li class=""nav-item""><a class=""nav-link"" href=""#"">Causas que apoio</a></li>
                <li class=""nav-item""><a class=""nav-link"" href=""#"">Comunicados</a></li>
                <li class=""nav-item""><a class=""nav-link"" href=""#"">Novidades</a></li>
            </ul>
            <ul class=""no-bullet"">
                <li class=""dropdown notification-list"">");
                WriteLiteral("\r\n                    <a class=\"dropdown-toggle arrow-none\" data-toggle=\"dropdown\" href=\"#\" role=\"button\" aria-haspopup=\"false\" aria-expanded=\"false\">\r\n");
#nullable restore
#line 68 "C:\Users\andre.corte\source\repos\NQS\NQS\NQS.HotSite\Views\Shared\_InternalLayout.cshtml"
                         if (HttpContextAccessor.HttpContext.Session.GetString("userpicture") != null)
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <span class=\"account-user-avatar\">\r\n                            <img");
                BeginWriteAttribute("src", " src=\'", 4105, "\'", 4176, 1);
#nullable restore
#line 71 "C:\Users\andre.corte\source\repos\NQS\NQS\NQS.HotSite\Views\Shared\_InternalLayout.cshtml"
WriteAttributeValue("", 4111, HttpContextAccessor.HttpContext.Session.GetString("userpicture"), 4111, 65, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" alt=\"user-image\" class=\"rounded-circle\">\r\n                        </span>\r\n");
#nullable restore
#line 73 "C:\Users\andre.corte\source\repos\NQS\NQS\NQS.HotSite\Views\Shared\_InternalLayout.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <span class=\"account-user-avatar icofont-ui-user icofont-2x\">\r\n\r\n                        </span>\r\n");
#nullable restore
#line 79 "C:\Users\andre.corte\source\repos\NQS\NQS\NQS.HotSite\Views\Shared\_InternalLayout.cshtml"
                        }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                    </a>
                    <div class=""dropdown-menu dropdown-menu-right dropdown-menu-animated topbar-dropdown-menu profile-dropdown"">
                        <div class="" dropdown-header noti-title"">
                            <h6 class=""text-overflow m-0"">
                                Olá <span class=""account-user-name"">
                                    <strong>
                                        ");
#nullable restore
#line 86 "C:\Users\andre.corte\source\repos\NQS\NQS\NQS.HotSite\Views\Shared\_InternalLayout.cshtml"
                                   Write(HttpContextAccessor.HttpContext.Session.GetString("username"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                    </strong>,
                                </span><br> Seja Bem-vindo!
                            </h6>
                        </div>
                        <!-- item-->
                        <a href=""/doacao/index"" class=""dropdown-item notify-item"">
                            <i class='bx bx-id-card'></i>
                            <span>Minha Conta</span>
                        </a>

                        <!-- item-->
                        <a href=""javascript:void(0);"" class=""dropdown-item notify-item"">
                            <i class='bx bx-cog'></i>
                            <span>Configurações</span>
                        </a>

                        <!-- item-->
                        <a href=""javascript:void(0);"" class=""dropdown-item notify-item"">
                            <i class='bx bx-message-rounded-dots'></i>
                            <span>Suporte</span>
                        </a>

                        <!");
                WriteLiteral(@"-- item-->
                        <a href=""/account/logout"" class=""dropdown-item notify-item"">
                            <i class='bx bx-log-out'></i>
                            <span>Logout</span>
                        </a>
                    </div>
                </li>
            </ul>
        </div>
    </nav>
    <div class=""main"">
        ");
#nullable restore
#line 120 "C:\Users\andre.corte\source\repos\NQS\NQS\NQS.HotSite\Views\Shared\_InternalLayout.cshtml"
   Write(RenderBody());

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    </div>\r\n\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "0d72c24cab906208945e4ac18a5f1c3496e7599214116", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n    <a href=\"#\" class=\"back-to-top\"><i class=\"icofont-simple-up\"></i></a>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IHttpContextAccessor HttpContextAccessor { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
