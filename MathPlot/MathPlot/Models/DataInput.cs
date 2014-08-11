using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows;

namespace MathPlot.Models
{
    public class DataInput : INotifyPropertyChanged
    {
        public ObservableCollection<Cruve_input> PointList { get; set; }

        public DataInput()
        {
            this.PointList = new ObservableCollection<Cruve_input>();
        }

        private string _xpoint;
        public string Xpoint
        {
            get { return _xpoint; }
            set
            {
                _xpoint = value;
                this.RaisePropertyChanged("Xpoint");   
            }
        }

        private string _ypoint;
        public string Ypoint
        {
            get { return _ypoint; }
            set
            {
                _ypoint = value;
                this.RaisePropertyChanged("Ypoint");
            }
        }

        public void Add(object obj)
        {
            try
            {
                this.PointList.Add(new Cruve_input { X = float.Parse(this.Xpoint), Y = float.Parse(this.Ypoint) });
            }
            catch (Exception e)
            {
                MessageBox.Show("请输入数字！");
            }
        }
        public void Delete(object obj)
        {
            if (PointList.Count != 0)
            {
                this.PointList.RemoveAt(PointList.Count - 1);
            }
            
        }
        //public void Show(object obj)
        //{
        //    MessageBox.Show(Xpoint);
        //}

        //public string Error
        //{
        //    get { return ""; }
        //}

        //public string this[string columnName]
        //{
        //    get
        //    {
        //        if (columnName == "Xpoint")
        //        {
        //            if (float.Parse(_xpoint) < 18)
        //            {
        //                return "年龄必须在18岁以上。";
        //            }
        //        }
        //        return string.Empty;
        //    }
        //}  

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }


    }
}
