#pragma checksum "C:\Users\andre.corte\source\repos\NQS\NQS\NQS.HotSite\Views\Home\dashboard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "13ebc4bf7d400c573f0977472042b7fead6f6f3c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_dashboard), @"mvc.1.0.view", @"/Views/Home/dashboard.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"13ebc4bf7d400c573f0977472042b7fead6f6f3c", @"/Views/Home/dashboard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"abba63441b77c597d03af1c584c42ccbe4bd38fa", @"/_ViewImports.cshtml")]
    public class Views_Home_dashboard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Leega.Dtos.Campanha>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("link-modal-cart"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "basket", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-keyboard", new global::Microsoft.AspNetCore.Html.HtmlString("false"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "causas", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 5 "C:\Users\andre.corte\source\repos\NQS\NQS\NQS.HotSite\Views\Home\dashboard.cshtml"
WriteAttributeValue("", 74, Url.Content("/assets/js/causes.js"), 74, 36, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("></script>\r\n");
            }
            );
            WriteLiteral(@"
<div id=""causes"" style=""height: fit-content;"">
    <div style=""background:url(/assets/img/home_bg.jpg);background-repeat: no-repeat;background-size: cover;background-position: center;"">

        <div class=""container-fluid px-0 h-100 opaque80"">
            <div class=""container py-5"">
                <div class=""row"">
                    <div class=""col-lg-5 col-xl-4"">
                        <h2>
                            SEJA O SEU <strong>MELHOR</strong>.
                            SEJA <strong>ALTRUS</strong>!
                        </h2>
                    </div>
                    <div class=""col-lg-6 col-xl-5"">
                        <p class=""text-white"">Apresentamos causas certificadas para você ajudar com segurança. Conheça campanhas inspiradoras e ajude em poucos cliques.</p>
                    </div>
                </div>
            </div>

            <div id=""causes-list"" class=""container py-5 py-xl-3 px-0"">
                <div id=""cause-item-container"" class=""owl");
            WriteLiteral("-carousel\">\r\n");
#nullable restore
#line 28 "C:\Users\andre.corte\source\repos\NQS\NQS\NQS.HotSite\Views\Home\dashboard.cshtml"
                     foreach (var causa in Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"causa__owl-item col\">\r\n                            <div");
            BeginWriteAttribute("id", " id=\"", 1328, "\"", 1348, 2);
            WriteAttributeValue("", 1333, "causa_", 1333, 6, true);
#nullable restore
#line 31 "C:\Users\andre.corte\source\repos\NQS\NQS\NQS.HotSite\Views\Home\dashboard.cshtml"
WriteAttributeValue("", 1339, causa.id, 1339, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"cause-item-box\" data-campanhaid=\"");
#nullable restore
#line 31 "C:\Users\andre.corte\source\repos\NQS\NQS\NQS.HotSite\Views\Home\dashboard.cshtml"
                                                                                         Write(causa.id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-nome=\"");
#nullable restore
#line 31 "C:\Users\andre.corte\source\repos\NQS\NQS\NQS.HotSite\Views\Home\dashboard.cshtml"
                                                                                                               Write(causa.nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-beneficiario=\"");
#nullable restore
#line 31 "C:\Users\andre.corte\source\repos\NQS\NQS\NQS.HotSite\Views\Home\dashboard.cshtml"
                                                                                                                                               Write(causa.beneficiario);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-valorminimo=\"");
#nullable restore
#line 31 "C:\Users\andre.corte\source\repos\NQS\NQS\NQS.HotSite\Views\Home\dashboard.cshtml"
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
#line 36 "C:\Users\andre.corte\source\repos\NQS\NQS\NQS.HotSite\Views\Home\dashboard.cshtml"
                                             if (causa.imagem != null)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <img class=\"cause-item-img img-fluid\"");
            BeginWriteAttribute("src", " src=\"", 2002, "\"", 2077, 2);
            WriteAttributeValue("", 2008, "https://altruswebassets.blob.core.windows.net/campanhas/", 2008, 56, true);
#nullable restore
#line 38 "C:\Users\andre.corte\source\repos\NQS\NQS\NQS.HotSite\Views\Home\dashboard.cshtml"
WriteAttributeValue("", 2064, causa.imagem, 2064, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n");
#nullable restore
#line 39 "C:\Users\andre.corte\source\repos\NQS\NQS\NQS.HotSite\Views\Home\dashboard.cshtml"
                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        </div>\r\n                                        <div class=\"cause-item-info\">\r\n                                            <h5 class=\"cause-item-name\">");
#nullable restore
#line 42 "C:\Users\andre.corte\source\repos\NQS\NQS\NQS.HotSite\Views\Home\dashboard.cshtml"
                                                                   Write(causa.nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                                        </div>\r\n                                        <div class=\"cause-item-button\">\r\n                                            <a");
            BeginWriteAttribute("href", " href=\"", 2504, "\"", 2528, 2);
            WriteAttributeValue("", 2511, "/causa/", 2511, 7, true);
#nullable restore
#line 45 "C:\Users\andre.corte\source\repos\NQS\NQS\NQS.HotSite\Views\Home\dashboard.cshtml"
WriteAttributeValue("", 2518, causa.url, 2518, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" target=\"_blank\"><span class=\"action__btn--view\"></span></a>\r\n                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "13ebc4bf7d400c573f0977472042b7fead6f6f3c11597", async() => {
                WriteLiteral("<span class=\"action__btn--doar\">DOAR!</span>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                        </div>\r\n                                    </div>\r\n                                </div>\r\n                            </div>\r\n                        </div>\r\n");
#nullable restore
#line 52 "C:\Users\andre.corte\source\repos\NQS\NQS\NQS.HotSite\Views\Home\dashboard.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n            </div>\r\n\r\n            <div class=\"container py-sm-3\">\r\n                <div class=\"row justify-content-center pb-5\">\r\n                    <div class=\"col-sm-6 col-lg-3 mb-3 mb-sm-0\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "13ebc4bf7d400c573f0977472042b7fead6f6f3c13854", async() => {
                WriteLiteral("<input id=\"btnDoar\" data-keyboard=\"false\" class=\"btn btn-whiteontranparent\" type=\"button\" value=\"QUERO DOAR!\">");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </div>\r\n                    <div class=\"col-sm-6 col-lg-3 mb-3 mb-sm-0\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "13ebc4bf7d400c573f0977472042b7fead6f6f3c15454", async() => {
                WriteLiteral("<input type=\"button\" class=\"btn btn-whiteontranparent\" value=\"VER TODAS AS CAUSAS\" />");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n<script>\r\n    buildCauseCarousel();\r\n</script>\r\n");
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
