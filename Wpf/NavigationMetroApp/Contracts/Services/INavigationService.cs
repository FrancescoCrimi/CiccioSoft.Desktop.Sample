using System;
using System.Windows.Controls;

namespace Wpf.NavigationMetroApp.Contracts.Services
{
    public interface INavigationService
    {
        event EventHandler Navigated;

        bool CanGoBack { get; }

        void Initialize(Frame shellFrame);

        bool NavigateTo(Type pageType, object parameter = null, bool clearNavigation = false);

        void GoBack();
    }
}
