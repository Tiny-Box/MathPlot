using System;

namespace MvvmLight1.Model
{
    public class DataService : IDataService
    {
        public void GetData(Action<DataItem, Exception> callback)
        {
            // Use this to connect to the actual data service

            var item = new DataItem("Welcome to MVVM Light");
            callback(item, null);
        }

        //public void DealStr(Action<Text_test, Exception> callback)
        //{
        //    //test str

        //    var item = new Text_test
        //}
    }
}