using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

using System;

namespace MvvmLightMessenger.WPF4.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm/getstarted
    /// </para>
    /// </summary>
    public class DialogViewModelBase : ViewModelBase
    {
        #region Fields
        protected RelayCommand _okCommand;
        protected RelayCommand _cancleCommand;
        #endregion // Fields

        public RelayCommand OKCommand 
        {
            get
            {
                if (_okCommand == null)
                {
                    _okCommand = new RelayCommand(
                        () => this.DoOK()
                        );
                }
                return _okCommand;
            }
        }
        public RelayCommand CancleCommand 
        {
            get
            {
                if (_cancleCommand == null)
                {
                    _cancleCommand = new RelayCommand(
                        () =>
                        {
                            // 点击取消关闭对话框，
                            CloseDialog();
                        }
                        );
                }
                return _cancleCommand;
            }
        }

        public Guid MessageID
        {
            get;
            private set;
        }


        /// <summary>
        /// Initializes a new instance of the DialogViewModel class.
        /// </summary>
        public DialogViewModelBase()
        {
            // 创建唯一的消息标识，用以与宿主ViewModel进行交互
            MessageID = Guid.NewGuid();
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real": Connect to service, etc...
            ////}

        }

        protected System.Windows.Visibility _dialogVisibility = System.Windows.Visibility.Collapsed;
        public System.Windows.Visibility DialogVisibility
        {
            get { return _dialogVisibility; }
            set
            {
                if (value == _dialogVisibility)
                    return;

                _dialogVisibility = value;

                base.RaisePropertyChanged("DialogVisibility");
            }
        }

        protected void CloseDialog()
        {
            // 点击取消关闭对话框，
            this.DialogVisibility = System.Windows.Visibility.Collapsed;
        }

        protected Action<string> messageCallback;

        protected virtual void DoOK()
        {
            // 消息内容包含回调函数messageCallback，在必要时进行调用
            NotificationMessageAction<string> notification
              = new NotificationMessageAction<string>(this, "OK", messageCallback);

            // 发送确定消息给消息的载体
            Messenger.Default.Send<NotificationMessageAction<string>>(notification, MessageID);
        }

        public override void Cleanup()
        {
            // Clean own resources if needed

            base.Cleanup();
        }
    }
}