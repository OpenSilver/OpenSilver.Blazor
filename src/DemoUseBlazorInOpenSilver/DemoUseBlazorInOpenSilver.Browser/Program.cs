using Microsoft.AspNetCore.Components.Web; 
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using OpenSilver.Blazor;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;

namespace DemoUseBlazorInOpenSilver.Browser
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            // Added:
            builder.RootComponents.RegisterCustomElement<RazorComponentInstantiator>("razorcomponentinstantiator-tag");

            var host = builder.Build();
            await host.RunAsync();
        }

        public static void RunApplication()
        {
            Application.RunApplication(() =>
            {
                var app = new DemoUseBlazorInOpenSilver.App();
            });
        }
    }
}
