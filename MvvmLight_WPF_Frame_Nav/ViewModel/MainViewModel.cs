using GalaSoft.MvvmLight;
using MvvmLight_WPF_Frame_Nav.Model;
using System;
using System.Windows.Controls;
using MvvmLight_WPF_Frame_Nav.Helpers;

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
        private readonly INavigationService _navigationService;

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

        /// <summary>
        /// The <see cref="FrameUri" /> property's name.
        /// </summary>
        public const string FrameUriPropertyName = "FrameUri";

        private Uri _frameUri;

        /// <summary>
        /// Sets and gets the FrameUri property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Uri FrameUri
        {
            get
            {
                return _frameUri;
            }
            set
            {
                Set(FrameUriPropertyName, ref _frameUri, value);
            }
        }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IDataService dataService, INavigationService navigationService)
        {
            _dataService = dataService;
            //_navigationService = navigationService;
            _dataService.GetData(
                (item, error) =>
                {
                    if (error != null)
                    {
                        // Report error here
                        return;
                    }

                    WelcomeTitle = item.Title;


                });
            FrameUri = ViewModelLocator.IntroPageUri;
            
            //FrameUri = _navigationService.NavigateTo(ViewModelLocator.IntroPageUri);
           //_navigationService.NavigateTo(ViewModelLocator.IntroPageUri);
        }

        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}
    }
}