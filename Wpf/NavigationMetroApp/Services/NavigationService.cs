using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Windows.Controls;
using System.Windows.Navigation;
using Wpf.NavigationMetroApp.Contracts.Services;
using Wpf.NavigationMetroApp.Contracts.ViewModels;

namespace Wpf.NavigationMetroApp.Services
{
    public class NavigationService : INavigationService, IDisposable
    {
        private readonly ILogger<NavigationService> logger;
        private readonly IServiceScopeFactory scopeFactory;
        private IServiceScope scope;
        private IServiceScope oldScope;
        private Frame _frame;
        private object _lastParameterUsed;
        private bool clearNavigation;

        public NavigationService(ILogger<NavigationService> logger,
                                 IServiceScopeFactory serviceScopeFactory)
        {
            this.logger = logger;
            scopeFactory = serviceScopeFactory;
            logger.LogDebug("Created: " + GetHashCode().ToString());
        }

        public event EventHandler Navigated;

        public bool CanGoBack => _frame.CanGoBack;

        public void GoBack()
        {
            if (_frame.CanGoBack)
            {
                var vmBeforeNavigation = _frame.GetDataContext();
                _frame.GoBack();
                if (vmBeforeNavigation is INavigationAware navigationAware)
                {
                    navigationAware.OnNavigatedFrom();
                }
            }
        }

        public void Initialize(Frame shellFrame)
        {
            if (_frame == null)
            {
                _frame = shellFrame;
                _frame.Navigated += OnNavigated;
            }
        }

        public bool NavigateTo(Type pageType, object parameter = null, bool clearNavigation = false)
        {
            if (_frame.Content?.GetType() != pageType || (parameter != null && !parameter.Equals(_lastParameterUsed)))
            {
                if (clearNavigation)
                {
                    oldScope = scope;
                    scope = scopeFactory.CreateScope();
                }
                this.clearNavigation = clearNavigation;

                if (scope == null)
                {
                    scope = scopeFactory.CreateScope();
                }

                var page = scope.ServiceProvider.GetService(pageType);
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
                return navigated;
            }
            return false;
        }

        private void OnNavigated(object sender, NavigationEventArgs e)
        {
            if (sender is Frame frame)
            {
                if (clearNavigation)
                {
                    while (frame.CanGoBack)
                    {
                        frame.RemoveBackEntry();
                    }
                    if (oldScope != null)
                    {
                        oldScope.Dispose();
                        oldScope = null;
                    }
                }
                var dataContext = frame.GetDataContext();
                if (dataContext is INavigationAware navigationAware)
                {
                    navigationAware.OnNavigatedTo(e.ExtraData);
                }
                Navigated?.Invoke(sender, new EventArgs());
            }
        }

        public void Dispose()
        {
            _frame.Navigated -= OnNavigated;
            if (scope != null)
            {
                scope.Dispose();
                scope = null;
            }
            logger.LogDebug("Disposed " + GetHashCode().ToString());
        }
    }
}
