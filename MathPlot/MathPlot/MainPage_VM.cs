using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows;
using MathPlot.Models;

namespace MathPlot
{
    class MainPage_VM
    {

        #region 坐标轴标签
        private string xlabel;
        public string Xlabel
        {
            get { return xlabel; }
            set
            {
                xlabel = value;
                RaisePropertyChanged("Xlabel");
            }
        }

        private string ylabel;
        public string Ylabel
        {
            get { return ylabel; }
            set
            {
                ylabel = value;
                RaisePropertyChanged("Ylabel");
            }
        }
        #endregion

        #region 菜单一
        public DelegateCommand OpenExcel { get; set; }
        public FileClass menuitem_one { get; set; }

        public DelegateCommand OpenInput { get; set; }
        
        
        #endregion


        public MainPage_VM()
        {
            #region 菜单一
            this.menuitem_one = new FileClass();
            this.OpenExcel = new DelegateCommand();
            this.OpenExcel.ExecuteCommand =  new Action<object>(this.menuitem_one.OpenExcel);
            
            
            this.OpenInput = new DelegateCommand();
            this.OpenInput.ExecuteCommand = new Action<object>(this.OpenInputPage);
            #endregion

            #region 菜单二
            
            #endregion

        }


        #region 打开人工输入界面
        public void OpenInputPage(object parameter)
        {
            Data_input cw;
            DataInput_VM ma = new DataInput_VM();
            cw = new Data_input(ma);
            cw.Show();
        }
        #endregion



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
