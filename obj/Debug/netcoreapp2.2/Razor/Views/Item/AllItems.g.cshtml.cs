#pragma checksum "/Users/angeloliwanag/Documents/CodingDojo/C#/Final-project/dogscover/Views/Item/AllItems.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ef696142bee9062cf4be21c764be8204387a0b21"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Item_AllItems), @"mvc.1.0.view", @"/Views/Item/AllItems.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Item/AllItems.cshtml", typeof(AspNetCore.Views_Item_AllItems))]
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
#line 1 "/Users/angeloliwanag/Documents/CodingDojo/C#/Final-project/dogscover/Views/_ViewImports.cshtml"
using DogScover;

#line default
#line hidden
#line 2 "/Users/angeloliwanag/Documents/CodingDojo/C#/Final-project/dogscover/Views/_ViewImports.cshtml"
using DogScover.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ef696142bee9062cf4be21c764be8204387a0b21", @"/Views/Item/AllItems.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6c867bbef3d322370f6e89fb0e7dff693e3e49bb", @"/Views/_ViewImports.cshtml")]
    public class Views_Item_AllItems : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Item>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ShowProject", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Item", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
            BeginContext(18, 267, true);
            WriteLiteral(@"
<style>
  h3 {
    text-align: center;
  }
  
  .text-warning {
    display: inline;
  }

  
</style>
<div class=""container"">
  <div class=""ViewSize mt-5"">
    <h3>Support a Project!</h3><br>
    
    <div class=""inline-block d-flex flex-wrap text-center products"">
");
            EndContext();
#line 19 "/Users/angeloliwanag/Documents/CodingDojo/C#/Final-project/dogscover/Views/Item/AllItems.cshtml"
     foreach(var item in Model)
    {

#line default
#line hidden
            BeginContext(323, 148, true);
            WriteLiteral("      <div class=\"shadow-lg bg-white rounded card mb-3 inline-block mr-4 ml-4\" style=\"max-width: 20rem;\">\n        <div class=\"card-body\">\n          ");
            EndContext();
            BeginContext(471, 282, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ef696142bee9062cf4be21c764be8204387a0b214486", async() => {
                BeginContext(549, 78, true);
                WriteLiteral("\n            <h4 style=\"color:#02b875; text-align:center;\" class=\"card-title\">");
                EndContext();
                BeginContext(628, 9, false);
#line 24 "/Users/angeloliwanag/Documents/CodingDojo/C#/Final-project/dogscover/Views/Item/AllItems.cshtml"
                                                                        Write(item.Name);

#line default
#line hidden
                EndContext();
                BeginContext(637, 22, true);
                WriteLiteral("</h4>\n            <img");
                EndContext();
                BeginWriteAttribute("src", " src=\"", 659, "\"", 679, 1);
#line 25 "/Users/angeloliwanag/Documents/CodingDojo/C#/Final-project/dogscover/Views/Item/AllItems.cshtml"
WriteAttributeValue("", 665, item.ImageURL, 665, 14, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(680, 69, true);
                WriteLiteral(" alt=\"image\" style=\"max-width: 18rem; max-height: 18rem;\">\n          ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 23 "/Users/angeloliwanag/Documents/CodingDojo/C#/Final-project/dogscover/Views/Item/AllItems.cshtml"
                                                              WriteLiteral(item.ItemId);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(753, 73, true);
            WriteLiteral("\n          <br>\n          <br>\n          <p class=\"text-warning\">Made by ");
            EndContext();
            BeginContext(827, 10, false);
#line 29 "/Users/angeloliwanag/Documents/CodingDojo/C#/Final-project/dogscover/Views/Item/AllItems.cshtml"
                                     Write(item.Brand);

#line default
#line hidden
            EndContext();
            BeginContext(837, 64, true);
            WriteLiteral("</p><br>\n          <p class=\"text-secondary\">Number of Barkers: ");
            EndContext();
            BeginContext(902, 18, false);
#line 30 "/Users/angeloliwanag/Documents/CodingDojo/C#/Final-project/dogscover/Views/Item/AllItems.cshtml"
                                                  Write(item.Funders.Count);

#line default
#line hidden
            EndContext();
            BeginContext(920, 33, true);
            WriteLiteral("</p>\n        </div>\n      </div>\n");
            EndContext();
#line 33 "/Users/angeloliwanag/Documents/CodingDojo/C#/Final-project/dogscover/Views/Item/AllItems.cshtml"
    }

#line default
#line hidden
            BeginContext(959, 27, true);
            WriteLiteral("    </div>\n  </div>\n\n</div>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Item>> Html { get; private set; }
    }
}
#pragma warning restore 1591
