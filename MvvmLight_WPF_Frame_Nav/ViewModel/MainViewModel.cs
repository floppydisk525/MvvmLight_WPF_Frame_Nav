using GalaSoft.MvvmLight;
using MvvmLight_WPF_Frame_Nav.Model;
using System;
using System.Windows.Controls;
using MvvmLight_WPF_Frame_Nav.Helpers;
using GalaSoft.MvvmLight.CommandWpf;

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
        //private readonly INavigationService _navigationService;
        
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

        #region Added properties from other viewmodels
        /// <summary>
        /// The <see cref="Screen1Text" /> property's name.
        /// </summary>
        public const string Screen1TextPropertyName = "Screen1Text";

        private string _screen1Text = string.Empty;

        /// <summary>
        /// Sets and gets the Screen1Text property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Screen1Text
        {
            get
            {
                return _screen1Text;
            }
            set
            {
                Set(ref _screen1Text, value);
            }
        }

        /// <summary>
        /// The <see cref="Screen2Text" /> property's name.
        /// </summary>
        public const string Screen2TextPropertyName = "Screen2Text";

        private string _screen2Text = string.Empty;

        /// <summary>
        /// Sets and gets the Screen2Text property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Screen2Text
        {
            get
            {
                return _screen2Text;
            }
            set
            {
                Set(Screen2TextPropertyName, ref _screen2Text, value);
            }
        }

        /// <summary>
        /// The <see cref="Screen3Text" /> property's name.
        /// </summary>
        public const string Screen3TextPropertyName = "Screen3Text";

        private string _screen3Text = string.Empty;

        /// <summary>
        /// Sets and gets the Screen3Text property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Screen3Text
        {
            get
            {
                return _screen3Text;
            }
            set
            {
                Set(Screen3TextPropertyName, ref _screen3Text, value);
            }
        }


        #endregion

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
                System.Diagnostics.Debug.WriteLine(_frameUri.ToString(), "_frameUri");
                System.Diagnostics.Debug.WriteLine(FrameUri.ToString(), "FrameUri");
            }
        }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        //public MainViewModel(IDataService dataService, INavigationService navigationService)
        public MainViewModel(IDataService dataService)
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
                    Screen1Text = item.Screen1;
                    Screen2Text = item.Screen2;
                    Screen3Text = item.Screen3;
                });
            
            FrameUri = ViewModelLocator.IntroPageUri;            
            
            //FrameUri = _navigationService.NavigateTo(ViewModelLocator.IntroPageUri);
            //_navigationService.NavigateTo(ViewModelLocator.IntroPageUri);
        }

        private RelayCommand _changeToIntroPage;

        /// <summary>
        /// Gets the ChangeToIntroPage.
        /// </summary>
        public RelayCommand ChangeToIntroPage
        {
            get
            {
                return _changeToIntroPage
                    ?? (_changeToIntroPage = new RelayCommand(
                    () =>
                    {
                        FrameUri = ViewModelLocator.IntroPageUri;                       
                    },
                    () =>   CheckUri(FrameUri, ViewModelLocator.IntroPageUri) ));      //FrameUri != ViewModelLocator.IntroPageUri          
            }
        }                

        private RelayCommand _changeToMiddlePage;

        /// <summary>
        /// Gets the ChangeToMiddlePage.
        /// </summary>
        public RelayCommand ChangeToMiddlePage
        {
            get
            {
                return _changeToMiddlePage ?? (_changeToMiddlePage = new RelayCommand(
                    ExecuteChangeToMiddlePage,
                    CanExecuteChangeToMiddlePage));
            }
        }

        private void ExecuteChangeToMiddlePage()
        {
            FrameUri = ViewModelLocator.MiddlePageUri;            
        }

        private bool CanExecuteChangeToMiddlePage()
        {
            return CheckUri(FrameUri, ViewModelLocator.MiddlePageUri);
            
            //if (FrameUri == ViewModelLocator.MiddlePageUri)            
            //{ return false; }
            //else
            //{ return true; }            
        }
        
        private RelayCommand _changeToLastPage;

        /// <summary>
        /// Gets the ChangeToLastPage.
        /// </summary>
        public RelayCommand ChangeToLastPage
        {
            get
            {
                return _changeToLastPage
                    ?? (_changeToLastPage = new RelayCommand(
                    () =>
                    {
                        FrameUri = ViewModelLocator.LastPageUri;                       
                    },
                () => CheckUri(FrameUri, ViewModelLocator.LastPageUri) ));                
            }
        }

        private Boolean CheckUri(Uri _frameUriToCheck, Uri _vmUri)
        {
            string StringUriToCheck = _frameUriToCheck.ToString();
            string StringUriVM = _vmUri.ToString();
            System.Diagnostics.Debug.WriteLine(StringUriToCheck, "StringUriToCheck");
            System.Diagnostics.Debug.WriteLine(StringUriVM, "StringUriVM");

            if (StringUriVM.Contains(StringUriToCheck))
            { return false; }
            else
            { return true; }
        }

        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}
    }
}