using Microsoft.AspNetCore.Blazor.Hosting;
using System.Threading.Tasks;

namespace MonitorInterfaceBlazor
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.Services.AddBlazorModal();
            builder.RootComponents.Add<App>("app");

            await builder.Build().RunAsync();
        }       
    }
}
