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
    public class testV:Canvas
    {
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

        private Pen drawingPen = new Pen(Brushes.SteelBlue, 3);
        private Size squareSize = new Size(30, 30);

        private void plottest(DrawingVisual visual, Point topLeftCorner, bool isSelected)
        {
            using (DrawingContext dc = visual.RenderOpen())
            {
                Brush brush = Brushes.Black;
                dc.DrawRectangle(brush, drawingPen, new Rect(topLeftCorner, squareSize));
            }
        }

        public void plottest()
        {
            //DrawingVisual visual = new DrawingVisual();
            //using (DrawingContext dc = visual.RenderOpen())
            //{
            //    Pen drawingPen = new Pen(Brushes.Black, 3);
            //    dc.DrawLine(drawingPen, new Point(0, 50), new Point(50, 0));
            //}
            DrawingVisual visual = new DrawingVisual();
            plottest(visual, new Point(10, 10), false);
            this.AddVisual(visual);
        }
    }
}
