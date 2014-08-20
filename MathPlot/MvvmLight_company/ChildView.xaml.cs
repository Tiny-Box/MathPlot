using System.Windows;
using MvvmLight_company.ViewModel;

namespace MvvmLight_company
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
    }
}