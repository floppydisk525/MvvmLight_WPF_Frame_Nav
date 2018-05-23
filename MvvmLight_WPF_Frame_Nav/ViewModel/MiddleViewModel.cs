using GalaSoft.MvvmLight;
using MvvmLight_WPF_Frame_Nav.Model;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;

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
                System.Diagnostics.Debug.WriteLine("Screen 2 Text GET Property");
                return _screen2Text;
            }
            set
            {
                System.Diagnostics.Debug.WriteLine("Screen 2 Text SET Property");
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

            //var result1 = SimpleIoc.Default.GetInstance<IDataService>("single");
            //result1.GetData(
            //    (item, error) =>
            //    {
            //        if (error != null)
            //        {
            //            // Report error here
            //            return;
            //        }

            //        //Screen1Text = item.Screen1;         // this is where you set the link to the data model.  item is DataItem Class, through dataservice above!
            //        Screen2Text = item.Screen2;
            //        //Screen3Text = item.Screen3;
            //    });

            Messenger.Default.Register<IDataService>(
                this,
                message =>
                {
                    message.GetData(
                        (item, error) =>
                        {
                            if (error != null)
                            {
                                // Report error here
                                return;
                            }

                            Screen2Text = item.Screen2;         // this is where you set the link to the data model.  item is DataItem Class, through dataservice above!
                        });
                });
        }
    }
}