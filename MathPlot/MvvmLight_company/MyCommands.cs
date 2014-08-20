using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows;

using GalaSoft.MvvmLight.Command;   

namespace MvvmLight_company
{
    class MyCommands
    {
        public static readonly RelayCommand<object> CloseCommand =
        new RelayCommand<object>(o => ((Window)o).Close());

        
    }
}
