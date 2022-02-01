using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NLog.Extensions.Logging;
using System.Windows;
using WpfNavigationMetroApp.Contracts;
using WpfNavigationMetroApp.Hosting;
using WpfNavigationMetroApp.Services;
using WpfNavigationMetroApp.ViewModels;
using WpfNavigationMetroApp.Views;

namespace WpfNavigationMetroApp
{
    public partial class App : Application
    {
        private async void OnStartup(object sender, StartupEventArgs e) =>
            await CreateHostBuilder(e.Args).Build().RunAsync();

        private IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureLogging((hostBuilderContext, loggingBuilder) =>
                    loggingBuilder.AddNLog(hostBuilderContext.Configuration))
                .ConfigureServices(ConfigureServices)
                .ConfigureWpfHost<ShellWindow>();
        }

        private void ConfigureServices(HostBuilderContext hostBuilderContext,
                                       IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddScoped<MyService>()
                .AddSingleton<IRightPaneService, RightPaneService>()
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
        }
    }
}
