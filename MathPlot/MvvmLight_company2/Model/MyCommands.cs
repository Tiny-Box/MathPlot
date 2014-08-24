using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

using GalaSoft.MvvmLight.Command;

namespace MvvmLight_company2.Model
{
    static class MyCommands
    {
        public static readonly RelayCommand<object> Close = new RelayCommand<object>(o =>
        {
            ((Window)o).Close();
        }
            );

    }
}
