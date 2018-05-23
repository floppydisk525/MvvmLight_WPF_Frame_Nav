using GalaSoft.MvvmLight;
using MvvmLight_WPF_Frame_Nav.Model;
using GalaSoft.MvvmLight.Ioc;

namespace MvvmLight_WPF_Frame_Nav.ViewModel
{
    public class LastViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;


        //mvvminpcset

        /// <summary>
        /// The <see cref="Screen3Text" /> property's name.
        /// </summary>
        public const string Screen3TextPropertyName = "Screen3Text";

        private string _screen3Text = string.Empty;

        /// <summary>
        /// Sets and gets the Screen1Text property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Screen3Text
        {
            get
            {
                System.Diagnostics.Debug.WriteLine("Screen 3 GET Text Property");
                return _screen3Text;
            }
            set
            {
                System.Diagnostics.Debug.WriteLine("Screen 3 SET Text Property");
                Set(ref _screen3Text, value);       
            }
        }

        /// <summary>
        /// Gets the view's ViewModel.
        /// </summary>
        public LastViewModel(IDataService dataService)
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

                    Screen3Text = item.Screen3;         // this is where you set the link to the data model.  item is DataItem Class, through dataservice above!
                });

            var result1 = SimpleIoc.Default.GetInstance<IDataService>("single");
            result1.GetData(
                (item, error) =>
                {
                    if (error != null)
                    {
                        // Report error here
                        return;
                    }

                    //Screen1Text = item.Screen1;         // this is where you set the link to the data model.  item is DataItem Class, through dataservice above!
                    //Screen2Text = item.Screen2;
                    Screen3Text = item.Screen3;
                });
        }
    }
}