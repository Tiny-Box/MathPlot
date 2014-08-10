using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathPlot.Models;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace MathPlot
{
    public class DataInput_VM:INotifyPropertyChanged
    {
        public DataInput Inputmodel { get; set; }
        public DelegateCommand Add { get; set; }
        public DelegateCommand Show { get; set; }
        

        public DataInput_VM()
        {
            
            Inputmodel = new DataInput();
            this.Add = new DelegateCommand();
            this.Add.ExecuteCommand = new Action<object>(this.Inputmodel.Add);
            //this.Show = new DelegateCommand();
            //this.Show.ExecuteCommand = new Action<object>(this.Inputmodel.Show);
            



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
