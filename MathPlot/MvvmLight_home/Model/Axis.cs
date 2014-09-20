using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GalaSoft.MvvmLight.Messaging;

namespace MvvmLight_home.Model
{
    public class Axis:Canvas
    {
        private int TOP = 8;
        private int BOTTOM = 26;
        private int BOTTOM_ZERO = 33;
        private int LEFT = 25;
        private int LEFT_ZERO = 50;
        private int RIGHT = 8;
        private static int AXISTHICKNESS = 3;

        

        private List<Visual> visuals = new List<Visual>();

        protected override int VisualChildrenCount
        {
            get
            {
                return visuals.Count;
            }
        }

        protected override Visual GetVisualChild(int index)
        {
            return visuals[index];
        }

        public void AddVisual(Visual visual)
        {
            visuals.Add(visual);

            base.AddVisualChild(visual);
            base.AddLogicalChild(visual);
        }

        public void DeleteVisual(Visual visual)
        {
            visuals.Remove(visual);

            base.RemoveVisualChild(visual);
            base.RemoveLogicalChild(visual);
        }

        public void Clear()
        {
            for(int i = 0; i < visuals.Count; i++)
            {
                
                base.RemoveVisualChild(visuals[i]);
                base.RemoveLogicalChild(visuals[i]);
                visuals.RemoveAt(i);

            }
        }

        protected Pen pen = new Pen(Brushes.Black, AXISTHICKNESS);

        public void plotY(double MAX, double MIN)
        {
            DrawingVisual visual = new DrawingVisual();
            double DIVISION = (this.Height - BOTTOM_ZERO - TOP)/6;
            double division = (MAX - MIN) / 6;

             using (DrawingContext dc = visual.RenderOpen())
             {
                 //主线
                 dc.DrawLine(pen, new Point(LEFT_ZERO , TOP), new Point(LEFT_ZERO, this.Height-BOTTOM));
                 //分度线
                 for(int i = 0; i < 6; i++)
                 {
                     string str = (MIN + i * division).ToString();
                     FormattedText formattedText = new FormattedText(
                                                                    str,
                                                                    System.Globalization.CultureInfo.GetCultureInfo("en-us"),
                                                                    FlowDirection.RightToLeft,
                                                                    new Typeface("Verdana"),
                                                                    10,
                                                                    Brushes.Black);

                     dc.DrawText(formattedText, new Point(LEFT_ZERO - 5 , this.Height - BOTTOM_ZERO - DIVISION * i - 5));
                     dc.DrawLine(pen, new Point(LEFT_ZERO, this.Height - BOTTOM_ZERO - DIVISION * i), new Point(LEFT_ZERO - 3, this.Height - BOTTOM_ZERO - DIVISION * i));
                 }
                 //三角
                 dc.DrawLine(pen, new Point(LEFT_ZERO, TOP), new Point(LEFT_ZERO - 8, TOP + 8));
                 dc.DrawLine(pen, new Point(LEFT_ZERO, TOP), new Point(LEFT_ZERO + 8, TOP + 8));
             }
             this.AddVisual(visual);
        }
        public void plotX(double MAX, double MIN)
        {
            DrawingVisual visual = new DrawingVisual();

            double DIVISION = (this.Width - BOTTOM_ZERO - TOP) / 6;
            double division = (MAX - MIN) / 6;

            using (DrawingContext dc = visual.RenderOpen())
            {
                //主线
                dc.DrawLine(pen, new Point(LEFT_ZERO, this.Height - BOTTOM_ZERO), new Point(this.Width - RIGHT, this.Height - BOTTOM_ZERO));
                //分度线
                for (int i = 0; i < 6; i++)
                {
                    string str = (MIN + i * division).ToString();
                    FormattedText formattedText = new FormattedText(
                                                                   str,
                                                                   System.Globalization.CultureInfo.GetCultureInfo("en-us"),
                                                                   FlowDirection.LeftToRight,
                                                                   new Typeface("Verdana"),
                                                                   10,
                                                                   Brushes.Black);

                    dc.DrawText(formattedText, new Point(LEFT_ZERO + DIVISION * i - 2, this.Height - BOTTOM_ZERO + 5));
                    dc.DrawLine(pen, new Point(LEFT_ZERO + DIVISION * i, this.Height - BOTTOM_ZERO), new Point(LEFT_ZERO + DIVISION * i, this.Height - BOTTOM_ZERO - 3));
                }
                //三角
                dc.DrawLine(pen, new Point(this.Width - RIGHT, this.Height - BOTTOM_ZERO), new Point(this.Width - RIGHT - 8, this.Height - BOTTOM_ZERO - 8));
                dc.DrawLine(pen, new Point(this.Width - RIGHT, this.Height - BOTTOM_ZERO), new Point(this.Width - RIGHT - 8, this.Height - BOTTOM_ZERO + 8));
            }
            this.AddVisual(visual);
        }
        public void plotZ()
        {
            DrawingVisual visual = new DrawingVisual();

            using (DrawingContext dc = visual.RenderOpen())
            {
                dc.DrawEllipse(Brushes.Black, null, new Point(LEFT_ZERO, this.Height - BOTTOM_ZERO), 5, 5);
            }
            this.AddVisual(visual);
        }
    }
}
