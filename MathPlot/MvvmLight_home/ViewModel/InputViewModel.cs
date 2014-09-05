using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

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

        #region Value

        
        public LineData line { get; set; }

        private string _x;
        public string x
        {
            get
            { 
                return _x;
            }
            set
            {
                _x = value;
                RaisePropertyChanged("x");
            }
        }

        private string _y;
        public string y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
                RaisePropertyChanged("y");
            }
        }
        #endregion

        #region Method
        public void Add()
        {
            try
            {
                if (line.Line.Count != 0)
                {
                    line.newPoint(double.Parse(x), double.Parse(y));
                }
                else
                {
                    line.StartPoint = new Point(double.Parse(x), double.Parse(y));
                    line.newPoint(double.Parse(x), double.Parse(y));
                }
              
            }
            catch(Exception)
            {
                MessageBox.Show("请输入数字！");
            }
        }

        public void Delete()
        {
            if (line.Line.Count != 0)
            {
                line.Line.RemoveAt(line.Line.Count - 1);
            }
        }
        #endregion

        #region ICommand
        public RelayCommand add
        {
            get;
            private set;
        }
        public RelayCommand delete
        {
            get;
            private set;
        }
        public RelayCommand<object> close
        {
            get;
            private set;
        }
        #endregion

        /// <summary>
        /// Initializes a new instance of the InputViewModel class.
        /// </summary>
        public InputViewModel(IDataService dataService)
        {
            
            this.line = new LineData();
            this.line.Line = new ObservableCollection<Point>();
            
            testStr = "abc";
            add = new RelayCommand
            (
                () =>
                {
                    Add();
                }
            );
            delete = new RelayCommand
            (
                () =>
                {
                    Delete();
                }
            );
            close = new RelayCommand<object>
            (o =>
            {
                
                Messenger.Default.Send<LineData>(line, "Main");
                ((Window)o).Close();
            }
            );
        }
    }
}