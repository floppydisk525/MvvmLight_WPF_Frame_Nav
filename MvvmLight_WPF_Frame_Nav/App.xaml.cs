using System.Windows;
using GalaSoft.MvvmLight.Threading;

namespace MvvmLight_WPF_Frame_Nav
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static App()
        {
            DispatcherHelper.Initialize();
        }
    }
}
