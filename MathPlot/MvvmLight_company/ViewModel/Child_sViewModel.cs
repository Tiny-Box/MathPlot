using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;

namespace MvvmLight_company.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class Child_sViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the Child_sViewModel class.
        /// </summary>
        private string _testStr = "efg";
        public string TestStr
        {
            get
            {
                return _testStr;
            }
            set
            {
                _testStr = value;
                RaisePropertyChanged("TestStr");
            }
        }

        public Child_sViewModel()
        {
            Messenger.Default.Register<string>(this,"Child_s",
                        n =>
                        {
                            TestStr = n;
                        }
            );
        }
    }
}