using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvvmLight1.Model
{
    class TextService:IText_test
    {
        public void GetTest(Action<Text_test, Exception> callback)
        {
            // Use this to connect to the actual data service

            var item = new Text_test("Welcome to MVVM Light");
            callback(item, null);
        }
    }
}
