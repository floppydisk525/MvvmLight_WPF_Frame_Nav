using System;
using MvvmLight_WPF_Frame_Nav.Model;

namespace MvvmLight_WPF_Frame_Nav.Design
{
    public class DesignDataService : IDataService
    {
        public void GetData(Action<DataItem, Exception> callback)
        {
            // Use this to create design time data

            var item = new DataItem("Welcome to MVVM Light [design]");
            callback(item, null);
        }
    }
}