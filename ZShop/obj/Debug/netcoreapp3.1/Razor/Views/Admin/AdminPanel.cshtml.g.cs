#pragma checksum "C:\Users\Zhdan\Source\Repos\ZShop\ZShop\Views\Admin\AdminPanel.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "88f730b1c34acd828f993a46ecd88fc0880f2343"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_AdminPanel), @"mvc.1.0.view", @"/Views/Admin/AdminPanel.cshtml")]
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
#line 1 "C:\Users\Zhdan\Source\Repos\ZShop\ZShop\Views\_ViewImports.cshtml"
using ZShop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Zhdan\Source\Repos\ZShop\ZShop\Views\_ViewImports.cshtml"
using ZShop.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"88f730b1c34acd828f993a46ecd88fc0880f2343", @"/Views/Admin/AdminPanel.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dddf48b01e87c2b8187c25bf68804d6cfc85afcb", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_AdminPanel : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\Zhdan\Source\Repos\ZShop\ZShop\Views\Admin\AdminPanel.cshtml"
  
    ViewData["Title"] = "AdminPanel";

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "88f730b1c34acd828f993a46ecd88fc0880f23433240", async() => {
                WriteLiteral("\r\n    <style>\r\n        body {\r\n            padding-top: 20px;\r\n        }\r\n\r\n        .panel-body .btn:not(.btn-block) {\r\n            width: 240px;\r\n            margin-bottom: 20px;\r\n            padding-right: 220px;\r\n        }\r\n    </style>\r\n");
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
            WriteLiteral(@"


<link href=""//netdna.bootstrapcdn.com/bootstrap/3.0.0/css/bootstrap.min.css"" rel=""stylesheet"" id=""bootstrap-css"">
<script src=""//netdna.bootstrapcdn.com/bootstrap/3.0.0/js/bootstrap.min.js""></script>
<script src=""//code.jquery.com/jquery-1.11.1.min.js""></script>
<!------ Include the above in your HEAD tag ---------->

<div class=""container"" style=""margin-left:250px;"">
    <div class=""row"">
        <div class=""col-md-6"">
            <div class=""panel panel-primary"">
                <div class=""panel-heading"">
                    <h3 class=""panel-title"">
                        <span class=""glyphicon glyphicon-bookmark""></span> <h1>AdminPanel</h1>
                    </h3>
                </div>
                <div class=""panel-body"" style=""height : 450px; width : 500px; padding-left:40px;"">
                    <div class=""row"">
                        <div class=""col-xs-10 col-md-6"">
                            <a href=""#"" class=""btn btn-danger btn-lg"" role=""button""><span class=""glyphic");
            WriteLiteral(@"on glyphicon-list-alt""></span> <br />Добавить товар</a>
                            <a href=""#"" class=""btn btn-warning btn-lg"" role=""button""><span class=""glyphicon glyphicon-bookmark""></span> <br />Скоро будет</a>
                            <a href=""#"" class=""btn btn-primary btn-lg"" role=""button""><span class=""glyphicon glyphicon-signal""></span> <br />Скоро будет</a>
                            <a href=""#"" class=""btn btn-primary btn-lg"" role=""button""><span class=""glyphicon glyphicon-comment""></span> <br />Скоро будет</a>
                        </div>
                        <div class=""col-xs-6 col-md-6"">
                            <a href=""#"" class=""btn btn-success btn-lg"" role=""button"" style=""margin-left : 10px""><span class=""glyphicon glyphicon-user""></span> <br />Управление покупателями</a>
                            <a href=""#"" class=""btn btn-info btn-lg"" role=""button"" style=""margin-left : 10px""><span class=""glyphicon glyphicon-file""></span> <br />Скоро будет</a>
                            <a ");
            WriteLiteral(@"href=""#"" class=""btn btn-primary btn-lg"" role=""button"" style=""margin-left : 10px""><span class=""glyphicon glyphicon-picture""></span> <br />Скоро будет</a>
                            <a href=""#"" class=""btn btn-primary btn-lg"" role=""button"" style=""margin-left : 10px""><span class=""glyphicon glyphicon-tag""></span> <br />Скоро будет</a>
                        </div>
                    </div>
                    <a href=""http://www.jquery2dotnet.com/"" class=""btn btn-success btn-lg btn-block"" role=""button"" style="" margin-left:10px;""><span class=""glyphicon glyphicon-globe""></span> Скоро будет</a>
                </div>
            </div>
        </div>
    </div>
</div>");
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
