#pragma checksum "C:\leega\NQS\NQS\Altrus.HotSite\Views\Account\ConfirmEmail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b4161b9b049382dc4e0ac509878489a9693b7d2e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_ConfirmEmail), @"mvc.1.0.view", @"/Views/Account/ConfirmEmail.cshtml")]
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
#line 1 "C:\leega\NQS\NQS\Altrus.HotSite\_ViewImports.cshtml"
using Leega.UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\leega\NQS\NQS\Altrus.HotSite\_ViewImports.cshtml"
using Leega.UI.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b4161b9b049382dc4e0ac509878489a9693b7d2e", @"/Views/Account/ConfirmEmail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"756b0c539fb7a53f1fc5543480fb3a3073c5a2e0", @"/_ViewImports.cshtml")]
    public class Views_Account_ConfirmEmail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\leega\NQS\NQS\Altrus.HotSite\Views\Account\ConfirmEmail.cshtml"
   
    Layout = "";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""container-fluid"">
    <div class=""row h-100"" data-ride=""carousel"">
        <div id=""login-bg-left""
             class=""col-lg-6 col-xl-7 marcas d-lg-flex align-items-center  d-none bg-color-1 text-white h-100"">
            <div class=""row justify-content-center"">
                <div class=""col-10 col-xl-8"">
                    <h1 class=""mb-4"">
                        SEJA O SEU <strong>MELHOR</strong>.<br>
                        SEJA <strong>ALTRUS</strong>!
                    </h1>
                    <p>
                        Apresentamos causas previamente
                        certificadas para você ajudar com
                        segurança
                    </p>
                </div>
            </div>
        </div>
        <div class=""col-lg-6 col-xl-5 pt-lg-3 pt-5 d-flex align-items-center panel text-center white"">
            <div class=""row justify-content-center"">
                <div class=""col-12 logo"">
                    <img src=""assets/img/logoti");
            WriteLiteral("po-altrus.png\"");
            BeginWriteAttribute("alt", " alt=\"", 1064, "\"", 1070, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                </div>
                <div class=""col-sm-7 col-10 text-left mt-lg-3 mt-5"">
                    <div class=""col-10 col-xl-8"">
                        <h1 class=""mb-4"">
                            SEJA BEM VINDO A <strong>ALTRUS!</strong>.<br>
                        </h1>
                        <p>
                            Seu email foi confirmado com sucesso.
                        </p>
                    </div>
                </div>
                <div class=""col-12"">
                    <p>Clique <a");
            BeginWriteAttribute("href", " href=\'", 1617, "\'", 1644, 1);
#nullable restore
#line 38 "C:\leega\NQS\NQS\Altrus.HotSite\Views\Account\ConfirmEmail.cshtml"
WriteAttributeValue("", 1624, Url.Action("login"), 1624, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">aqui</a> para fazer o seu login.</p>
                </div>

                <div class=""col-12"">
                    <div class=""credits pt-xl-5 pb-xl-3 pt-lg-3 pb-lg-3 pb-5 pt-5"">
                        <a href=""https://www.leega.com.br/"" target=""_blank""><span class=""leega_gray""></span></a><a href=""https://estudio86.com.br/"" target=""_blank""><span class=""e86_gray""></span></a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
