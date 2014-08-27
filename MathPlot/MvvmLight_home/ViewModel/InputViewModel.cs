using GalaSoft.MvvmLight;

using MvvmLight_home.Model;

namespace MvvmLight_home.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class InputViewModel : ViewModelBase
    {
        private string _testStr = "vmTest";
        public string testStr
        {
            get
            {
                return _testStr;
            }
            set
            {
                _testStr = value;
                RaisePropertyChanged("testStr");
            }
        }

        /// <summary>
        /// Initializes a new instance of the InputViewModel class.
        /// </summary>
        public InputViewModel(IDataService dataService)
        {
            testStr = "abc";
        }
    }
}