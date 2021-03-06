using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NLog.Extensions.Logging;
using System.Windows;
using WpfNavigationApp.Contracts;
using WpfNavigationApp.Services;
using WpfNavigationApp.ViewModels;
using WpfNavigationApp.Views;

namespace WpfNavigationApp
{
    public partial class App : Application
    {
        private async void OnStartup(object sender, StartupEventArgs e)
        {
            await CreateHostBuilder(e.Args).StartAsync();
        }

        private IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureLogging((hostBuilderContext, loggingBuilder) =>
                    loggingBuilder.AddNLog(hostBuilderContext.Configuration))
                .ConfigureServices((hostBuilderContext, serviceCollection) =>
                {
                    serviceCollection
                        .AddSingleton<IHostLifetime, WpfHostLifetime>()
                        .AddScoped<MyService>()
                        .AddSingleton<INavigationService, NavigationService>()
                        .AddSingleton<ShellWindow>()
                        .AddSingleton<ShellViewModel>()
                        .AddTransient<Page1ViewModel>()
                        .AddTransient<Page1>()
                        .AddTransient<Page2ViewModel>()
                        .AddTransient<Page2>()
                        .AddTransient<Page3ViewModel>()
                        .AddTransient<Page3>()
                        .AddTransient<Page4ViewModel>()
                        .AddTransient<Page4>()
                        .AddTransient<Page5ViewModel>()
                        .AddTransient<Page5>();
                });
        }
    }
}
