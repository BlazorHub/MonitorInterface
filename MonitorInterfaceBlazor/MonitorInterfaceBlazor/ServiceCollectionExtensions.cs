using MonitorInterfaceBlazor.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MonitorInterfaceBlazor
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBlazorModal(this IServiceCollection services)
        {
            return services.AddScoped<IModalService, ModalService>();
        }
    }
}
