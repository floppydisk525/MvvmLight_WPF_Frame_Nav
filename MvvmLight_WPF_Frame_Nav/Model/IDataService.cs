using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvvmLight_WPF_Frame_Nav.Model
{
    public interface IDataService
    {
        void GetData(Action<DataItem, Exception> callback);
    }
}
