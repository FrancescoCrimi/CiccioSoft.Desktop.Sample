using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;

namespace Wpf.WindowApp.Hosting
{
    public static class WpfHostBuilderExtensions
    {
        public static IHostBuilder ConfigureWPF<TWindow>(this IHostBuilder hostBuilder) where TWindow : Window
        {
            return hostBuilder
                .ConfigureServices((hostBuilderContext, serviceCollection) =>
                    serviceCollection
                        .AddSingleton<IHostLifetime, WpfAppLifetime>()
                        .AddHostedService<WpfAppHostedService<TWindow>>());
        }
    }
}
