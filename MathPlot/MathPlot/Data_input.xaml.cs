using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MathPlot.Models;

namespace MathPlot
{
    /// <summary>
    /// Data_input.xaml 的交互逻辑
    /// </summary>
    public partial class Data_input : Window
    {
        public Data_input(DataInput_VM ma)
        {
            InitializeComponent();

            this.DataContext = ma;
        }
    }
}
