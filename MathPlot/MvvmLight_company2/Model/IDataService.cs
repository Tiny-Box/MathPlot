using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvvmLight_company2.Model
{
    public interface IDataService
    {
        void GetData(Action<DataItem, Exception> callback);
    }
}
