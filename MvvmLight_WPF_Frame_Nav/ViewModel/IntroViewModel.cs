using GalaSoft.MvvmLight;
using MvvmLight_WPF_Frame_Nav.Model;

namespace MvvmLight_WPF_Frame_Nav.ViewModel
{
    public class IntroViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;


        //mvvminpcset

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

        /// <summary>
        /// Gets the view's ViewModel.
        /// </summary>
        public IntroViewModel(IDataService dataService)
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

                    Screen1Text = item.Screen1;         // this is where you set the link to the data model.  item is DataItem Class, through dataservice above!
                    Screen2Text = item.Screen2;
                    Screen3Text = item.Screen3;
                });
        }
    }
}