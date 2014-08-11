using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using System.Data;
using System.Data.OleDb;
using System.Collections;
using System.Data.Objects;
using System.Data.SqlClient;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace MathPlot.Models
{
    public class FileClass : INotifyPropertyChanged
    {
        private int num;
        public int Num
        {
            get { return num; }
            set
            {
                num = value;
            }
        }

        public Cruve cruve = new Cruve();

        #region 打开Excel
        public void OpenExcel(object obj)
        {
            Stream myStream = null;
            Microsoft.Win32.OpenFileDialog openFileDialog1 = new Microsoft.Win32.OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Excel files (*.xls, *xlsx)|*.xls; *xlsx";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            bool? userClickedOK = openFileDialog1.ShowDialog();

            if (userClickedOK == true)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            string ConnectionStr = "";
                            ConnectionStr = this.judgeVersion(openFileDialog1.FileName);

                            //MessageBox.Show(ConnectionStr);
                            this.conExcel(ConnectionStr);
                            //MessageBox.Show(PubCom.Ylabel);

                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }
        #endregion

        #region 给Excel连接字符串
        private string judgeVersion(string filename)
        {
            string FileName = @filename;
            if (filename.EndsWith("xlsx"))
            {
                return "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + @filename + ";" +
                                "Extended Properties='Excel 12.0 Xml;HDR=NO" + ";'";
            }
            else
                return "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + FileName + ";" +
                                "Extended Properties='Excel 8.0;HDR=NO;IMEX=1" + ";'";
        }
        #endregion

        #region 连接Excel
        //连接数据库，导入数据
        public void conExcel(string connection)
        {
            DataSet dtTemp = new DataSet();

            OleDbConnection objConn = new OleDbConnection(connection);
            objConn.Open();

            OleDbDataAdapter oda = new OleDbDataAdapter("select * from [Sheet1$]", objConn);

            oda.Fill(dtTemp);

            Num += 1;
            //Cruve cruve = new Cruve();
            //allCruve.Add(cruve);

            if (!isNumberic(dtTemp.Tables[0].Rows[0][0].ToString()))
            {
                //Xlabel = dtTemp.Tables[0].Rows[0][0].ToString();
                //Ylabel = dtTemp.Tables[0].Rows[0][1].ToString();

                for (int i = 1; i < dtTemp.Tables[0].Rows.Count - 1; i++)
                {
                    cruve.Xpoint = double.Parse(dtTemp.Tables[0].Rows[i][0].ToString());
                    cruve.Ypoint = double.Parse(dtTemp.Tables[0].Rows[i][1].ToString());

                    cruve.init();
                }
            }
            else
            {
                //Xlabel = "";
                //Ylabel = "";

                for (int i = 0; i < dtTemp.Tables[0].Rows.Count - 1; i++)
                {
                    cruve.Xpoint = double.Parse(dtTemp.Tables[0].Rows[i][0].ToString());
                    cruve.Ypoint = double.Parse(dtTemp.Tables[0].Rows[i][1].ToString());

                    cruve.init();
                }

            }




        }
        #endregion

        #region 判断是否为数字
        private bool isNumberic(string message)
        {
            double result = 0.0;
            try
            {
                result = double.Parse(message);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region 打开人工输入窗口
        Data_input cw;

        public void executeOpenChildWindow(object parameter)
        {
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
