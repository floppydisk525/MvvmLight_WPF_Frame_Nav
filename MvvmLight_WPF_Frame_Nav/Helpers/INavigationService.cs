using System;
using System.Windows.Navigation;

namespace MvvmLight_WPF_Frame_Nav.Helpers
{
    public interface INavigationService
    {
        event NavigatingCancelEventHandler Navigating;
        void NavigateTo(Uri uri);
        void GoBack();
    }
}