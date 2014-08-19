using GalaSoft.MvvmLight;
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
    public class MessageBoxViewModel : DialogViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MessageBoxViewModel class.
        /// </summary>
        public MessageBoxViewModel()
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

        protected override void DoOK()
        {
            // 初始化消息回调方法
            this.messageCallback = s =>
            {
                // 执行完成则关闭对话框，执行错误，则显示错误信息
                if (string.IsNullOrEmpty(s))
                {
                    CloseDialog();
                    return;
                }

                Content = s;
            };

            base.DoOK();
        }
        

        public const string ContentPropertyName = "Content";
        private string _content;

        public string Content
        {
            get
            {
                return _content;
            }

            set
            {
                if (_content == value)
                {
                    return;
                }
                _content = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(ContentPropertyName);
            }
        }
        
    }
}