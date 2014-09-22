using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace MvvmLight_home.Model
{
    public class LineData
    {

        private int TOP = 8;
        private int BOTTOM_ZERO = 33;
        private int LEFT_ZERO = 50;
        private int RIGHT = 8;
        private int HEIGHT = 491;
        private int WIDTH = 780;
        private static int AXISTHICKNESS = 3;

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

        public PathFigure ToPathFigure(double Xmax, double Xmin, double Ymax, double Ymin)
        {
            //PathFigure pathFigure = new PathFigure();

            //pathFigure.StartPoint = this.StartPoint;

            //Point[] polyLinePointArray = new Point[this.Line.Count - 1];
            //for (int i = 1; i < this.Line.Count; i++)
            //{
            //    polyLinePointArray[i - 1] = new Point(this.Line[i].X, this.Line[i].Y);
            //}

            //PolyLineSegment myPolyLineSegment = new PolyLineSegment();
            //myPolyLineSegment.Points = new PointCollection(polyLinePointArray);

            PathFigure pathFigure = new PathFigure();

            double Xr = (WIDTH - RIGHT - LEFT_ZERO) / (Xmax - Xmin);
            //MessageBox.Show("Xr: " + Xr.ToString());
            double Yr = -(HEIGHT - TOP - BOTTOM_ZERO) / (Ymax - Ymin);
            //MessageBox.Show("Yr: " + Yr.ToString());

            //MessageBox.Show("Line[0].X Y: " + this.Line[0].X.ToString() + " " + this.Line[0].Y.ToString());

            Matrix matrix1 = new Matrix(Xr, 0, 0, Yr, LEFT_ZERO, HEIGHT-BOTTOM_ZERO);
            Point[] temp = new Point[this.Line.Count];

            for (int i = 0; i < this.Line.Count; i++ )
            {
                temp[i] = Point.Multiply(this.Line[i], matrix1);
            }
            //MessageBox.Show("temp[0].X Y: " + temp[0].X.ToString() + " " + temp[0].Y.ToString());

            pathFigure.StartPoint = Point.Multiply(this.StartPoint, matrix1);
            //MessageBox.Show("StartPoint.X Y: " + pathFigure.StartPoint.X.ToString() + " " + pathFigure.StartPoint.Y.ToString());

            PolyLineSegment myPolyLineSegment = new PolyLineSegment();
            myPolyLineSegment.Points = new PointCollection(temp);

            pathFigure.Segments.Add(myPolyLineSegment);

            return pathFigure;
        }

        void dealData(double Xmax, double Xmin, double Ymax, double Ymin)
        {

        }
    }
}
