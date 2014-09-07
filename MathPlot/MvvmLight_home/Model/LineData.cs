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

        public PathFigure ToPathFigure()
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

            pathFigure.StartPoint = this.StartPoint;

            PolyLineSegment myPolyLineSegment = new PolyLineSegment();
            myPolyLineSegment.Points = new PointCollection(this.Line);

            pathFigure.Segments.Add(myPolyLineSegment);

            return pathFigure;
        }
    }
}
