#pragma checksum "C:\Users\Zhdan\source\repos\ZShop\ZShop\Views\Home\ViewProduct.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3cf4e3942c8af0304ed713610d5bac0f431ca359"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_ViewProduct), @"mvc.1.0.view", @"/Views/Home/ViewProduct.cshtml")]
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
#line 1 "C:\Users\Zhdan\source\repos\ZShop\ZShop\Views\_ViewImports.cshtml"
using ZShop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Zhdan\source\repos\ZShop\ZShop\Views\_ViewImports.cshtml"
using ZShop.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3cf4e3942c8af0304ed713610d5bac0f431ca359", @"/Views/Home/ViewProduct.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dddf48b01e87c2b8187c25bf68804d6cfc85afcb", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_ViewProduct : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Entities.Product>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "ShopCart", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddToCart", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success btn-lg btn-block text-uppercase"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("submit"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("cart.html"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Zhdan\source\repos\ZShop\ZShop\Views\Home\ViewProduct.cshtml"
  
    ViewData["Title"] = "ViewProduct";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    <style>
        .bloc_left_price {
            color: #c01508;
            text-align: center;
            font-weight: bold;
            font-size: 150%;
        }

        .category_block li:hover {
            background-color: #007bff;
        }

            .category_block li:hover a {
                color: #ffffff;
            }

        .category_block li a {
            color: #343a40;
        }

        .add_to_cart_block .price {
            color: #c01508;
            text-align: center;
            font-weight: bold;
            font-size: 200%;
            margin-bottom: 0;
        }

        .add_to_cart_block .price_discounted {
            color: #343a40;
            text-align: center;
            text-decoration: line-through;
            font-size: 140%;
        }

        .product_rassurance {
            padding: 10px;
            margin-top: 15px;
            background: #ffffff;
            border: 1px solid #6c757d;
            color: #6c7");
            WriteLiteral(@"57d;
        }

            .product_rassurance .list-inline {
                margin-bottom: 0;
                text-transform: uppercase;
                text-align: center;
            }

                .product_rassurance .list-inline li:hover {
                    color: #343a40;
                }

        .reviews_product .fa-star {
            color: gold;
        }

        .pagination {
            margin-top: 20px;
        }

       
    </style>

<!------ Include the above in your HEAD tag ---------->

<link href=""https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css"" rel=""stylesheet"" integrity=""sha384-wvfXpqpZZVQGK6TAh5PVlGOfQNHSoD2xbE+QkPxCAFlNEevoEH3Sl0sibVcOQVnN"" crossorigin=""anonymous"">

<div class=""container"">
    <div class=""row"">
        <div class=""col"">
            <nav aria-label=""breadcrumb"">
                <ol class=""breadcrumb"">
                    <li class=""breadcrumb-item""><a href=""/"">Главная</a></li>
                    <li");
            WriteLiteral(@" class=""breadcrumb-item""><a href=""category.html"">Категории</a></li>
                    <li class=""breadcrumb-item active"" aria-current=""page"">...</li>
                </ol>
            </nav>
        </div>
    </div>
</div>
<div class=""container"">
    <div class=""row"">
        <!-- Image -->

        <div id=""carouselExampleIndicators"" class=""carousel slide col-12 col-lg-6"" data-ride=""carousel"" >
            <ol class=""carousel-indicators"">
                <li data-target=""#carouselExampleIndicators"" data-slide-to=""0"" class=""active""></li>
                <li data-target=""#carouselExampleIndicators"" data-slide-to=""1""></li>
                <li data-target=""#carouselExampleIndicators"" data-slide-to=""2""></li>
            </ol>
            <div class=""carousel-inner"">
                <div class=""carousel-item active"">
                    <img class=""d-block w-100""");
            BeginWriteAttribute("src", " src=\"", 3014, "\"", 3051, 1);
#nullable restore
#line 100 "C:\Users\Zhdan\source\repos\ZShop\ZShop\Views\Home\ViewProduct.cshtml"
WriteAttributeValue("", 3020, Html.DisplayFor(x=>x.ImageUrl), 3020, 31, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"First slide\">\r\n                </div>\r\n                <div class=\"carousel-item\">\r\n                    <img class=\"d-block w-100\"");
            BeginWriteAttribute("src", " src=\"", 3188, "\"", 3225, 1);
#nullable restore
#line 103 "C:\Users\Zhdan\source\repos\ZShop\ZShop\Views\Home\ViewProduct.cshtml"
WriteAttributeValue("", 3194, Html.DisplayFor(x=>x.ImageUrl), 3194, 31, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"Second slide\">\r\n                </div>\r\n                <div class=\"carousel-item\">\r\n                    <img class=\"d-block w-100\"");
            BeginWriteAttribute("src", " src=\"", 3363, "\"", 3400, 1);
#nullable restore
#line 106 "C:\Users\Zhdan\source\repos\ZShop\ZShop\Views\Home\ViewProduct.cshtml"
WriteAttributeValue("", 3369, Html.DisplayFor(x=>x.ImageUrl), 3369, 31, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" alt=""Third slide"">
                </div>
            </div>
            <a class=""carousel-control-prev"" href=""#carouselExampleIndicators"" role=""button"" data-slide=""prev"">
                <span class=""carousel-control-prev-icon"" aria-hidden=""true""></span>
                <span class=""sr-only"">Previous</span>
            </a>
            <a class=""carousel-control-next"" href=""#carouselExampleIndicators"" role=""button"" data-slide=""next"">
                <span class=""carousel-control-next-icon"" aria-hidden=""true""></span>
                <span class=""sr-only"">Next</span>
            </a>
        </div>

");
            WriteLiteral("\r\n        <!-- Add to cart -->\r\n        <div class=\"col-12 col-lg-6 add_to_cart_block\">\r\n            <div class=\"card bg-light mb-3\">\r\n                <div class=\"card-body\">\r\n                    <p class=\"h3\" style=\"text-align : center;\">");
#nullable restore
#line 134 "C:\Users\Zhdan\source\repos\ZShop\ZShop\Views\Home\ViewProduct.cshtml"
                                                          Write(Html.DisplayFor(x => x.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\r\n                    <p class=\"price\">99.00 грн</p>\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3cf4e3942c8af0304ed713610d5bac0f431ca35911325", async() => {
                WriteLiteral("\r\n");
                WriteLiteral("                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3cf4e3942c8af0304ed713610d5bac0f431ca35911643", async() => {
                    WriteLiteral("\r\n                            <i class=\"fa fa-shopping-cart\"></i> Add To Cart\r\n                        ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 146 "C:\Users\Zhdan\source\repos\ZShop\ZShop\Views\Home\ViewProduct.cshtml"
                                                                              WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                    <div class=""product_rassurance"">
                        <ul class=""list-inline"">
                            <li class=""list-inline-item""><i class=""fa fa-phone fa-2x""></i><br />+38 (098) 929 79 00</li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class=""row"">
        <!-- Description -->
        <div class=""col-12"">
            <div class=""card border-light mb-3"">
                <div class=""card-header bg-primary text-white text-uppercase""><i class=""fa fa-align-justify""></i> Description</div>
                <div class=""card-body"">
                    <p class=""card-text"">
                        ");
#nullable restore
#line 167 "C:\Users\Zhdan\source\repos\ZShop\ZShop\Views\Home\ViewProduct.cshtml"
                   Write(Html.DisplayFor(x => x.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                    </p>
                    <p class=""card-text"">

                    </p>
                </div>
            </div>
        </div>

        <!-- Reviews -->
        <!-- Footer -->
        <!-- Modal image -->
        <div class=""modal fade"" id=""productModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""productModalLabel"" aria-hidden=""true"">
            <div class=""modal-dialog modal-lg"" role=""document"">
                <div class=""modal-content"">
                    <div class=""modal-header"">
                        <h5 class=""modal-title"" id=""productModalLabel"">Product title</h5>
                        <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                            <span aria-hidden=""true"">×</span>
                        </button>
                    </div>
                    <div class=""modal-body"">
                        <img class=""img-fluid"" src=""https://dummyimage.com/1200x1200/55595c/fff"" />
                    </d");
            WriteLiteral(@"iv>
                    <div class=""modal-footer"">
                        <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Close</button>
                    </div>
                </div>
            </div>
        </div>
<script type=""text/javascript"">
    $(document).ready(function () {
        $.ajax({
            type: ""POST"",
            url: ""/ShopCart/ClearCart"",
            data: ""{}"",
            contentType: ""application/json; charset=utf-8"",
            dataType: ""json"",
            success: function (msg) {
                alert(msg.d);
            }
        });
    });
   </script>
        <script>
    $(document).ready(function () {
        var quantity = 1;

        $('.quantity-right-plus').click(function (e) {
            e.preventDefault();
            var quantity = parseInt($('#quantity').val());
            $('#quantity').val(quantity + 1);
        });

        $('.quantity-left-minus').click(function (e) {
            e.preventDefault(");
            WriteLiteral(");\r\n            var quantity = parseInt($(\'#quantity\').val());\r\n            if (quantity > 1) {\r\n                $(\'#quantity\').val(quantity - 1);\r\n            }\r\n        });\r\n\r\n    });\r\n        </script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Entities.Product> Html { get; private set; }
    }
}
#pragma warning restore 1591
