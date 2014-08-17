using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvvmLight1.Model
{
    class Text_test
    {
        public Text_test(string title)
        {
            Title = title;
        }

        public string Title
        {
            get;
            private set;
        }
    }
}
