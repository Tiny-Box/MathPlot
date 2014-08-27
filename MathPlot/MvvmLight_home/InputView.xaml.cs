using System.Windows;

namespace MvvmLight_home
{
    /// <summary>
    /// Description for InputView.
    /// </summary>
    public partial class InputView : Window
    {
        /// <summary>
        /// Initializes a new instance of the InputView class.
        /// </summary>
        public InputView()
        {
            InitializeComponent();
        }

        private void Rectangle_MouseLeftButtonDown_1(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}