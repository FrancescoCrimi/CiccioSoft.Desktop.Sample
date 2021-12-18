using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NLog.Extensions.Logging;
using System.Windows;
using System.Windows.Threading;
using WpfNavigationMetroApp.Contracts.Services;
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

        private void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            // TODO WTS: Please log and handle the exception as appropriate to your scenario
            // For more info see https://docs.microsoft.com/dotnet/api/system.windows.application.dispatcherunhandledexception?view=netcore-3.0
        }

        private void OnExit(object sender, ExitEventArgs e) { }

        private IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureWPF<ShellWindow>()
            .ConfigureLogging((hostBuilderContext, loggingBuilder) =>
                loggingBuilder.AddNLog(hostBuilderContext.Configuration))
            .ConfigureServices(ConfigureServices);

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
