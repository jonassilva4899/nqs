#pragma checksum "C:\nqs_2020\nqs\NQS\NQS\Altrus.HotSite\Views\Shared\_Layout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0a624a6f65461b696089f42f7ce89c5a9e819712"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Layout), @"mvc.1.0.view", @"/Views/Shared/_Layout.cshtml")]
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
#line 1 "C:\nqs_2020\nqs\NQS\NQS\Altrus.HotSite\_ViewImports.cshtml"
using Leega.UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\nqs_2020\nqs\NQS\NQS\Altrus.HotSite\_ViewImports.cshtml"
using Leega.UI.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0a624a6f65461b696089f42f7ce89c5a9e819712", @"/Views/Shared/_Layout.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"756b0c539fb7a53f1fc5543480fb3a3073c5a2e0", @"/_ViewImports.cshtml")]
    public class Views_Shared__Layout : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
            WriteLiteral("<!DOCTYPE html>\r\n<html lang=\"pt\">\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0a624a6f65461b696089f42f7ce89c5a9e8197123640", async() => {
                WriteLiteral("\r\n    <meta charset=\"utf-8\">\r\n    <meta content=\"width=device-width, initial-scale=1.0\" name=\"viewport\">\r\n\r\n    <title>NQS</title>\r\n    <meta");
                BeginWriteAttribute("content", " content=\"", 184, "\"", 194, 0);
                EndWriteAttribute();
                WriteLiteral(@"
          name=""NQS"">
    <meta content=""NQS"" name=""keywords"">

    <!-- Favicons -->
    <link href=""/assets/img/apple-touch-icon.png"" rel=""apple-touch-icon"">

    <!-- Vendor CSS Files -->
    <link href=""/assets/vendor/bootstrap/css/bootstrap.min.css"" rel=""stylesheet"" />
    <link href=""/assets/vendor/icofont/icofont.min.css"" rel=""stylesheet"" />
    <link href=""/assets/vendor/boxicons/css/boxicons.min.css"" rel=""stylesheet"" />
    <link href=""/assets/vendor/venobox/venobox.css"" rel=""stylesheet"" />
    <link href=""/assets/vendor/owl.carousel/assets/owl.carousel.min.css"" rel=""stylesheet"" />
    <link href=""/assets/vendor/aos/aos.css"" rel=""stylesheet"" />
    <link href=""/assets/lib/datatables/css/dataTables.bootstrap.min.css"" rel=""stylesheet"" />

    <!-- Template Main CSS File -->
    <link href=""/assets/css/main.css"" rel=""stylesheet"">
    <link");
                BeginWriteAttribute("href", " href=\"", 1071, "\"", 1108, 1);
#nullable restore
#line 27 "C:\nqs_2020\nqs\NQS\NQS\Altrus.HotSite\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 1078, Url.Action("Style","Account"), 1078, 30, false);

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
                WriteLiteral("os/aos.js\"></script>\r\n    <script src=\"/assets/js/main.js\"></script>\r\n\r\n    ");
#nullable restore
#line 45 "C:\nqs_2020\nqs\NQS\NQS\Altrus.HotSite\Views\Shared\_Layout.cshtml"
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0a624a6f65461b696089f42f7ce89c5a9e8197127624", async() => {
                WriteLiteral(@"
    <nav class=""navbar fixed-top navbar-expand-lg header"">
        <a href=""/home/index"" class=""navbar-brand""><img src=""/assets/img/ALTERALOGO_ALT.png""></a>
        <button class=""navbar-toggler navbar-dark"" type=""button"" data-toggle=""collapse"" data-target=""#navbarToggler"" aria-controls=""navbarToggler"" aria-expanded=""false"">
            <span class=""navbar-toggler-icon"">
                <span class=""icon-bar""></span>
                <span class=""icon-bar""></span>
                <span class=""icon-bar""></span>
            </span>
        </button>
        <div class=""collapse navbar-collapse justify-content-around"" id=""navbarToggler"">
            <ul class=""navbar-nav"">
                <li class=""nav-item"">
                    <a class=""nav-link"" href=""/account/login"">Inicial</a>
                </li>
                <li class=""nav-item"">
                    <a class=""nav-link"" href=""/account/login"">NQS</a>
                </li>
                <li class=""nav-item"">
                    <a c");
                WriteLiteral(@"lass=""nav-link"" href=""/account/login"">Causas</a>
                </li>
                <li class=""nav-item dropdown"">
                    <a class=""nav-link dropdown-toggle"" herf=""#"" data-toggle=""dropdown"" id=""menuArtigo"">Artigos</a>
                    <div class=""dropdown-menu"" aria-labelledby=""menuArtigo"">
                        <a class=""nav-link"" href=""/home/bloginterna"">Interna do Blog</a>
                    </div>
                </li>
                <li class=""nav-item"">
                    <a class=""nav-link"" href=""/home/transparencia"">Transparência</a>
                </li>
                <li class=""nav-item"">
                    <a class=""nav-link"" href=""/home/contato"">Contato</a>
                </li>
                <li class=""nav-item"">
                    <a class=""nav-link"" href=""/account/login"">Login</a>
                </li>
                <li class=""nav-item"">
                    <a href=""#modal-cadastre-se"" data-toggle=""modal"" data-backdrop=""static"" data-keyboard=""fa");
                WriteLiteral(@"lse""
                       data-target=""#modal-cadastre-se"" class=""nav-link btn btn-whiteonblue btn-fitcontent"">CADASTRE-SE</a>
                </li>
                <li class=""nav-item"">
                    <a class=""nav-link"" href=""#""></a>
                </li>
                <li class=""nav-item"">
                    <a class=""nav-link btn btn-blackonorange btn-fitcontent"" href=""/home/whitelabel"">CONTRATAR WHITE LABEL</a>
                </li>
            </ul>
        </div>
    </nav>
    <div class=""main"">
        ");
#nullable restore
#line 97 "C:\nqs_2020\nqs\NQS\NQS\Altrus.HotSite\Views\Shared\_Layout.cshtml"
   Write(RenderBody());

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
        <!-- Modal Cadastre-se -->
        <div id=""modal-cadastre-se"" class=""modal fade bd-cart-lg-causes"" tabindex=""-1"" role=""dialog"">
            <div class=""modal-dialog"">
                <div class=""modal-content"">

                    <div class=""modal-header position-absolute w-100 border-0"" style=""z-index: 2;"">
                        <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                            <span aria-hidden=""true"">&times;</span>
                        </button>
                    </div>

                    <div class=""modal-body"">
                        <div class=""row mx-0 mb-3"">
                            <div class=""col-sm-12 mt-5"">
                                <h4 class=""title mb-3"">Cadastre-se!</h4>
                                <p class=""mb-3"" style=""color: #2F2F30!important;font-size:15px"">
                                    Selecione abaixo qual tipo de cadastro
                                    deseja realizar:
");
                WriteLiteral("                                </p>\r\n                                <a");
                BeginWriteAttribute("href", " href=\"", 5965, "\"", 6025, 1);
#nullable restore
#line 117 "C:\nqs_2020\nqs\NQS\NQS\Altrus.HotSite\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 5972, Url.Action("register","account", new { tipo = "F" }), 5972, 53, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" target=""_blank"">
                                    <button class=""modal__btn--cadastre-se"">
                                        <strong>Quero Ajudar</strong>
                                        (Cadastro Altruísta Pessoa Física)
                                    </button>
                                </a>
                                <a");
                BeginWriteAttribute("href", " href=\"", 6389, "\"", 6449, 1);
#nullable restore
#line 123 "C:\nqs_2020\nqs\NQS\NQS\Altrus.HotSite\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 6396, Url.Action("register","account", new { tipo = "J" }), 6396, 53, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" target=""_blank"">
                                    <button class=""modal__btn--cadastre-se"">
                                        <strong>Quero Ajudar</strong>
                                        (Cadastro Altruísta Pessoa Jurídica)
                                    </button>
                                </a>
                                <a href=""/cadastro/embaixador"" target=""_blank"">
                                    <button class=""modal__btn--cadastre-se"">
                                        <strong>Quero ser Embaixador</strong>
                                        (Cadastro Embaixador)
                                    </button>
                                </a>
                                <a href=""/cadastro/causas"" target=""_blank"">
                                    <button class=""modal__btn--cadastre-se"">
                                        <strong>Sou uma Causa</strong>
                                        (Preciso de ajuda)
                    ");
                WriteLiteral(@"                </button>
                                </a>
                                <a href=""/home/whitelabel"">
                                    <button class=""modal__btn--cadastre-se"">
                                        <strong>
                                            Altrus na minha
                                            empresa
                                        </strong> (Cadastro White Label)
                                    </button>
                                </a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "0a624a6f65461b696089f42f7ce89c5a9e81971214993", async() => {
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
