using System.Windows;
using MvvmLightMessenger.WPF4.ViewModel;

namespace MvvmLightMessenger.WPF4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Closing += (s, e) => ViewModelLocator.Cleanup();
        }
    }
}
