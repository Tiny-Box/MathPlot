using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Data;
using System.Data.OleDb;
using System.Collections;
using System.Data.Objects;
using System.Data.SqlClient;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace MathPlot
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainPage_VM();
        }


        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            ////文件打开
            //Stream myStream = null;
            //Microsoft.Win32.OpenFileDialog openFileDialog1 = new Microsoft.Win32.OpenFileDialog();

            //openFileDialog1.InitialDirectory = "c:\\";
            //openFileDialog1.Filter = "Excel files (*.xls, *xlsx)|*.xls; *xlsx";
            //openFileDialog1.FilterIndex = 1;
            //openFileDialog1.RestoreDirectory = true;

            //bool? userClickedOK = openFileDialog1.ShowDialog();

            //if (userClickedOK == true)
            //{
            //    try
            //    {
            //        if ((myStream = openFileDialog1.OpenFile()) != null)
            //        {
            //            using (myStream)
            //            {
            //                string ConnectionStr = "";
            //                ConnectionStr = PubCom.judgeVersion(openFileDialog1.FileName);

            //                PubCom.conExcel(ConnectionStr);
            //                MessageBox.Show(PubCom.Ylabel);
                           
            //            }

            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
            //    }
            //}

        }
    }

    //class Cruve
    //{
    //    //存储坐标
    //    List<double> xpoint = new List<double>();
    //    List<double> ypoint = new List<double>();
    //    PointF[] coordiate;

    //    //斜率
    //    double slope;
    //    //最大值
    //    double max;
    //    //平均值
    //    double avg;
    //    //最小值
    //    double min;

    //    public double Xpoint
    //    {
    //        set { xpoint.Add(value); }
    //    }
    //    public double Ypoint
    //    {
    //        set { ypoint.Add(value); }
    //    }


    //    //初始化曲线
    //    public void init()
    //    {
    //        this.coordiate = new PointF[xpoint.Count];
    //        for (int i = 0; i <= this.xpoint.Count - 1; i++)
    //        {
    //            this.coordiate[i] = new PointF(float.Parse(this.xpoint[i].ToString()), float.Parse(this.ypoint[i].ToString()));
    //        }
                
    //    }



    //}

    //static class PubCom
    //{
    //    public static List<Cruve> allCruve = new List<Cruve>();
    //    public static int num = -1;

    //    //坐标轴标签
    //    public static string Xlabel;
    //    public static string Ylabel;

    //    //临时贮存Excel里数据的dataset
    //    public static DataSet dtTemp = new DataSet();

    //    //判断是否为数字
    //    public static bool isNumberic(string message)
    //    {
    //        double result = 0.0;
    //        try
    //        {
    //            result = double.Parse(message);
    //            return true;
    //        }
    //        catch
    //        {
    //            return false;
    //        }
    //    }

    //    //判断导入的Excel版本
    //    public static string judgeVersion(string filename)
    //    {
    //        string FileName = @filename;
    //        if(filename.EndsWith("xlsx"))
    //        {
    //            return "Provider=Microsoft.ACE.OLEDB.12.0;Data Source="+@filename+";" +
    //                            "Extended Properties='Excel 12.0 Xml;HDR=NO" + ";'";
    //        }
    //        else
    //            return "Provider=Microsoft.Jet.OLEDB.4.0;Data Source="+FileName+";" +
    //                            "Extended Properties='Excel 8.0;HDR=NO;IMEX=1" + ";'";
    //    }

    //    //连接数据库，导入数据
    //    public static void conExcel(string connection)
    //    {
    //        OleDbConnection objConn = new OleDbConnection(connection);
    //        objConn.Open();

    //        OleDbDataAdapter oda = new OleDbDataAdapter("select * from [Sheet1$]", objConn);
            
    //        oda.Fill(dtTemp);

    //        num += 1;
    //        Cruve cruve = new Cruve();
    //        allCruve.Add(cruve);

    //        if(!isNumberic(dtTemp.Tables[0].Rows[0][0].ToString()))
    //        {
    //            Xlabel = dtTemp.Tables[0].Rows[0][0].ToString();
    //            Ylabel = dtTemp.Tables[0].Rows[0][1].ToString();

    //            for (int i = 1; i < dtTemp.Tables[0].Rows.Count - 1; i++)
    //            {
    //                allCruve[num].Xpoint = double.Parse(dtTemp.Tables[0].Rows[i][0].ToString());
    //                allCruve[num].Ypoint = double.Parse(dtTemp.Tables[0].Rows[i][1].ToString());

    //                allCruve[num].init();
    //            }
    //        }
    //        else
    //        {
    //            Xlabel = "";
    //            Ylabel = "";

    //            for (int i = 0; i < dtTemp.Tables[0].Rows.Count - 1; i++)
    //            {
    //                allCruve[num].Xpoint = double.Parse(dtTemp.Tables[0].Rows[i][0].ToString());
    //                allCruve[num].Ypoint = double.Parse(dtTemp.Tables[0].Rows[i][1].ToString());

    //                allCruve[num].init();
    //            }
                
    //        }

            
            
            
    //    }

    //} 
}
