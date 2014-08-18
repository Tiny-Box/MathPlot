﻿/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:MvvmLightCommand.SL4.ViewModel"
                                   x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"
*/

namespace MvvmLightCommand.SL4.ViewModel
{
        /// <summary>
        /// This class contains static references to all the view models in the
        /// application and provides an entry point for the bindings.
        /// <para>
        /// Use the <strong>mvvmlocatorproperty</strong> snippet to add ViewModels
        /// to this locator.
        /// </para>
        /// <para>
        /// In Silverlight and WPF, place the ViewModelLocator in the App.xaml resources:
        /// </para>
        /// <code>
        /// &lt;Application.Resources&gt;
        ///     &lt;vm:ViewModelLocator xmlns:vm="clr-namespace:MvvmLightCommand.SL4.ViewModel"
        ///                                  x:Key="Locator" /&gt;
        /// &lt;/Application.Resources&gt;
        /// </code>
        /// <para>
        /// Then use:
        /// </para>
        /// <code>
        /// DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"
        /// </code>
        /// <para>
        /// You can also use Blend to do all this with the tool's support.
        /// </para>
        /// <para>
        /// See http://www.galasoft.ch/mvvm/getstarted
        /// </para>
        /// </summary>
        public class ViewModelLocator
        {
            /// <summary>
            /// Initializes a new instance of the ViewModelLocator class.
            /// </summary>
            public ViewModelLocator()
            {
                ////if (ViewModelBase.IsInDesignModeStatic)
                ////{
                ////    // Create design time view models
                ////}
                ////else
                ////{
                ////    // Create run time view models
                ////}

                CreateMain();
            }

            public static void Cleanup()
            {
                // TODO Clear the ViewModels
            }

            #region MainViewModel
            private static MainViewModel _main;

            /// <summary>
            /// Gets the Main property.
            /// </summary>
            public static MainViewModel MainStatic
            {
                get
                {
                    if (_main == null)
                    {
                        CreateMain();
                    }

                    return _main;
                }
            }

            /// <summary>
            /// Gets the Main property.
            /// </summary>
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
                "CA1822:MarkMembersAsStatic",
                Justification = "This non-static member is needed for data binding purposes.")]
            public MainViewModel Main
            {
                get
                {
                    return MainStatic;
                }
            }

            /// <summary>
            /// Provides a deterministic way to delete the Main property.
            /// </summary>
            public static void ClearMain()
            {
                _main.Cleanup();
                _main = null;
            }

            /// <summary>
            /// Provides a deterministic way to create the Main property.
            /// </summary>
            public static void CreateMain()
            {
                if (_main == null)
                {
                    _main = new MainViewModel();
                }
            }

            #endregion
        }
}