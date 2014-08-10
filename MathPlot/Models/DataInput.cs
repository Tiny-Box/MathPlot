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
            this.PointList.Add(new Cruve_input { X = float.Parse(this.Xpoint), Y = float.Parse(this.Ypoint) });
        }
        public void Show(object obj)
        {
            MessageBox.Show(Xpoint);
        }

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
