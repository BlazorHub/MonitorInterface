#pragma checksum "C:\Users\q1440767\source\repos\MonitorInterfaceBlazor\MonitorInterfaceBlazor\Modal.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ba0c64e1e2b3bdac36a54fd5c37c1678da87ed3e"
// <auto-generated/>
#pragma warning disable 1591
namespace MonitorInterfaceBlazor
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\q1440767\source\repos\MonitorInterfaceBlazor\MonitorInterfaceBlazor\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\q1440767\source\repos\MonitorInterfaceBlazor\MonitorInterfaceBlazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\q1440767\source\repos\MonitorInterfaceBlazor\MonitorInterfaceBlazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\q1440767\source\repos\MonitorInterfaceBlazor\MonitorInterfaceBlazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\q1440767\source\repos\MonitorInterfaceBlazor\MonitorInterfaceBlazor\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\q1440767\source\repos\MonitorInterfaceBlazor\MonitorInterfaceBlazor\_Imports.razor"
using MonitorInterfaceBlazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\q1440767\source\repos\MonitorInterfaceBlazor\MonitorInterfaceBlazor\_Imports.razor"
using MonitorInterfaceBlazor.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\q1440767\source\repos\MonitorInterfaceBlazor\MonitorInterfaceBlazor\_Imports.razor"
using MatBlazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\q1440767\source\repos\MonitorInterfaceBlazor\MonitorInterfaceBlazor\_Imports.razor"
using MonitorInterfaceBlazor.Services;

#line default
#line hidden
#nullable disable
    public partial class Modal : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "bm-container" + " " + (
#nullable restore
#line 1 "C:\Users\q1440767\source\repos\MonitorInterfaceBlazor\MonitorInterfaceBlazor\Modal.razor"
                           IsVisible ? "bm-active" : string.Empty

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(2, "\r\n\r\n    ");
            __builder.OpenElement(3, "div");
            __builder.AddAttribute(4, "class", "bm-overlay");
            __builder.AddAttribute(5, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 3 "C:\Users\q1440767\source\repos\MonitorInterfaceBlazor\MonitorInterfaceBlazor\Modal.razor"
                                      HandleBackgroundClick

#line default
#line hidden
#nullable disable
            ));
            __builder.CloseElement();
            __builder.AddMarkupContent(6, "\r\n\r\n    ");
            __builder.OpenElement(7, "div");
            __builder.AddAttribute(8, "class", "blazor-modal");
            __builder.AddMarkupContent(9, "\r\n        ");
            __builder.OpenElement(10, "div");
            __builder.AddAttribute(11, "class", "bm-header");
            __builder.AddMarkupContent(12, "            \r\n            ");
            __builder.OpenElement(13, "h3");
            __builder.AddAttribute(14, "class", "bm-title");
            __builder.AddContent(15, 
#nullable restore
#line 7 "C:\Users\q1440767\source\repos\MonitorInterfaceBlazor\MonitorInterfaceBlazor\Modal.razor"
                                  Title

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(16, "\r\n");
#nullable restore
#line 8 "C:\Users\q1440767\source\repos\MonitorInterfaceBlazor\MonitorInterfaceBlazor\Modal.razor"
             if (!ComponentHideCloseButton)
            {

#line default
#line hidden
#nullable disable
            __builder.AddContent(17, "                ");
            __builder.OpenElement(18, "button");
            __builder.AddAttribute(19, "type", "button");
            __builder.AddAttribute(20, "class", "bm-close");
            __builder.AddAttribute(21, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 10 "C:\Users\q1440767\source\repos\MonitorInterfaceBlazor\MonitorInterfaceBlazor\Modal.razor"
                                                                   () => ModalService.Cancel()

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(22, "\r\n                    ");
            __builder.AddMarkupContent(23, "<span>&times;</span>\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(24, "\r\n");
#nullable restore
#line 13 "C:\Users\q1440767\source\repos\MonitorInterfaceBlazor\MonitorInterfaceBlazor\Modal.razor"
            }               

#line default
#line hidden
#nullable disable
            __builder.AddContent(25, "        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(26, "\r\n        ");
            __builder.OpenElement(27, "div");
            __builder.AddAttribute(28, "class", "bm-content");
            __builder.AddMarkupContent(29, "\r\n            ");
            __Blazor.MonitorInterfaceBlazor.Modal.TypeInference.CreateCascadingValue_0(__builder, 30, 31, 
#nullable restore
#line 16 "C:\Users\q1440767\source\repos\MonitorInterfaceBlazor\MonitorInterfaceBlazor\Modal.razor"
                                   this

#line default
#line hidden
#nullable disable
            , 32, (__builder2) => {
                __builder2.AddMarkupContent(33, "\r\n                ");
                __Blazor.MonitorInterfaceBlazor.Modal.TypeInference.CreateCascadingValue_1(__builder2, 34, 35, 
#nullable restore
#line 17 "C:\Users\q1440767\source\repos\MonitorInterfaceBlazor\MonitorInterfaceBlazor\Modal.razor"
                                        Parameters

#line default
#line hidden
#nullable disable
                , 36, (__builder3) => {
                    __builder3.AddMarkupContent(37, "\r\n                    ");
                    __builder3.AddContent(38, 
#nullable restore
#line 18 "C:\Users\q1440767\source\repos\MonitorInterfaceBlazor\MonitorInterfaceBlazor\Modal.razor"
                     Content

#line default
#line hidden
#nullable disable
                    );
                    __builder3.AddMarkupContent(39, "\r\n                ");
                }
                );
                __builder2.AddMarkupContent(40, "\r\n            ");
            }
            );
            __builder.AddMarkupContent(41, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(42, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(43, "\r\n");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
    }
}
namespace __Blazor.MonitorInterfaceBlazor.Modal
{
    #line hidden
    internal static class TypeInference
    {
        public static void CreateCascadingValue_0<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, TValue __arg0, int __seq1, global::Microsoft.AspNetCore.Components.RenderFragment __arg1)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.CascadingValue<TValue>>(seq);
        __builder.AddAttribute(__seq0, "Value", __arg0);
        __builder.AddAttribute(__seq1, "ChildContent", __arg1);
        __builder.CloseComponent();
        }
        public static void CreateCascadingValue_1<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, TValue __arg0, int __seq1, global::Microsoft.AspNetCore.Components.RenderFragment __arg1)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.CascadingValue<TValue>>(seq);
        __builder.AddAttribute(__seq0, "Value", __arg0);
        __builder.AddAttribute(__seq1, "ChildContent", __arg1);
        __builder.CloseComponent();
        }
    }
}
#pragma warning restore 1591
