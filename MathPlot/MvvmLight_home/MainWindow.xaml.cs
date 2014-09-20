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
            Messenger.Default.Register<LineData>(this, "Main",
                n =>
                {
                    tempData = n;
                }
            );
        }

        private LineData tempData = new LineData();
        
        public void plotax(object obj, RoutedEventArgs e)
        {

            Yaxis.plotY(10000, 1);
            Xaxis.plotX(10, 1);
            Xaxis.plotZ();
        }
        public void Clear(object obj, RoutedEventArgs e)
        {
            Xaxis.Clear();
            Yaxis.Clear();
        }
    }
}