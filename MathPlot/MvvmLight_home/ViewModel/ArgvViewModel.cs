using System;
using System.Windows;
using System.Windows.Media;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

using MvvmLight_home.Model;

namespace MvvmLight_home.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class ArgvViewModel : ViewModelBase
    {
        #region Argv 参数
        public ArgvL lineArgv = new ArgvL();

        public string Title
        {
            get
            {
                return lineArgv.title;
            }
            set
            {
                lineArgv.title = value;
                RaisePropertyChanged("Title");
            }
        }
        public string Xmin
        {
            get
            {
                return lineArgv.xmin.ToString();
            }
            set
            {
                try
                {
                    lineArgv.xmin = double.Parse(value);
                    RaisePropertyChanged("Xmin");
                }
                catch(Exception)
                {
                    MessageBox.Show("请输入数字！");
                }
            }
        }
        public string Xmax
        {
            get
            {
                return lineArgv.xmax.ToString();
            }
            set
            {
                try
                {
                    lineArgv.xmax = double.Parse(value);
                    RaisePropertyChanged("Xmax");
                }
                catch (Exception)
                {
                    MessageBox.Show("请输入数字！");
                }
            }
        }
        public string Ymin
        {
            get
            {
                return lineArgv.ymin.ToString();
            }
            set
            {
                try
                {
                    lineArgv.ymin = double.Parse(value);
                    RaisePropertyChanged("Ymin");
                }
                catch (Exception)
                {
                    MessageBox.Show("请输入数字！");
                }
            }
        }
        public string Ymax
        {
            get
            {
                return lineArgv.ymax.ToString();
            }
            set
            {
                try
                {
                    lineArgv.ymax = double.Parse(value);
                    RaisePropertyChanged("Ymax");
                }
                catch (Exception)
                {
                    MessageBox.Show("请输入数字！");
                }
            }
        }
        #endregion


        public string color
        {
            get
            {
                return lineArgv.color.ToString();
            }
            set
            {
                lineArgv.color = (Color)ColorConverter.ConvertFromString(value.Split(' ')[1]);;
            }
            //get;
            //set;
        }
        #region ICommand
        public RelayCommand<object> OK
        {
            get;
            set;
        }
        public RelayCommand<object> drag
        {
            get;
            private set;
        }
        #endregion
        /// <summary>
        /// Initializes a new instance of the ArgvViewModel class.
        /// </summary>
        public ArgvViewModel()
        {
            OK = new RelayCommand<object>
                (
                    (o) =>
                    {
                        Messenger.Default.Send<ArgvL>(lineArgv, "Main");
                        ((Window)o).Close();
                    }
                );

            drag = new RelayCommand<object>
           (
               o =>
               {
                   ((Window)o).DragMove();
               }
           );
        }
    }
}