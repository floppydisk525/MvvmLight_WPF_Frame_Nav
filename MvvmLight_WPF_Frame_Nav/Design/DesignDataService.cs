using System;
using MvvmLight_WPF_Frame_Nav.Model;

namespace MvvmLight_WPF_Frame_Nav.Design
{
    public class DesignDataService : IDataService
    {
        public void GetData(Action<DataItem, Exception> callback)
        {
            // Use this to create design time data

            var item = new DataItem("Welcome MJ MVVM Light [design]", "Screen-ola 1 Text DESIGN", "Screenie 2 DESIGN", "Screenda 3 now DESIGN");
            callback(item, null);
        }
    }
}