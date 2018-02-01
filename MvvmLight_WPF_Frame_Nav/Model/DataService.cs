using System;

namespace MvvmLight_WPF_Frame_Nav.Model
{
    public class DataService : IDataService
    {
        public void GetData(Action<DataItem, Exception> callback)
        {
            // Use this to connect to the actual data service

            var item = new DataItem("Welcome to MVVM Light", "Screen 1 Text", "Screenie 2 here", "Screenda 3 now");
            callback(item, null);
        }
    }
}