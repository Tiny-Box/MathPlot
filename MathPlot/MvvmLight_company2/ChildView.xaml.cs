using System.Windows;

using MvvmLight_company2.ViewModel;

namespace MvvmLight_company2
{
    /// <summary>
    /// Description for ChildView.
    /// </summary>
    public partial class ChildView : Window
    {
        /// <summary>
        /// Initializes a new instance of the ChildView class.
        /// </summary>
        public ChildView(ChildViewModel ma)
        {
            InitializeComponent();
            this.DataContext = ma;
        }

        private void Rectangle_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}