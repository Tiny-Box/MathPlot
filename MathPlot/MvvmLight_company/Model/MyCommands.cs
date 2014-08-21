using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

using GalaSoft.MvvmLight.Command;

namespace MvvmLight_company.Model
{
    class MyCommands
    {
        public static readonly RelayCommand<object> Close = new RelayCommand<object>(o =>
            {
                ((Window)o).Close();
            }
            );

    }
}
