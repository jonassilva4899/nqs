#pragma checksum "C:\nqs\NQS\NQS\Altrus.HotSite\Views\Shared\_LoginLayout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d33f591d2bdebabdb542f6e26911260455a911f9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__LoginLayout), @"mvc.1.0.view", @"/Views/Shared/_LoginLayout.cshtml")]
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
#line 1 "C:\nqs\NQS\NQS\Altrus.HotSite\_ViewImports.cshtml"
using Leega.UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\nqs\NQS\NQS\Altrus.HotSite\_ViewImports.cshtml"
using Leega.UI.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d33f591d2bdebabdb542f6e26911260455a911f9", @"/Views/Shared/_LoginLayout.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"756b0c539fb7a53f1fc5543480fb3a3073c5a2e0", @"/_ViewImports.cshtml")]
    public class Views_Shared__LoginLayout : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d33f591d2bdebabdb542f6e26911260455a911f93166", async() => {
                WriteLiteral("\r\n    <meta charset=\"utf-8\">\r\n    <meta content=\"width=device-width, initial-scale=1.0\" name=\"viewport\">\r\n\r\n    <title>NQS</title>\r\n    <meta");
                BeginWriteAttribute("content", " content=\"", 155, "\"", 165, 0);
                EndWriteAttribute();
                WriteLiteral(@"
          name=""NQS"">
    <meta content=""NQS"" name=""keywords"">

    <!-- Favicons -->
    <link href=""assets/img/apple-touch-icon.png"" rel=""apple-touch-icon"">

    <!-- Vendor CSS Files -->
    <link href=""/assets/vendor/bootstrap/css/bootstrap.min.css"" rel=""stylesheet"">
    <link href=""/assets/vendor/icofont/icofont.min.css"" rel=""stylesheet"">
    <link href=""/assets/vendor/boxicons/css/boxicons.min.css"" rel=""stylesheet"">
    <link href=""/assets/vendor/venobox/venobox.css"" rel=""stylesheet"">
    <link href=""/assets/vendor/owl.carousel/assets/owl.carousel.min.css"" rel=""stylesheet"">
    <link href=""/assets/vendor/aos/aos.css"" rel=""stylesheet"">

    <!-- Template Main CSS File -->
    <link href=""/assets/css/main.css"" rel=""stylesheet"">
    <link");
                BeginWriteAttribute("href", " href=\"", 935, "\"", 972, 1);
#nullable restore
#line 24 "C:\nqs\NQS\NQS\Altrus.HotSite\Views\Shared\_LoginLayout.cshtml"
WriteAttributeValue("", 942, Url.Action("Style","Account"), 942, 30, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" rel=\"stylesheet\" type=\"text/css\" />\r\n");
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d33f591d2bdebabdb542f6e26911260455a911f95669", async() => {
                WriteLiteral("\r\n    ");
#nullable restore
#line 28 "C:\nqs\NQS\NQS\Altrus.HotSite\Views\Shared\_LoginLayout.cshtml"
Write(RenderBody());

#line default
#line hidden
#nullable disable
                WriteLiteral(@";

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
    <script src=""/assets/vendor/aos/aos.js""></script>
    <script s");
                WriteLiteral("rc=\"/assets/js/main.js\"></script>\r\n\r\n    ");
#nullable restore
#line 46 "C:\nqs\NQS\NQS\Altrus.HotSite\Views\Shared\_LoginLayout.cshtml"
Write(RenderSection("Scripts", required: false));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
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