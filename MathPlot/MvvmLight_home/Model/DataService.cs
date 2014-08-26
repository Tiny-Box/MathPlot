using System;
using System.Windows;
using System.IO;
using System.Data;
using System.Data.OleDb;

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

        public void OpenExcel(Action<LineData, Exception> callback)
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
                            DataSet dtTemp = excelData(openFileDialog1.FileName);
                            

                            var item = new LineData();
                            callback(item, null);
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        public DataSet excelData(string fileName)
        {
            string connStr = "";
            if (fileName.EndsWith("xls"))
                connStr = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + fileName + ";" + ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1\"";
            else
                connStr = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + fileName + ";" + ";Extended Properties=\"Excel 12.0;HDR=YES;IMEX=1\"";
            DataSet dtTemp = new DataSet();

            OleDbConnection objConn = new OleDbConnection(connStr);
            objConn.Open();

            OleDbDataAdapter oda = new OleDbDataAdapter("select * from [Sheet1$]", objConn);

            oda.Fill(dtTemp);
            return dtTemp;
        }

        public 
    }
}