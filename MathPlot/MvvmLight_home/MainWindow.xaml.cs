using System.Windows.Media;
using System.Windows;
using System.Windows.Input;
using MvvmLight_home.ViewModel;

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
        }

        private Pen drawingPen = new Pen(Brushes.SteelBlue, 3);
        private Size squareSize = new Size(30, 30);

        private void plottest(DrawingVisual visual, Point topLeftCorner, bool isSelected)
        {
            using (DrawingContext dc = visual.RenderOpen())
            {
                Brush brush = Brushes.Black;
                dc.DrawRectangle(brush, drawingPen, new Rect(topLeftCorner, squareSize));
            }
        }

        public void plotax(object obj, RoutedEventArgs e)
        {

            Yaxis.plotY();
            Xaxis.plotX();
            Xaxis.plotZ();
        }
        public void Clear(object obj, RoutedEventArgs e)
        {
            Xaxis.Clear();
            Yaxis.Clear();
        }
    }
}