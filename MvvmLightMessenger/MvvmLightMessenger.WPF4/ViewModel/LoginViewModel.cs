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
    public class LoginViewModel : ViewModelBase
    {
        #region ICommand

        public RelayCommand<object> LoginCommand
        {
            get 
            {
                return new RelayCommand<object>(
                    (p) => 
                    {
                        System.Windows.Controls.PasswordBox pb = p as System.Windows.Controls.PasswordBox;

                        bool isLogon = false;

                        // 登录成功
                        if (_userName == "admin" && pb.Password == "123")
                            isLogon = true;
                        else
                            isLogon = false;
                        
                        // 发送消息
                        Messenger.Default.Send<bool?>(isLogon); 
                    }
                    ); 
            }
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

        #region 公共属性
        public const string UserNamePropertyName = "UserName";

        private string _userName = "";

        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                if (_userName == value)
                {
                    return;
                }

                _userName = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(UserNamePropertyName);
            }
        }
        #endregion

        /// <summary>
        /// Initializes a new instance of the LoginViewModel class.
        /// </summary>
        public LoginViewModel()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real": Connect to service, etc...
            ////}
        }

        ////public override void Cleanup()
        ////{
        ////    // Clean own resources if needed

        ////    base.Cleanup();
        ////}
    }
}