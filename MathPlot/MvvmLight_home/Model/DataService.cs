using System;
using System.Windows;
using System.IO;
using System.Linq;
using System.Data;
using System.Data.OleDb;
using Microsoft.Win32;

namespace MvvmLight_home.Model
{
    public class DataService : IDataService
    {
        public void GetData(Action<DataItem, Exception> callback)
        {
            // Use this to connect to the actual data service

            var item = new DataItem("Welcome to MVVM Light");
            callback(item, null);
        }
        delegate int judgetitle(object a);
        public void OpenExcel(Action<LineData, Exception> callback)
        {

            
            OpenFileDialog openFileDialog1 = new Microsoft.Win32.OpenFileDialog();

            openFileDialog1.InitialDirectory = "D:\\";
            openFileDialog1.Filter = "Excel files (*.xls, *xlsx)|*.xls; *xlsx";
            
            if (openFileDialog1.ShowDialog() == true)
            {

            }

            DataSet dtTemp = excelData(openFileDialog1.FileName);

            judgetitle gwl = (p) =>
            {

                try
                {
                    double a = double.Parse(p.ToString());
                    return 0;
                }
                catch (FormatException)
                {
                    return 1;
                }

            };

            
            int i = gwl(dtTemp.Tables[0].Rows[0][0]);

            var item = new LineData();
            item.StartPoint = new Point(double.Parse(dtTemp.Tables[0].Rows[i][0].ToString()), double.Parse(dtTemp.Tables[0].Rows[i][1].ToString()));
            
            for (i = i+1; i < dtTemp.Tables[0].Rows.Count - 1; i++)
            {
                item.Line.Add(new Point(double.Parse(dtTemp.Tables[0].Rows[i][0].ToString()), double.Parse(dtTemp.Tables[0].Rows[i][1].ToString())));
            }
            
            callback(item, null);


        }


        public DataSet excelData(string fileName)
        {
            string connStr = "";
            if (fileName.EndsWith("xls"))
                connStr = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + fileName + ";" + ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1\"";
            else
                connStr = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + fileName + ";" + ";Extended Properties=\"Excel 12.0;HDR=NO;IMEX=1\"";
            DataSet dtTemp = new DataSet();

            OleDbConnection objConn = new OleDbConnection(connStr);
            objConn.Open();

            OleDbDataAdapter oda = new OleDbDataAdapter("select * from [Sheet1$]", objConn);

            oda.Fill(dtTemp);


            

            //int i = gwl(dtTemp.Tables[0].Rows[0][0]);
            //MessageBox.Show(i.ToString());
            //MessageBox.Show(dtTemp.Tables[0].Rows[1][0].GetType().ToString());
            //MessageBox.Show(dtTemp.Tables[0].Rows[0][0].GetType().ToString());
            return dtTemp;
        }


    }
}