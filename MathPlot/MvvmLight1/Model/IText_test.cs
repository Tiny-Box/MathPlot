using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvvmLight1.Model
{
    interface IText_test
    {
        void GetTest(Action<Text_test, Exception> callback);
    }
}
