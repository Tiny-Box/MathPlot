using System;
using System.Windows;
using System.IO;

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
                            Point a = new Point(10, 50);
                            Point b = new Point(100, 150);

                            var item = new LineData();
                            item.Line.Add(a);
                            item.Line.Add(b);
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
    }
}