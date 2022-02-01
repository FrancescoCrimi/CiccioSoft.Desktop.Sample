using System;
using System.Windows.Controls;

namespace WpfNavigationApp.Contracts
{
    public interface INavigationService
    {
        bool CanGoBack { get; }

        void Initialize(Frame shellFrame);

        bool NavigateTo(Type pageType, object parameter = null, bool clearNavigation = false);

        void GoBack();
    }
}
