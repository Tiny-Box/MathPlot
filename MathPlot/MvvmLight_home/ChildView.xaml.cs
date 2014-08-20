﻿using System.Windows;
using MvvmLight_home.ViewModel;

namespace MvvmLight_home
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
            Closing += (s, e) => ViewModelLocator.Cleanup();
        }
    }
}