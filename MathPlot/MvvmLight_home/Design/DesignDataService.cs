using System;
using MvvmLight_home.Model;

namespace MvvmLight_home.Design
{
    public class DesignDataService 
    {
        public void GetData(Action<DataItem, Exception> callback)
        {
            // Use this to create design time data

            var item = new DataItem("Welcome to MVVM Light [design]");
            callback(item, null);
        }
    }
}