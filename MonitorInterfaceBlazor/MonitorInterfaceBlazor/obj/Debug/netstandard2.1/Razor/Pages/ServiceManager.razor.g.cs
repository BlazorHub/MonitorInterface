#pragma checksum "C:\Users\q1440767\source\repos\MonitorInterfaceBlazor\MonitorInterfaceBlazor\Pages\ServiceManager.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3291fc6efa3c52d1c58a2d24141b3eab128e0af9"
// <auto-generated/>
#pragma warning disable 1591
namespace MonitorInterfaceBlazor.Pages
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
    [Microsoft.AspNetCore.Components.RouteAttribute("/ServiceManager")]
    public partial class ServiceManager : ServiceManagerBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
#nullable restore
#line 4 "C:\Users\q1440767\source\repos\MonitorInterfaceBlazor\MonitorInterfaceBlazor\Pages\ServiceManager.razor"
 if (results != null)
{

#line default
#line hidden
#nullable disable
            __builder.AddContent(0, "    ");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Forms.EditForm>(1);
            __builder.AddAttribute(2, "Model", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Object>(
#nullable restore
#line 6 "C:\Users\q1440767\source\repos\MonitorInterfaceBlazor\MonitorInterfaceBlazor\Pages\ServiceManager.razor"
                      results

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(3, "OnInvalidSubmit", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Forms.EditContext>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Forms.EditContext>(this, 
#nullable restore
#line 6 "C:\Users\q1440767\source\repos\MonitorInterfaceBlazor\MonitorInterfaceBlazor\Pages\ServiceManager.razor"
                                                 HandleValidSubmit

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(4, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Forms.EditContext>)((context) => (__builder2) => {
                __builder2.AddMarkupContent(5, "\r\n        ");
                __builder2.OpenElement(6, "div");
                __builder2.AddAttribute(7, "class", "serviceMessage");
                __builder2.AddMarkupContent(8, "\r\n            ");
                __builder2.OpenElement(9, "label");
                __builder2.AddAttribute(10, "class", "serviceLabel");
                __builder2.OpenElement(11, "font");
                __builder2.AddAttribute(12, "color", 
#nullable restore
#line 8 "C:\Users\q1440767\source\repos\MonitorInterfaceBlazor\MonitorInterfaceBlazor\Pages\ServiceManager.razor"
                                                     FontColor

#line default
#line hidden
#nullable disable
                );
                __builder2.AddContent(13, 
#nullable restore
#line 8 "C:\Users\q1440767\source\repos\MonitorInterfaceBlazor\MonitorInterfaceBlazor\Pages\ServiceManager.razor"
                                                                Message

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(14, "\r\n        ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(15, "\r\n        ");
                __builder2.OpenElement(16, "div");
                __builder2.AddAttribute(17, "class", "serviceManagerButtons");
                __builder2.AddMarkupContent(18, "\r\n            ");
                __builder2.OpenElement(19, "button");
                __builder2.AddAttribute(20, "type", "button");
                __builder2.AddAttribute(21, "class", "btn btn-primary");
                __builder2.AddAttribute(22, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 11 "C:\Users\q1440767\source\repos\MonitorInterfaceBlazor\MonitorInterfaceBlazor\Pages\ServiceManager.razor"
                                                                    SetService

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddContent(23, "Set");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(24, "\r\n            ");
                __builder2.OpenElement(25, "button");
                __builder2.AddAttribute(26, "type", "button");
                __builder2.AddAttribute(27, "class", "btn btn-danger");
                __builder2.AddAttribute(28, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 12 "C:\Users\q1440767\source\repos\MonitorInterfaceBlazor\MonitorInterfaceBlazor\Pages\ServiceManager.razor"
                                                                   SaveChanges

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(29, "disabled", 
#nullable restore
#line 12 "C:\Users\q1440767\source\repos\MonitorInterfaceBlazor\MonitorInterfaceBlazor\Pages\ServiceManager.razor"
                                                                                           IsDisabled

#line default
#line hidden
#nullable disable
                );
                __builder2.AddContent(30, "Save");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(31, "\r\n            ");
                __builder2.OpenElement(32, "button");
                __builder2.AddAttribute(33, "type", "button");
                __builder2.AddAttribute(34, "class", "btn btn-warning");
                __builder2.AddAttribute(35, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 13 "C:\Users\q1440767\source\repos\MonitorInterfaceBlazor\MonitorInterfaceBlazor\Pages\ServiceManager.razor"
                                                                    ClearDowntimes

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(36, "disabled", 
#nullable restore
#line 13 "C:\Users\q1440767\source\repos\MonitorInterfaceBlazor\MonitorInterfaceBlazor\Pages\ServiceManager.razor"
                                                                                               IsDisabled

#line default
#line hidden
#nullable disable
                );
                __builder2.AddContent(37, "Clear Downtimes");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(38, "\r\n            ");
                __builder2.OpenElement(39, "button");
                __builder2.AddAttribute(40, "type", "button");
                __builder2.AddAttribute(41, "class", "btn btn-primary");
                __builder2.AddAttribute(42, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 14 "C:\Users\q1440767\source\repos\MonitorInterfaceBlazor\MonitorInterfaceBlazor\Pages\ServiceManager.razor"
                                                                    Exit

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddContent(43, "Exit");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(44, "\r\n        ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(45, "\r\n        ");
                __builder2.OpenElement(46, "div");
                __builder2.AddAttribute(47, "class", "datePickers");
                __builder2.AddMarkupContent(48, "\r\n            ");
                __builder2.OpenElement(49, "div");
                __builder2.AddAttribute(50, "class", "datePicker1");
                __builder2.AddMarkupContent(51, "\r\n                ");
                __builder2.OpenElement(52, "p");
                __builder2.AddAttribute(53, "class", "datePicker");
                __builder2.AddMarkupContent(54, "\r\n                    ");
                __Blazor.MonitorInterfaceBlazor.Pages.ServiceManager.TypeInference.CreateMatBlazor_MatDatePicker_0(__builder2, 55, 56, 
#nullable restore
#line 19 "C:\Users\q1440767\source\repos\MonitorInterfaceBlazor\MonitorInterfaceBlazor\Pages\ServiceManager.razor"
                                                           Date1

#line default
#line hidden
#nullable disable
                , 57, Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => Date1 = __value, Date1)), 58, () => Date1);
                __builder2.AddMarkupContent(59, "\r\n                ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(60, "\r\n                ");
                __builder2.OpenElement(61, "span");
                __builder2.AddAttribute(62, "class", "datePickerResults");
                __builder2.OpenElement(63, "strong");
                __builder2.AddContent(64, "Start: ");
                __builder2.AddContent(65, 
#nullable restore
#line 21 "C:\Users\q1440767\source\repos\MonitorInterfaceBlazor\MonitorInterfaceBlazor\Pages\ServiceManager.razor"
                                                                 Date1.HasValue ? Date1.Value.ToLocalTime().ToString() : ""

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(66, "\r\n            ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(67, "\r\n            ");
                __builder2.OpenElement(68, "div");
                __builder2.AddAttribute(69, "class", "datePicker2");
                __builder2.AddMarkupContent(70, "\r\n                ");
                __builder2.OpenElement(71, "p");
                __builder2.AddAttribute(72, "class", "datePicker");
                __builder2.AddMarkupContent(73, "\r\n                    ");
                __Blazor.MonitorInterfaceBlazor.Pages.ServiceManager.TypeInference.CreateMatBlazor_MatDatePicker_1(__builder2, 74, 75, 
#nullable restore
#line 25 "C:\Users\q1440767\source\repos\MonitorInterfaceBlazor\MonitorInterfaceBlazor\Pages\ServiceManager.razor"
                                                           Date2

#line default
#line hidden
#nullable disable
                , 76, Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => Date2 = __value, Date2)), 77, () => Date2);
                __builder2.AddMarkupContent(78, "\r\n                ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(79, "\r\n                ");
                __builder2.OpenElement(80, "span");
                __builder2.AddAttribute(81, "class", "datePickerResults");
                __builder2.OpenElement(82, "strong");
                __builder2.AddContent(83, "End: ");
                __builder2.AddContent(84, 
#nullable restore
#line 27 "C:\Users\q1440767\source\repos\MonitorInterfaceBlazor\MonitorInterfaceBlazor\Pages\ServiceManager.razor"
                                                               Date2.HasValue ? Date2.Value.ToLocalTime().ToString() : ""

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(85, "\r\n            ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(86, "\r\n        ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(87, "\r\n        ");
                __builder2.OpenElement(88, "div");
                __builder2.AddAttribute(89, "class", "jobSelectFields");
                __builder2.AddMarkupContent(90, "\r\n            ");
                __builder2.OpenElement(91, "table");
                __builder2.AddAttribute(92, "class", "table");
                __builder2.AddMarkupContent(93, "\r\n                ");
                __builder2.OpenElement(94, "tr");
                __builder2.AddMarkupContent(95, "\r\n                    <th></th>\r\n                    ");
                __builder2.OpenElement(96, "th");
                __builder2.OpenElement(97, "button");
                __builder2.AddAttribute(98, "type", "button");
                __builder2.AddAttribute(99, "class", "btn btn-warning");
                __builder2.AddAttribute(100, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 34 "C:\Users\q1440767\source\repos\MonitorInterfaceBlazor\MonitorInterfaceBlazor\Pages\ServiceManager.razor"
                                                                                SelectAll

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddContent(101, 
#nullable restore
#line 34 "C:\Users\q1440767\source\repos\MonitorInterfaceBlazor\MonitorInterfaceBlazor\Pages\ServiceManager.razor"
                                                                                            SelectMessage

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(102, "\r\n                    ");
                __builder2.AddMarkupContent(103, "<th>Scheduled Downtimes</th>\r\n                ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(104, "\r\n");
#nullable restore
#line 37 "C:\Users\q1440767\source\repos\MonitorInterfaceBlazor\MonitorInterfaceBlazor\Pages\ServiceManager.razor"
                 foreach (var item in results)
                {

#line default
#line hidden
#nullable disable
                __builder2.AddContent(105, "                    ");
                __builder2.OpenElement(106, "tr");
                __builder2.AddMarkupContent(107, "\r\n                        ");
                __builder2.OpenElement(108, "td");
                __builder2.AddMarkupContent(109, "\r\n                            ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputCheckbox>(110);
                __builder2.AddAttribute(111, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 41 "C:\Users\q1440767\source\repos\MonitorInterfaceBlazor\MonitorInterfaceBlazor\Pages\ServiceManager.razor"
                                                                                    () => JobChecked(item.JOB_NAME)

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(112, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 41 "C:\Users\q1440767\source\repos\MonitorInterfaceBlazor\MonitorInterfaceBlazor\Pages\ServiceManager.razor"
                                                       item.IsJobSelected

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(113, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.Boolean>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.Boolean>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => item.IsJobSelected = __value, item.IsJobSelected))));
                __builder2.AddAttribute(114, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.Boolean>>>(() => item.IsJobSelected));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(115, "\r\n                        ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(116, "\r\n                        ");
                __builder2.OpenElement(117, "td");
                __builder2.AddMarkupContent(118, "\r\n                            ");
                __builder2.AddContent(119, 
#nullable restore
#line 44 "C:\Users\q1440767\source\repos\MonitorInterfaceBlazor\MonitorInterfaceBlazor\Pages\ServiceManager.razor"
                             item.JOB_NAME

#line default
#line hidden
#nullable disable
                );
                __builder2.AddMarkupContent(120, "\r\n                        ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(121, "\r\n                        ");
                __builder2.OpenElement(122, "td");
                __builder2.AddMarkupContent(123, "\r\n                            ");
                __builder2.AddContent(124, 
#nullable restore
#line 47 "C:\Users\q1440767\source\repos\MonitorInterfaceBlazor\MonitorInterfaceBlazor\Pages\ServiceManager.razor"
                             item.ScheduledDownTime

#line default
#line hidden
#nullable disable
                );
                __builder2.AddMarkupContent(125, "\r\n                        ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(126, "\r\n                    ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(127, "\r\n");
#nullable restore
#line 50 "C:\Users\q1440767\source\repos\MonitorInterfaceBlazor\MonitorInterfaceBlazor\Pages\ServiceManager.razor"
                }

#line default
#line hidden
#nullable disable
                __builder2.AddContent(128, "            ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(129, "\r\n        ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(130, "\r\n    ");
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(131, "\r\n");
#nullable restore
#line 54 "C:\Users\q1440767\source\repos\MonitorInterfaceBlazor\MonitorInterfaceBlazor\Pages\ServiceManager.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 56 "C:\Users\q1440767\source\repos\MonitorInterfaceBlazor\MonitorInterfaceBlazor\Pages\ServiceManager.razor"
       
    void HandleValidSubmit()
    {
        Console.WriteLine("OnValidSubmit");
    }

#line default
#line hidden
#nullable disable
    }
}
namespace __Blazor.MonitorInterfaceBlazor.Pages.ServiceManager
{
    #line hidden
    internal static class TypeInference
    {
        public static void CreateMatBlazor_MatDatePicker_0<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, TValue __arg0, int __seq1, global::Microsoft.AspNetCore.Components.EventCallback<TValue> __arg1, int __seq2, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg2)
        {
        __builder.OpenComponent<global::MatBlazor.MatDatePicker<TValue>>(seq);
        __builder.AddAttribute(__seq0, "Value", __arg0);
        __builder.AddAttribute(__seq1, "ValueChanged", __arg1);
        __builder.AddAttribute(__seq2, "ValueExpression", __arg2);
        __builder.CloseComponent();
        }
        public static void CreateMatBlazor_MatDatePicker_1<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, TValue __arg0, int __seq1, global::Microsoft.AspNetCore.Components.EventCallback<TValue> __arg1, int __seq2, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg2)
        {
        __builder.OpenComponent<global::MatBlazor.MatDatePicker<TValue>>(seq);
        __builder.AddAttribute(__seq0, "Value", __arg0);
        __builder.AddAttribute(__seq1, "ValueChanged", __arg1);
        __builder.AddAttribute(__seq2, "ValueExpression", __arg2);
        __builder.CloseComponent();
        }
    }
}
#pragma warning restore 1591