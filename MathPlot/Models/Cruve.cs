using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Drawing;

namespace MathPlot.Models
{
    public class Cruve
    {
        //存储坐标
        List<double> xpoint = new List<double>();
        List<double> ypoint = new List<double>();
        PointF[] coordiate;

        //斜率
        double slope;
        //最大值
        double max;
        //平均值
        double avg;
        //最小值
        double min;

        public double Xpoint
        {
            set { xpoint.Add(value); }
        }
        public double Ypoint
        {
            set { ypoint.Add(value); }
        }


        //初始化曲线
        public void init()
        {
            this.coordiate = new PointF[xpoint.Count];
            for (int i = 0; i <= this.xpoint.Count - 1; i++)
            {
                this.coordiate[i] = new PointF(float.Parse(this.xpoint[i].ToString()), float.Parse(this.ypoint[i].ToString()));
            }

        }
        public void init(List<string> data)
        {
            this.coordiate = new PointF[data.Count];
            for (int i = 0; i <= data.Count - 1; i++)
            {
               // this.coordiate[i] = new PointF(float.Parse
            }
        }
    }
}
