using GalaSoft.MvvmLight;
using MvvmLight_WPF_Frame_Nav.Model;

namespace MvvmLight_WPF_Frame_Nav.ViewModel
{
    public class MiddleViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;
        
        //mvvminpcset

        /// <summary>
        /// The <see cref="Screen2Text" /> property's name.
        /// </summary>
        public const string Screen2TextPropertyName = "Screen2Text";

        private string _screen2Text = string.Empty;

        /// <summary>
        /// Sets and gets the Screen1Text property.
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
                Set(ref _screen2Text, value);
            }
        }

        /// <summary>
        /// Gets the view's ViewModel.
        /// </summary>
        public MiddleViewModel(IDataService dataService)
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

                    Screen2Text = item.Screen2;         // this is where you set the link to the data model.  item is DataItem Class, through dataservice above!
                });
        }



    }
}