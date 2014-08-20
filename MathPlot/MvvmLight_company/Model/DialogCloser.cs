using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using MvvmLight_company;

namespace MvvmLight_company.Model
{
    class DialogCloser
    {
        public static readonly DependencyProperty DialogResultProperty =
            DependencyProperty.RegisterAttached(
                "DialogResult",
                typeof(bool?),
                typeof(DialogCloser),
                new PropertyMetadata(DialogResultChanged));

        private static void DialogResultChanged(
            DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            var window = d as ChildView;
            if (window != null)
                window.DialogResult = e.NewValue as bool?;
        }
        public static bool? GetDialogResult(DependencyObject dp)
        {
            return (bool?)dp.GetValue(DialogResultProperty);
        }
        public static void SetDialogResult(DependencyObject target, bool? value)
        {
            target.SetValue(DialogResultProperty, value);
        }
    }
}
