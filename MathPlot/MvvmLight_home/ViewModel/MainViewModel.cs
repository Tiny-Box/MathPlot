using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MvvmLight_home.Model;

using System.Windows;

namespace MvvmLight_home.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;

        /// <summary>
        /// The <see cref="WelcomeTitle" /> property's name.
        /// </summary>
        public const string WelcomeTitlePropertyName = "WelcomeTitle";

        private string _welcomeTitle = string.Empty;

        /// <summary>
        /// Gets the WelcomeTitle property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string WelcomeTitle
        {
            get
            {
                return _welcomeTitle;
            }

            set
            {
                if (_welcomeTitle == value)
                {
                    return;
                }

                _welcomeTitle = value;
                RaisePropertyChanged(WelcomeTitlePropertyName);
            }
        }

        private string _testStr = "abc";

        public string TestStr
        {
            get
            {
                return _testStr;
            }

            set
            {
                if (_testStr == value)
                {
                    return;
                }

                _testStr = value;
                RaisePropertyChanged("TestStr");
            }
        }


        #region ICommand
        public RelayCommand ReciveCommand
        {
            get;
            private set;
        }

        public RelayCommand<string> BehaviourCommand
        {
            get;
            private set;
        }

        
       
        #endregion

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IDataService dataService)
        {
            _dataService = dataService;
            _dataService.GetData(
                (item, error) =>
                {
                    if (error != null)
                    {
                        // Report error here
                        return;
                    }

                    WelcomeTitle = item.Title;
                });

            BehaviourCommand = new RelayCommand<string>
           (
               (p) =>
               {
                   ChildView Child = new ChildView();
                   Child.Show();
               },
               (p) =>
               {
                   return !string.IsNullOrEmpty(p);
               }
           );  

            ReciveCommand = new RelayCommand
            (
                () =>
                    {
                        Messenger.Default.Register<string>(this,
                            n =>
                            {
                                MessageBox.Show(n);
                            }
                    );
                    }
            );
        }

        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}
    }
}