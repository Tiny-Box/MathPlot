using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MvvmLight1.Model;

using System.Windows.Input;

namespace MvvmLight1.ViewModel
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

        bool _CanClick;
        public bool CanClick
        {
            get { return _CanClick; }

            set
            {
                if (_CanClick == value)
                    return;

                _CanClick = value;

                RaisePropertyChanged("CanClick");

                // SL中需要手动调用RaiseCanExecuteChanged方法更新按钮可用s状态  
                CanExecuteCommand.RaiseCanExecuteChanged();

            }
        }  


        #region ICommand
        public ICommand SimpleCommand
        {
            get;
            private set;
        }
        public RelayCommand CanExecuteCommand
        {
            get;
            private set;
        }
        public RelayCommand<bool?> ParamCommand
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

            //SimpleCommand = new RelayCommand
            //    (
            //        () => WelcomeTitle = "执行简单命令"
            //    );
            SimpleCommand = new RelayCommand(OnButtonClick);

            CanExecuteCommand = new RelayCommand
            (
                () =>
                {
                    //CommandResult = "执行CanExecute命令";
                },
                () => CanClick  // 等价于()=>{return CanClick;}  
            );

            ParamCommand = new RelayCommand<bool?>
        (
            (p) =>
            {
                WelcomeTitle = string.Format("执行带参数的命令(参数值：{0})", p);
            },
            (p) => p ?? false
        );  

        }

        private void OnButtonClick()
        {
            WelcomeTitle = "Test" ;
        }  

        public override void Cleanup()
        {
            // Clean up if needed

            base.Cleanup();
        }

        
    }
}