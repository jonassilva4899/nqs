#pragma checksum "C:\nqs_2020\nqs\NQS\NQS\Altrus.HotSite\Views\Causa\detalhe.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "816f778ce830ea34c7052e0057f73c101bbdf504"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Causa_detalhe), @"mvc.1.0.view", @"/Views/Causa/detalhe.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"816f778ce830ea34c7052e0057f73c101bbdf504", @"/Views/Causa/detalhe.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"756b0c539fb7a53f1fc5543480fb3a3073c5a2e0", @"/_ViewImports.cshtml")]
    public class Views_Causa_detalhe : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Leega.Dtos.Campanha>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<!-- Margin top -->
<div id=""mt-top-header""></div>
<!-- End Margin top -->
<main id=""main"">

    <!-- ======= Single ======= -->
    <section id=""single"">
        <div class=""container"">
            <div class=""row"">
                <div class=""col-lg-8 pr-lg-4"">
                    <h1>
                        ");
#nullable restore
#line 13 "C:\nqs_2020\nqs\NQS\NQS\Altrus.HotSite\Views\Causa\detalhe.cshtml"
                   Write(Model.nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </h1>\r\n                </div>\r\n                <div class=\"col-lg-12 mt-4 mb-5\">\r\n                    <img class=\"img-fluid w-100 rounded\"");
            BeginWriteAttribute("src", " src=\"", 523, "\"", 598, 2);
            WriteAttributeValue("", 529, "https://altruswebassets.blob.core.windows.net/campanhas/", 529, 56, true);
#nullable restore
#line 17 "C:\nqs_2020\nqs\NQS\NQS\Altrus.HotSite\Views\Causa\detalhe.cshtml"
WriteAttributeValue("", 585, Model.imagem, 585, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 599, "\"", 605, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                </div>
            </div>
            <div class=""row"">
                <div class=""col-lg-8"">
                    <div class=""row"">
                        <div class=""col-lg-12 old-12 text-inner"">
                            <h5 class=""mb-4"">Descrição da Causa</h5>
                            <p>");
#nullable restore
#line 25 "C:\nqs_2020\nqs\NQS\NQS\Altrus.HotSite\Views\Causa\detalhe.cshtml"
                          Write(Model.descricao);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                        </div>
                        <div class=""col-lg-12 old-12"">
                            <div class=""causes__box__avisos p-4 border rounded"">
                                <h5>AÇÕES EM COMBATE AOS EFEITOS DO COVID 19</h5>
                                <p class=""m-0"">");
#nullable restore
#line 30 "C:\nqs_2020\nqs\NQS\NQS\Altrus.HotSite\Views\Causa\detalhe.cshtml"
                                          Write(Model.covid);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            </div>\r\n                        </div>\r\n                        <div class=\"col-lg-12 old-12 my-5\">\r\n                            <a class=\"venobox\" data-vbtype=\"video\" data-autoplay=\"true\"");
            BeginWriteAttribute("href", " href=\"", 1487, "\"", 1510, 1);
#nullable restore
#line 34 "C:\nqs_2020\nqs\NQS\NQS\Altrus.HotSite\Views\Causa\detalhe.cshtml"
WriteAttributeValue("", 1494, Model.linkvideo, 1494, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                <img class=\"w-100 img-fluid rounded background-color3\" style=\"height:390px;\"");
            BeginWriteAttribute("src", " src=\"", 1622, "\"", 1644, 1);
#nullable restore
#line 35 "C:\nqs_2020\nqs\NQS\NQS\Altrus.HotSite\Views\Causa\detalhe.cshtml"
WriteAttributeValue("", 1628, Model.linkvideo, 1628, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 1645, "\"", 1651, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                            </a>
                        </div>
                    </div>
                </div>
                <div class=""col-lg-4"">
                    <div id=""box-lateral-column"" class=""border rounded p-4"">
                        <h5>Quanto deseja doar?</h5>
                        <div class=""box-donate-price mt-3 mb-4"">
                            Doações à partir de R$30,00
                        </div>
                        <button class=""btn btn-whiteonblue w-100"">QUERO DOAR!</button>
                    </div>
                    <div id=""box-lateral-column"" class=""border rounded p-4 mt-box-lateral"">
                        <h5 class=""mb-3"">QRCODE da causa</h5>
                        <div id=""qrcode"">
                            <img");
            BeginWriteAttribute("src", " src=\"", 2447, "\"", 2536, 1);
#nullable restore
#line 51 "C:\nqs_2020\nqs\NQS\NQS\Altrus.HotSite\Views\Causa\detalhe.cshtml"
WriteAttributeValue("", 2453, String.Format("data:image/png;base64,{0}", Convert.ToBase64String(ViewBag.QRCode)), 2453, 83, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" style=""height: 250px;width: 250px;"" />
                        </div>
                    </div>
                    <div id=""box-lateral-column"" class=""border rounded p-4 mt-box-lateral"">
                        <h5 class=""mb-3"">Beneficiário</h5>
                        <div class=""box-beneficio my-2"" style=""overflow-wrap: break-word;"">
                            Razão Social: <strong>");
#nullable restore
#line 57 "C:\nqs_2020\nqs\NQS\NQS\Altrus.HotSite\Views\Causa\detalhe.cshtml"
                                             Write(Model.ong.razaosocial);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong>\r\n                        </div>\r\n                        <div class=\"box-beneficio my-2\">\r\n                            CNPJ: <strong>");
#nullable restore
#line 60 "C:\nqs_2020\nqs\NQS\NQS\Altrus.HotSite\Views\Causa\detalhe.cshtml"
                                     Write(Model.ong.cnpj);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong>\r\n                        </div>\r\n                        <div class=\"box-beneficio my-2\" style=\"overflow-wrap: break-word;\">\r\n                            Site: <strong>");
#nullable restore
#line 63 "C:\nqs_2020\nqs\NQS\NQS\Altrus.HotSite\Views\Causa\detalhe.cshtml"
                                     Write(Model.ong.site);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong>\r\n                        </div>\r\n                        <div class=\"box-beneficio my-2\" style=\"overflow-wrap: break-word;\">\r\n                            Contato: <strong>");
#nullable restore
#line 66 "C:\nqs_2020\nqs\NQS\NQS\Altrus.HotSite\Views\Causa\detalhe.cshtml"
                                        Write(Model.ong.email);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</strong>
                        </div>
                    </div>
                </div>
            </div>
            <div class=""row"">
                <div class=""col-lg-8"" id=""gallery"">
                    <h5>Galeria de Fotos</h5>
                    <div class=""row py-2 border rounded"">
");
#nullable restore
#line 75 "C:\nqs_2020\nqs\NQS\NQS\Altrus.HotSite\Views\Causa\detalhe.cshtml"
                         for (int pic = 0; pic < 6; pic++)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            <div class=""col-4 my-2"">
                                <a class=""venobox vbox-item"" data-gall=""myGallery"" href=""#"">
                                    <img class=""img-fluid rounded background-color3"" style=""width:223px;height:156px;"">
                                </a>
                            </div>
");
#nullable restore
#line 82 "C:\nqs_2020\nqs\NQS\NQS\Altrus.HotSite\Views\Causa\detalhe.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    </div>
                </div>
                <div class=""col-lg-4"">
                    <div id=""box-lateral-column"" class=""border rounded p-4"">
                    </div>
                </div>
            </div>
        </div>
    </section>

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Leega.Dtos.Campanha> Html { get; private set; }
    }
}
#pragma warning restore 1591
