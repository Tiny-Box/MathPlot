using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

using System.Windows;
using System.Windows.Input;

namespace MvvmLight_company.ViewModel
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

        public RelayCommand sendToMain
        {
            get;
            private set;
        }

        public RelayCommand sendToChild_s
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

        public RelayCommand<object> CloseCommand
        {
            get;
            private set;
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


        /// <summary>
        /// Initializes a new instance of the ChildViewModel class.
        /// </summary>
        public ChildViewModel()
        {

            #region
            sendToMain = new RelayCommand
            (
                    () =>
                    {
                        //System.Windows.Controls.PasswordBox pb = p as System.Windows.Controls.PasswordBox;

                        //bool isLogon = false;
                        //string isLogon = "ABC";

                        // 发送消息  
                        MessageBox.Show(SendStr);
                        Messenger.Default.Send<string>(SendStr,"Main");
                        
                    }
            );

            sendToChild_s = new RelayCommand
            (
                () =>
                {
                    MessageBox.Show(SendStr);
                    Messenger.Default.Send<string>(SendStr, "Child_s");
                }
            );

            CloseCommand = new RelayCommand<object>(o =>
            {
                MessageBox.Show("OK");
                ((Window)o).Close();

            });
            #endregion
        }
    }
}