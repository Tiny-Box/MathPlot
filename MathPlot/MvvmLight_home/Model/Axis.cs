using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmLight_home.Model
{
    public class Axis:Canvas
    {
        private int TOP = 8;
        private int BOTTOM = 26;
        private int BOTTOM_ZERO = 33;
        private int LEFT = 25;
        private int LEFT_ZERO = 33;
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

        public void plotY()
        {
            DrawingVisual visual = new DrawingVisual();
            double DIVISION = (this.Height - BOTTOM_ZERO - TOP)/6;

             using (DrawingContext dc = visual.RenderOpen())
             {
                 //主线
                 dc.DrawLine(pen, new Point((this.Width-AXISTHICKNESS)/2, TOP), new Point((this.Width-AXISTHICKNESS)/2, this.Height-BOTTOM));
                 //分度线
                 for(int i = 0; i < 6; i++)
                 {
                     dc.DrawLine(pen, new Point((this.Width - AXISTHICKNESS) / 2, this.Height - BOTTOM_ZERO - DIVISION * i), new Point((this.Width - AXISTHICKNESS) / 2 - 3, this.Height - BOTTOM_ZERO - DIVISION * i));
                 }
                 //三角
                 dc.DrawLine(pen, new Point((this.Width-AXISTHICKNESS) / 2 , TOP), new Point((this.Width-AXISTHICKNESS)/2 - 8, TOP + 8));
                 dc.DrawLine(pen, new Point((this.Width - AXISTHICKNESS) / 2 , TOP), new Point((this.Width - AXISTHICKNESS) / 2 + 8, TOP + 8));
             }
             this.AddVisual(visual);
        }
        public void plotX()
        {
            DrawingVisual visual = new DrawingVisual();

            double DIVISION = (this.Width - BOTTOM_ZERO - TOP) / 6;

            using (DrawingContext dc = visual.RenderOpen())
            {
                //主线
                dc.DrawLine(pen, new Point(LEFT, (this.Height - AXISTHICKNESS)/2), new Point(this.Width - RIGHT, (this.Height - AXISTHICKNESS)/2));
                //分度线
                for (int i = 0; i < 6; i++)
                {
                    dc.DrawLine(pen, new Point(LEFT_ZERO + DIVISION * i, (this.Height - AXISTHICKNESS) / 2), new Point(LEFT_ZERO + DIVISION * i, (this.Height - AXISTHICKNESS) / 2 - 3));
                }
                //三角
                dc.DrawLine(pen, new Point(this.Width - RIGHT, (this.Height - AXISTHICKNESS) / 2), new Point(this.Width - RIGHT - 8, (this.Height - AXISTHICKNESS) / 2 - 8));
                dc.DrawLine(pen, new Point(this.Width - RIGHT, (this.Height - AXISTHICKNESS) / 2), new Point(this.Width - RIGHT - 8, (this.Height - AXISTHICKNESS) / 2 + 8));
            }
            this.AddVisual(visual);
        }
        public void plotZ()
        {
            DrawingVisual visual = new DrawingVisual();

            using (DrawingContext dc = visual.RenderOpen())
            {
                dc.DrawEllipse(Brushes.Black, null, new Point(LEFT_ZERO - 3, this.Height - BOTTOM_ZERO), 5, 5);
            }
            this.AddVisual(visual);
        }
    }
}
