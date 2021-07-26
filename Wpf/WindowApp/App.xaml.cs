using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NLog.Extensions.Logging;
using System.Windows;
using System.Windows.Threading;
using Wpf.WindowApp.Hosting;
using Wpf.WindowApp.Services;
using Wpf.WindowApp.ViewModels;
using Wpf.WindowApp.Views;

namespace Wpf.WindowApp
{
    public partial class App : Application
    {
        private async void OnStartup(object sender, StartupEventArgs e) =>
            await CreateHostBuilder(e.Args).Build().RunAsync();

        private IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureWPF<MainWindow>()
            .ConfigureLogging((hostBuilderContext, loggingBuilder) =>
                loggingBuilder.AddNLog(hostBuilderContext.Configuration))
            .ConfigureServices(ConfigureServices);

        private void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e) { }

        private void OnExit(object sender, ExitEventArgs e) { }

        private void ConfigureServices(HostBuilderContext hostBuilderContext,
                                       IServiceCollection serviceCollection) =>
            serviceCollection
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
    }
}
