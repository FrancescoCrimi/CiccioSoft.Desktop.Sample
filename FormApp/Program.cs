using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;
using FormApp.Services;
using FormApp.Views;

namespace FormApp
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            await CreateHostBuilder(args).StartAsync();
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostBuilderContext, serviceCollection) =>
                {
                    serviceCollection
                        .AddSingleton<IHostLifetime, FormHostLifetime>()
                        .AddSingleton<WindowService>()
                        .AddSingleton<DialogService>()
                        .AddTransient<MainWindow>()
                        .AddTransient<Window1>()
                        .AddTransient<Window2>()
                        .AddTransient<Window3>()
                        .AddTransient<Window4>()
                        .AddTransient<Window5>()
                        .AddScoped<MyService>();
                });
        }
    }
}
