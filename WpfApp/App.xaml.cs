using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NLog.Extensions.Logging;
using System.Windows;
using WpfApp.Services;
using WpfApp.ViewModels;
using WpfApp.Views;

namespace WpfApp
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
                        .AddSingleton<WindowService>()
                        .AddScoped<DialogService>()
                        .AddTransient<MainWindowViewModel>()
                        .AddTransient<MainWindow>()
                        .AddTransient<Window1ViewModel>()
                        .AddTransient<Window1>()
                        .AddTransient<Window2ViewModel>()
                        .AddTransient<Window2>()
                        .AddTransient<Window3ViewModel>()
                        .AddTransient<Window3>()
                        .AddTransient<Window4ViewModel>()
                        .AddTransient<Window4>()
                        .AddTransient<Window5ViewModel>()
                        .AddTransient<Window5>()
                        .AddScoped<MyService>();
                });
        }
    }
}
