#pragma checksum "C:\nsq_08122020\nqs\NQS\NQS\Altrus.HotSite\Views\Cadastro\pacienteLista.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9a5a82a57e5600474856161b81f4a02095b21f44"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9a5a82a57e5600474856161b81f4a02095b21f44", @"/Views/Cadastro/pacienteLista.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"756b0c539fb7a53f1fc5543480fb3a3073c5a2e0", @"/_ViewImports.cshtml")]
    public class Views_Cadastro_pacienteLista : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Leega.Dtos.ListaPacientes>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "cadastro", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "pacienteObter", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n\r\n<br />\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9a5a82a57e5600474856161b81f4a02095b21f444337", async() => {
                WriteLiteral(@"
    
    <title>NQS</title>
    <style>
        .pagination {
            display: flex;
            justify-content: center;
        }

            .pagination a {
                color: black;
                float: left;
                padding: 8px 16px;
                text-decoration: none;                                
            }
                .pagination a.active {
                    background-color: #4CAF50;
                    color: white;
                }
    </style>

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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9a5a82a57e5600474856161b81f4a02095b21f445822", async() => {
                WriteLiteral(@"    
    <div class=""row"">
        <div class=""col-md-12"">
            <div class=""panel panel-primary list-panel"" id=""list-panel"">
                <div class=""panel-heading list-panel-heading"">
                    <h1 class=""panel-title list-panel-title"">Assets</h1>
                </div>

                <div class=""panel-body"">
                    <div class=""col-sm-12 py-3"">
                        <h4 class=""title"">Pacientes</h4>
                        <div class=""row justify-content-sm-between"">
                        </div>
                    </div>

                    <table id=""assets-data-table"" class=""table table-striped table-bordered"" style=""width:95%"" align=""center"">
                        <thead>
                            <tr>
                                <th>Nome Completo</th>
                                <th>Documento Identificador</th>
                                <th>Data Nascimento</th>
                                <th>Celular</th>
                 ");
                WriteLiteral("           </tr>\r\n                        </thead>\r\n                        <tbody>\r\n");
#nullable restore
#line 55 "C:\nsq_08122020\nqs\NQS\NQS\Altrus.HotSite\Views\Cadastro\pacienteLista.cshtml"
                             foreach (Leega.Dtos.Paciente item in Model.Paciente)
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                <tr>\r\n                                    <td><a data-value=\"");
#nullable restore
#line 58 "C:\nsq_08122020\nqs\NQS\NQS\Altrus.HotSite\Views\Cadastro\pacienteLista.cshtml"
                                                  Write(item.Id);

#line default
#line hidden
#nullable disable
                WriteLiteral("\" id=\"actionId\"");
                BeginWriteAttribute("onclick", " onclick=\"", 1997, "\"", 2026, 3);
                WriteAttributeValue("", 2007, "Clickfn(\'", 2007, 9, true);
#nullable restore
#line 58 "C:\nsq_08122020\nqs\NQS\NQS\Altrus.HotSite\Views\Cadastro\pacienteLista.cshtml"
WriteAttributeValue("", 2016, item.Id, 2016, 8, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 2024, "\')", 2024, 2, true);
                EndWriteAttribute();
                WriteLiteral(">");
#nullable restore
#line 58 "C:\nsq_08122020\nqs\NQS\NQS\Altrus.HotSite\Views\Cadastro\pacienteLista.cshtml"
                                                                                                        Write(item.NomeCompleto);

#line default
#line hidden
#nullable disable
                WriteLiteral("</a></td>\r\n                                    <td>");
#nullable restore
#line 59 "C:\nsq_08122020\nqs\NQS\NQS\Altrus.HotSite\Views\Cadastro\pacienteLista.cshtml"
                                   Write(item.DocumentoIdentificacao);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 60 "C:\nsq_08122020\nqs\NQS\NQS\Altrus.HotSite\Views\Cadastro\pacienteLista.cshtml"
                                   Write(item.DataNascimento.ToString().Substring(0,10));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 61 "C:\nsq_08122020\nqs\NQS\NQS\Altrus.HotSite\Views\Cadastro\pacienteLista.cshtml"
                                   Write(item.Celular);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                </tr>\r\n");
#nullable restore
#line 63 "C:\nsq_08122020\nqs\NQS\NQS\Altrus.HotSite\Views\Cadastro\pacienteLista.cshtml"
                            }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                        </tbody>
                    </table>
                    <br />
                    <div class=""panel-body"">

                    </div>
                    <input type=""hidden"" id=""hfCurrentPageIndex"" name=""currentPageIndex"" />
                </div>
            </div>
        </div>
    </div>
    <div class=""pagination"" >
        
");
#nullable restore
#line 77 "C:\nsq_08122020\nqs\NQS\NQS\Altrus.HotSite\Views\Cadastro\pacienteLista.cshtml"
         for (int i = 1; i <= Model.PageCount; i++)
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 79 "C:\nsq_08122020\nqs\NQS\NQS\Altrus.HotSite\Views\Cadastro\pacienteLista.cshtml"
             if (i != Model.CurrentPageIndex)
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <a");
                BeginWriteAttribute("href", " href=\"", 2874, "\"", 2907, 3);
                WriteAttributeValue("", 2881, "javascript:PagerClick(", 2881, 22, true);
#nullable restore
#line 81 "C:\nsq_08122020\nqs\NQS\NQS\Altrus.HotSite\Views\Cadastro\pacienteLista.cshtml"
WriteAttributeValue("", 2903, i, 2903, 2, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 2905, ");", 2905, 2, true);
                EndWriteAttribute();
                WriteLiteral(">");
#nullable restore
#line 81 "C:\nsq_08122020\nqs\NQS\NQS\Altrus.HotSite\Views\Cadastro\pacienteLista.cshtml"
                                                Write(i);

#line default
#line hidden
#nullable disable
                WriteLiteral("</a>\r\n");
#nullable restore
#line 82 "C:\nsq_08122020\nqs\NQS\NQS\Altrus.HotSite\Views\Cadastro\pacienteLista.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <a class=\"active\">");
#nullable restore
#line 85 "C:\nsq_08122020\nqs\NQS\NQS\Altrus.HotSite\Views\Cadastro\pacienteLista.cshtml"
                             Write(i);

#line default
#line hidden
#nullable disable
                WriteLiteral("</a>                \r\n");
#nullable restore
#line 86 "C:\nsq_08122020\nqs\NQS\NQS\Altrus.HotSite\Views\Cadastro\pacienteLista.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 86 "C:\nsq_08122020\nqs\NQS\NQS\Altrus.HotSite\Views\Cadastro\pacienteLista.cshtml"
             
        }

#line default
#line hidden
#nullable disable
                WriteLiteral("    </div>\r\n    <br />\r\n\r\n\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n<script>\r\n        function Clickfn(id) {\r\n\r\n        var url = \'");
#nullable restore
#line 96 "C:\nsq_08122020\nqs\NQS\NQS\Altrus.HotSite\Views\Cadastro\pacienteLista.cshtml"
              Write(Url.Action("PacienteEditar", "Cadastro", new {id = -1}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\'; //Generate URL string using razor\r\n        window.location.href = url.replace(\'-1\', id); //replace ID value\r\n    }\r\n\r\n    function PagerClick(index) {\r\n\r\n        var url = \'");
#nullable restore
#line 102 "C:\nsq_08122020\nqs\NQS\NQS\Altrus.HotSite\Views\Cadastro\pacienteLista.cshtml"
              Write(Url.Action("PacienteLista", "Cadastro", new { currentPage = -1}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\'; //Generate URL string using razor\r\n        window.location.href = url.replace(\'-1\', index); //replace ID value\r\n    }\r\n</script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Leega.Dtos.ListaPacientes> Html { get; private set; }
    }
}
#pragma warning restore 1591