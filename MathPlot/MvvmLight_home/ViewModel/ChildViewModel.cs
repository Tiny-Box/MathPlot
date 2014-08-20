using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

using System.Windows;

namespace MvvmLight_home.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class ChildViewModel : ViewModelBase
    {

        #region ICommand

        public RelayCommand LoginCommand
        {
            get;
            private set;
        }

        public RelayCommand CancelCommand
        {
            get
            {
                return new RelayCommand(
                    () =>
                    {
                        // 发送消息  
                        Messenger.Default.Send<bool?>(null);
                    }
                    );
            }
        }  
        #endregion

        private string _sendStr = "ABC";
        public string SendStr
        {
            get
            {
                return _sendStr;
            }
            set
            {
                if (_sendStr == value)
                {
                    return;
                }
                _sendStr = value;
                RaisePropertyChanged("SendStr");
            }
        }

        #region close Command
        public RelayCommand<CancelEventArgs> OnClosingCommand { get; set; }
        #endregion

        /// <summary>
        /// Initializes a new instance of the ChildViewModel class.
        /// </summary>
        public ChildViewModel()
        {

            #region
            LoginCommand = new RelayCommand
            (
                    () =>
                    {
                        //System.Windows.Controls.PasswordBox pb = p as System.Windows.Controls.PasswordBox;

                        //bool isLogon = false;
                        //string isLogon = "ABC";

                        // 发送消息  
                        MessageBox.Show(SendStr);
                        Messenger.Default.Send<string>(SendStr);
                        
                    }
            );
            #endregion

            #region close
            this.OnClosingCommand = new RelayCommand<CancelEventArgs>(this.OnClosingCommandExecuted);
            #endregion
        }

        #region close method
        private void OnClosingCommandExecuted(SessionEndingCancelEventArgs cancelEventArgs)
        {
            if (mustCancelClosing)
            {
                cancelEventArgs.Cancel = true;
            }
        }
        #endregion
    }
}