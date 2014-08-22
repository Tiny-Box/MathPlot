using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;


namespace MvvmLight_company2.ViewModel
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

        public RelayCommand Plot
        {
            get;
            private set;
        }


        
        #endregion

        private Point _startPoint = new Point(10, 50);
        public Point StartPoint
        {
            get
            {
                return _startPoint;
            }
            set
            {
                _startPoint = value;
                RaisePropertyChanged("startPoint");
            }
        }
        private Point _endPoint = new Point(200, 70);
        public Point EndPoint
        {
            get
            {
                return _endPoint;
            }
            set
            {
                _endPoint = value;
                RaisePropertyChanged("EndPoint");
            }
        }

        private string _sendStr = "LightBlue";
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

        public Border _pannel;
        public Border exampleBorder
        {
            get
            {
                return _pannel;
            }
            set
            {
                if (_pannel == value)
                {
                    return;
                }
                _pannel = value;
                RaisePropertyChanged("exampleBorder");
            }
        }
        private Image _anImage;
        public Image anImage
        {
            get
            {
                return _anImage;
            }
            set
            {
                if (_anImage == value)
                {
                    return;
                }
                _anImage = value;
                RaisePropertyChanged("anImage");
            }
        }

        #region Method
        void PlotLine()
        {
            StartPoint = new Point(10, 100);
            EndPoint = new Point(200, 120);

        }
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

            Plot = new RelayCommand
            (
                () =>
                {
                    MessageBox.Show("OK");
                    PlotLine();
                }
            );
            
            #endregion
        }
    }
}