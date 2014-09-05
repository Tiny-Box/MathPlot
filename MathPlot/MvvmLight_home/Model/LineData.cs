using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace MvvmLight_home.Model
{
    public class LineData
    {

        public ObservableCollection<Point> Line
        {
            get;
            set;
        }

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
            
        }
        public double Y
        {
            get
            {
                return Line[Line.Count - 1].Y;
            }
            
        }

        public void newPoint(double x, double y)
        {
            Line.Add(new Point(x, y));
        }
    }
}
