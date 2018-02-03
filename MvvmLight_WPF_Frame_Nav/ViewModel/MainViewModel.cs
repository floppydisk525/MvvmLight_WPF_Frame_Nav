using GalaSoft.MvvmLight;
using MvvmLight_WPF_Frame_Nav.Model;
using System.Windows.Controls;
//using MvvmLight_Nav_MJ.Helpers;

namespace MvvmLight_WPF_Frame_Nav.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;

        /// <summary>
        /// The <see cref="WelcomeTitle" /> property's name.
        /// </summary>
        public const string WelcomeTitlePropertyName = "WelcomeTitle";

        private string _welcomeTitle = string.Empty;

        /// <summary>
        /// Gets the WelcomeTitle property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string WelcomeTitle
        {
            get
            {
                return _welcomeTitle;
            }
            set
            {
                Set(ref _welcomeTitle, value);
            }
        }
        
        /// <summary>
        /// The <see cref="DisplayFrame" /> property's name.
        /// </summary>
        public const string DisplayFramePropertyName = "DisplayFrame";

        private Frame _displayFrame = new Frame();

        /// <summary>
        /// Sets and gets the DisplayPage property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Frame DisplayFrame
        {
            get
            {
                return _displayFrame;
            }
            set
            {
                Set(DisplayFramePropertyName, ref _displayFrame, value);
            }
        }

        //public Frame DisplayPage { get => _displayFrame; set => _displayFrame = value; }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IDataService dataService)
        {
            _dataService = dataService;
            _dataService.GetData(
                (item, error) =>
                {
                    if (error != null)
                    {
                        // Report error here
                        return;
                    }

                    WelcomeTitle = item.Title;
                    DisplayFrame.NavigationService.Navigate(ViewModelLocator.IntroPageUri);
                });
        }

        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}
    }
}