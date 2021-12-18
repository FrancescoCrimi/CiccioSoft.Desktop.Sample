using MahApps.Metro.Controls;
using Microsoft.Extensions.Logging;
using System;
using System.Windows.Controls;
using System.Windows.Navigation;
using WpfNavigationMetroApp.Contracts.Services;
using WpfNavigationMetroApp.Contracts.ViewModels;

namespace WpfNavigationMetroApp.Services
{
    public class RightPaneService : IRightPaneService, IDisposable
    {
        private readonly ILogger<RightPaneService> logger;
        private readonly IServiceProvider _serviceProvider;
        private Frame _frame;
        private object _lastParameterUsed;
        private SplitView _splitView;

        public RightPaneService(ILogger<RightPaneService> logger,
                                IServiceProvider serviceProvider)
        {
            this.logger = logger;
            _serviceProvider = serviceProvider;
            logger.LogDebug("Created: " + GetHashCode().ToString());
        }

        public event EventHandler PaneOpened;

        public event EventHandler PaneClosed;

        public void Initialize(Frame rightPaneFrame, SplitView splitView)
        {
            _frame = rightPaneFrame;
            _splitView = splitView;
            _frame.Navigated += OnNavigated;
            _splitView.PaneClosed += OnPaneClosed;
        }

        public void OpenInRightPane(Type pageType, object parameter = null)
        {
            if (_frame.Content?.GetType() != pageType || (parameter != null && !parameter.Equals(_lastParameterUsed)))
            {
                var page = _serviceProvider.GetService(pageType);
                var navigated = _frame.Navigate(page, parameter);
                if (navigated)
                {
                    _lastParameterUsed = parameter;
                    var dataContext = _frame.GetDataContext();
                    if (dataContext is INavigationAware navigationAware)
                    {
                        navigationAware.OnNavigatedFrom();
                    }
                }
            }
            _splitView.IsPaneOpen = true;
            PaneOpened?.Invoke(_splitView, EventArgs.Empty);
        }

        private void OnNavigated(object sender, NavigationEventArgs e)
        {
            if (sender is Frame frame)
            {
                while (frame.CanGoBack)
                {
                    frame.RemoveBackEntry();
                }
                var dataContext = frame.GetDataContext();
                if (dataContext is INavigationAware navigationAware)
                {
                    navigationAware.OnNavigatedTo(e.ExtraData);
                }
            }
        }

        private void OnPaneClosed(object sender, EventArgs e)
            => PaneClosed?.Invoke(sender, e);

        public void Dispose()
        {
            _frame.Navigated -= OnNavigated;
            _splitView.PaneClosed -= OnPaneClosed;
            logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}
