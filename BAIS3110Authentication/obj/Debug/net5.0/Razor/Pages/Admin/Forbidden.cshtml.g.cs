#pragma checksum "C:\Users\Eron\source\repos\BAIS3110Authentication\Pages\Admin\Forbidden.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4291a5803d2f123780e0db095f59b50f789a0ad1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(BAIS3110Authentication.Pages.Admin.Pages_Admin_Forbidden), @"mvc.1.0.razor-page", @"/Pages/Admin/Forbidden.cshtml")]
namespace BAIS3110Authentication.Pages.Admin
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
#line 1 "C:\Users\Eron\source\repos\BAIS3110Authentication\Pages\_ViewImports.cshtml"
using BAIS3110Authentication;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4291a5803d2f123780e0db095f59b50f789a0ad1", @"/Pages/Admin/Forbidden.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9d444ed6b9032c9d9245e41c9c9b1acd74056fa5", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Admin_Forbidden : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<h1>Forbidden</h1>\r\nYou are not allowed to Access this resource\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BAIS3110Authentication.Pages.Admin.ForbiddenModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<BAIS3110Authentication.Pages.Admin.ForbiddenModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<BAIS3110Authentication.Pages.Admin.ForbiddenModel>)PageContext?.ViewData;
        public BAIS3110Authentication.Pages.Admin.ForbiddenModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
