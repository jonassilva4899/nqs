#pragma checksum "C:\nqs_2020\nqs\NQS\NQS\Altrus.HotSite\Views\Cadastro\dashboard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3dd8d98e0dbb623b2c1f08cc8a25d3e4a41b48f5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cadastro_dashboard), @"mvc.1.0.view", @"/Views/Cadastro/dashboard.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3dd8d98e0dbb623b2c1f08cc8a25d3e4a41b48f5", @"/Views/Cadastro/dashboard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"756b0c539fb7a53f1fc5543480fb3a3073c5a2e0", @"/_ViewImports.cshtml")]
    public class Views_Cadastro_dashboard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Leega.Dtos.Campanha>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "dashboard", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script");
                BeginWriteAttribute("src", " src=\"", 68, "\"", 110, 1);
#nullable restore
#line 5 "C:\nqs_2020\nqs\NQS\NQS\Altrus.HotSite\Views\Cadastro\dashboard.cshtml"
WriteAttributeValue("", 74, Url.Content("/assets/js/causes.js"), 74, 36, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("></script>\r\n    <script");
                BeginWriteAttribute("src", " src=\"", 134, "\"", 174, 1);
#nullable restore
#line 6 "C:\nqs_2020\nqs\NQS\NQS\Altrus.HotSite\Views\Cadastro\dashboard.cshtml"
WriteAttributeValue("", 140, Url.Content("/assets/js/main.js"), 140, 34, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("></script>\r\n");
            }
            );
            WriteLiteral(@"
<section id=""causes"" class=""home px-0 p-0""
         style=""background:url(/assets/img/home_bg.jpg);background-repeat: no-repeat;background-size: cover;background-position: center;"">

    <!-- causas__bg_home -->
    <div class=""container-fluid px-0 h-100 causas__bg_home"" style=""background-color: rgba(0, 80, 138, 0.8);"">
        <div class=""container py-5"">
            <div class=""row"">
                <div class=""col-lg-5 col-xl-4"">
                    <h2>
                        SEJA O SEU <strong>MELHOR</strong>.
                        SEJA <strong>ALTRUS</strong>!
                    </h2>
                </div>
                <div class=""col-lg-6 col-xl-5"">
                    <p>Apresentamos causas previamente certificadas para você ajudar com segurança.</p>
                </div>
            </div>
        </div>
        <!-- Causas Lista -->
        <div id=""causes-list"" class=""container py-5 py-xl-3 px-0"">
            <div id=""cause-item-container"" class=""owl-carousel"">
");
#nullable restore
#line 30 "C:\nqs_2020\nqs\NQS\NQS\Altrus.HotSite\Views\Cadastro\dashboard.cshtml"
                 foreach (var causa in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"causa__owl-item col\">\r\n                    <div");
            BeginWriteAttribute("id", " id=\"", 1350, "\"", 1370, 2);
            WriteAttributeValue("", 1355, "causa_", 1355, 6, true);
#nullable restore
#line 33 "C:\nqs_2020\nqs\NQS\NQS\Altrus.HotSite\Views\Cadastro\dashboard.cshtml"
WriteAttributeValue("", 1361, causa.id, 1361, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"cause-item-box\" data-campanhaid=\"");
#nullable restore
#line 33 "C:\nqs_2020\nqs\NQS\NQS\Altrus.HotSite\Views\Cadastro\dashboard.cshtml"
                                                                                 Write(causa.id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-nome=\"");
#nullable restore
#line 33 "C:\nqs_2020\nqs\NQS\NQS\Altrus.HotSite\Views\Cadastro\dashboard.cshtml"
                                                                                                       Write(causa.nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-beneficiario=\"");
#nullable restore
#line 33 "C:\nqs_2020\nqs\NQS\NQS\Altrus.HotSite\Views\Cadastro\dashboard.cshtml"
                                                                                                                                       Write(causa.beneficiario);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-valorminimo=\"");
#nullable restore
#line 33 "C:\nqs_2020\nqs\NQS\NQS\Altrus.HotSite\Views\Cadastro\dashboard.cshtml"
                                                                                                                                                                              Write(causa.valorminimo);

#line default
#line hidden
#nullable disable
            WriteLiteral(@""">
                        <div class=""cause-item-box-wrap"">
                            <div class=""cause-item-column h-100"">
                                <span class=""box__span"">nova</span>
                                <div class=""cause-item-img-box"">
");
#nullable restore
#line 38 "C:\nqs_2020\nqs\NQS\NQS\Altrus.HotSite\Views\Cadastro\dashboard.cshtml"
                                     if (causa.imagem != null)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <img class=\"cause-item-img img-fluid\"");
            BeginWriteAttribute("src", " src=\"", 1968, "\"", 2043, 2);
            WriteAttributeValue("", 1974, "https://altruswebassets.blob.core.windows.net/campanhas/", 1974, 56, true);
#nullable restore
#line 40 "C:\nqs_2020\nqs\NQS\NQS\Altrus.HotSite\Views\Cadastro\dashboard.cshtml"
WriteAttributeValue("", 2030, causa.imagem, 2030, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n");
#nullable restore
#line 41 "C:\nqs_2020\nqs\NQS\NQS\Altrus.HotSite\Views\Cadastro\dashboard.cshtml"
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                </div>\r\n                                <div class=\"cause-item-info\">\r\n                                    <h5 class=\"cause-item-name\">");
#nullable restore
#line 44 "C:\nqs_2020\nqs\NQS\NQS\Altrus.HotSite\Views\Cadastro\dashboard.cshtml"
                                                           Write(causa.nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                                    <p>\r\n                                        ");
#nullable restore
#line 46 "C:\nqs_2020\nqs\NQS\NQS\Altrus.HotSite\Views\Cadastro\dashboard.cshtml"
                                   Write(causa.nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </p>\r\n                                </div>\r\n                                <div class=\"cause-item-button\">\r\n                                    <a");
            BeginWriteAttribute("href", " href=\"", 2554, "\"", 2585, 2);
            WriteAttributeValue("", 2561, "/causa/detalhe/", 2561, 15, true);
#nullable restore
#line 50 "C:\nqs_2020\nqs\NQS\NQS\Altrus.HotSite\Views\Cadastro\dashboard.cshtml"
WriteAttributeValue("", 2576, causa.id, 2576, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" target=""_blank""><span class=""action__btn--view""></span></a>
                                    <a id=""link-modal-cart"" href=""#bd-cart-lg-causes"" data-toggle=""modal"" data-backdrop=""static"" data-keyboard=""false"" data-target=""#bd-cart-lg-causes""><span class=""action__btn--doar"">DOAR!</span></a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
");
#nullable restore
#line 57 "C:\nqs_2020\nqs\NQS\NQS\Altrus.HotSite\Views\Cadastro\dashboard.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            </div>
        </div>

        <!-- Action Buttons -->
        <div class=""container py-sm-3"">
            <div class=""row justify-content-center pb-5"">
                <div class=""col-sm-6 col-lg-3 mb-3 mb-sm-0"">
                    <input data-toggle=""modal"" data-backdrop=""static"" data-keyboard=""false"" data-target=""#bd-cart-lg-causes""
                           class=""causas__btn_action doar"" type=""button"" value=""QUERO DOAR!"" disabled>
                </div>
                <div class=""col-sm-6 col-lg-3 mb-3 mb-sm-0"">
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3dd8d98e0dbb623b2c1f08cc8a25d3e4a41b48f511839", async() => {
                WriteLiteral("<input type=\"button\" class=\"causas__btn_action active\" value=\"VER TODAS AS CAUSAS\" />");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                </div>
            </div>
        </div>
        <!-- End Causas Lista -->

    </div><!-- End causas__bg_home -->
</section><!-- End Causas Section -->
<main id=""main"">
    <section id=""busca-por-categoria"">
        <div class=""container"">
            <h5 class=""title mb-4"">
                Busque por categoria
            </h5>
        </div>
        <div id=""objetivos"" class=""container pl-lg-4"">
            <div class=""row"">


                <div class=""objetivo-item col mt-2"">
                    <!-- Default inline 2-->
                    <div class=""custom-control p-0 d-flex align-items-center custom-control p-0-inline m-0"">
                        <input type=""checkbox"" id=""objetivo_01"" name=""objetivo_01"" />
                        <label for=""objetivo_01"" class=""check-title""><img src=""/assets/img/objetivos/01.png""");
            BeginWriteAttribute("alt", " alt=\"", 4642, "\"", 4648, 0);
            EndWriteAttribute();
            WriteLiteral(@"></label>
                    </div>
                </div>

            </div>
        </div>
    </section>

    <!-- ======= Causas Section ======= -->
    <section id=""causes"" class=""dashboard"">
        <div class=""container py-3"">
            <div class=""row"">
                <div class=""col-sm-8 mb-3 mb-sm-0 text-center text-sm-left"">
                    <h5 class=""title"">
                        Doar nunca foi tão fácil e seguro
                    </h5>
                </div>
                <div class=""col-sm-4 text-center text-sm-right"">
                    <a href=""causas.html"">ver todas as causas</a>
                </div>
            </div>
        </div>
    </section><!-- End Causas Section -->
</main><!-- End #main -->
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Leega.Dtos.Campanha>> Html { get; private set; }
    }
}
#pragma warning restore 1591
