using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

using System;
using System.Windows.Input;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Windows.Threading;
using System.Windows;
using System.Linq;
using System.Windows.Media.Imaging;

using MvvmLightCommand.SL4.TriggerActions;

namespace MvvmLightCommand.SL4.ViewModel
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
    public class MainViewModel : ViewModelBase
    {

        #region View中要显示的绑定属性
        string _CommandResult;
        public string CommandResult
        {
            get { return _CommandResult; }

            set
            {
                if (_CommandResult == value)
                    return;

                _CommandResult = value;

                RaisePropertyChanged("CommandResult");
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

                CanExecuteCommand.RaiseCanExecuteChanged();

            }
        }
        #endregion

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

        public RelayCommand<string> BehaviourCommand
        {
            get;
            private set;
        }

        public ICommand MoveMouseCommand
        {
            get;
            private set;
        }

        public RelayCommand<EventInformation<RoutedEventArgs>> CustomBehaviorCommand
        {
            get;
            private set;
        }
        #endregion

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            SimpleCommand = new RelayCommand
                (
                    () => CommandResult = "执行简单命令"
                );

            CanExecuteCommand = new RelayCommand
               (
                   () =>
                   {
                       CommandResult = "执行CanExecute命令";
                   },
                   () => CanClick // 等价于()=>{return CanClick;}
               );

            ParamCommand = new RelayCommand<bool?>
                (
                    (p) =>
                    {
                        CommandResult = string.Format("执行带参数的命令(参数值：{0})", p);
                    },
                    (p) => p??false
                );

            BehaviourCommand = new RelayCommand<string>
               (
                   (p) =>
                   {
                       CommandResult = string.Format("执行TextChanged命令,触发命令的TextBox值为{0}",p);
                   },
                   (p) => 
                   { 
                       return !string.IsNullOrEmpty(p); 
                   }
               );

            MoveMouseCommand = new RelayCommand<MouseEventArgs>
                (
                    (e) => 
                        {
                            var element = e.OriginalSource as UIElement;
                            var point = e.GetPosition(element);

                            CommandResult = string.Format("执行带MouseEventArgs事件参数的命令,鼠标位置:X-{0}，Y-{1}",point.X,point.Y);
                        }
                );

            CustomBehaviorCommand = new RelayCommand<EventInformation<RoutedEventArgs>>
              (
                  (ei) =>
                  {
                      EventInformation<RoutedEventArgs> eventInfo = ei as EventInformation<RoutedEventArgs>;

                      System.Windows.Controls.TextBox sender = eventInfo.Sender as System.Windows.Controls.TextBox;

                      CommandResult = string.Format("执行{0}的TextChanged命令,文本框的值：{1},传递的参数：{2}，事件参数：{3}",
                          sender.Name,
                          sender.Text,
                          ei.CommandArgument,
                          ei.EventArgs.GetType().ToString());
                  },
                  (ei) =>
                  {
                      return true;
                  }
              );


            if (IsInDesignMode)
            {
                // Code runs in Blend --> create design time data.
            }
            else
            {
                // Code runs "for real": Connect to service, etc...
            }
        }

        public override void Cleanup()
        {
            // Clean own resources if needed

            base.Cleanup();
        }
    }
}