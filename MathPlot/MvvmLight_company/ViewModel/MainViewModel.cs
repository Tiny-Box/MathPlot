using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

using MvvmLight_company.ViewModel;
using MvvmLight_company.Model;
using MvvmLight_company;

using System.Windows;

namespace MvvmLight_company.ViewModel
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
       

        /// <summary>
        /// Gets the WelcomeTitle property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
      

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
            

            BehaviourCommand = new RelayCommand<string>
           (
               (p) =>
               {
                   ChildView Child = new ChildView();
                   Child.Show();
                   ChildView_s Child_s = new ChildView_s();
                   Child_s.Show();
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
                    MessageBox.Show("OK!");
                    
               
                }
            );
            Messenger.Default.Register<string>(this,"Main",
                        n =>
                        {
                            TestStr = n;
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