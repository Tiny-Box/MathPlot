using System.Windows.Media;
using System.Windows;
using System.Windows.Input;

using MvvmLight_home.ViewModel;
using MvvmLight_home.Model;

using GalaSoft.MvvmLight.Messaging;

namespace MvvmLight_home
{
    /// <summary>
    /// This application's main window.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the MainWindow class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            Closing += (s, e) => ViewModelLocator.Cleanup();
            Messenger.Default.Register<ArgvL>(this, "MainV",
                n =>
                {
                    tempArgv = n;
                }
            );
        }

        private ArgvL tempArgv = new ArgvL();
        
        public void plotax(object obj, RoutedEventArgs e)
        {
            if (tempArgv.xmin != tempArgv.xmax)
            {
                axis.plotY(tempArgv.ymax, tempArgv.ymin);
                axis.plotX(tempArgv.xmax, tempArgv.xmin);
                axis.plotZ();
            }
            else
            {
                MessageBox.Show("请先输入参数。");
            }

        }
        public void Clear(object obj, RoutedEventArgs e)
        {
            axis.Clear();
        }
    }
}