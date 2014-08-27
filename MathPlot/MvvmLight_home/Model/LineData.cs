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
    }
}
