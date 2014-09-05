using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace MvvmLight_home.Model
{
    public class LineData
    {
        public List<Point> Line = new List<Point>();

        public Point StartPoint
        {
            get;
            set;
        }

        public double X
        {
            get
            {
                return Line[Line.Count - 1].X;
            }
            set;
        }
        public double Y
        {
            get
            {
                return Line[Line.Count - 1].Y;
            }
            set;
        }

        public void newPoint()
        {
            Line.Add(new Point(X, Y));
        }
    }
}
