#pragma checksum "C:\Users\fukgo\source\repos\Empatik\Empatik\Views\Home\DateQuery.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f746d1e120e0cbfd2250b55aee9686796ddeadee"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_DateQuery), @"mvc.1.0.view", @"/Views/Home/DateQuery.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f746d1e120e0cbfd2250b55aee9686796ddeadee", @"/Views/Home/DateQuery.cshtml")]
    public class Views_Home_DateQuery : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Empatik.Controllers.HomeController.DateModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("    <h1> Günlük Sayfa Görüntülenme Sayıları</h1>\r\n    <table>\r\n        <tr>\r\n            <th> Tarih </th>\r\n            <th> Ziyaretçi Sayısı </th>\r\n        </tr>\r\n\r\n");
#nullable restore
#line 10 "C:\Users\fukgo\source\repos\Empatik\Empatik\Views\Home\DateQuery.cshtml"
         foreach (var x in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 13 "C:\Users\fukgo\source\repos\Empatik\Empatik\Views\Home\DateQuery.cshtml"
               Write(x.Date);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                <td>");
#nullable restore
#line 14 "C:\Users\fukgo\source\repos\Empatik\Empatik\Views\Home\DateQuery.cshtml"
               Write(x.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n            </tr>\r\n");
#nullable restore
#line 17 "C:\Users\fukgo\source\repos\Empatik\Empatik\Views\Home\DateQuery.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Empatik.Controllers.HomeController.DateModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591