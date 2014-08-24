using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GalaSoft.MvvmLight.Command;

namespace MvvmLight_home.Model
{
    static class MyCommands
    {
        public static readonly RelayCommand<object> Close = new RelayCommand<object>
            (o =>
                {
                    ((Window)o).Close();
                }
            );
    }
}
