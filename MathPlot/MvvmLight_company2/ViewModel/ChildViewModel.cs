using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

using MvvmLight_company2.Model;


namespace MvvmLight_company2.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class ChildViewModel : ViewModelBase
    {

        #region ICommand

        public RelayCommand LoginCommand
        {
            get;
            private set;
        }

        public RelayCommand CancelCommand
        {
            get
            {
                return new RelayCommand(
                    () =>
                    {
                        // 发送消息  
                        Messenger.Default.Send<bool?>(null);
                    }
                    );
            }
        }

        public RelayCommand Plot
        {
            get;
            private set;
        }

        public RelayCommand AddPlot
        {
            get;
            private set;
        }
        
        #endregion

        private Point _startPoint = new Point(10, 50);
        public Point StartPoint
        {
            get
            {
                return _startPoint;
            }
            set
            {
                _startPoint = value;
                RaisePropertyChanged("startPoint");
            }
        }
        private Point _endPoint = new Point(200, 70);
        public Point EndPoint
        {
            get
            {
                return _endPoint;
            }
            set
            {
                _endPoint = value;
                RaisePropertyChanged("EndPoint");
            }
        }

        private PathGeometry _myPathGeometry = new PathGeometry();
        public PathGeometry myPathGeometry
        {
            get
            {
                return _myPathGeometry;
            }
            set
            {
                _myPathGeometry = value;
                RaisePropertyChanged("myPathGeometry");
            }
        }

        private string _sendStr = "LightBlue";
        public string SendStr
        {
            get
            {
                return _sendStr;
            }
            set
            {
                if (_sendStr == value)
                {
                    return;
                }
                _sendStr = value;
                RaisePropertyChanged("SendStr");
            }
        }

        

        #region Method
        void PlotLine()
        {
            StartPoint = new Point(10, 100.5);
            EndPoint = new Point(200, 120);

            PathFigure pathFigure1 = new PathFigure();
            pathFigure1.StartPoint = new Point(10, 50);
            pathFigure1.Segments.Add(
                new BezierSegment(
                    new Point(100, 0),
                    new Point(200, 200),
                    new Point(300, 100),
                    true /* IsStroked */ ));
            pathFigure1.Segments.Add(
                new LineSegment(
                    new Point(400, 100),
                    true /* IsStroked */ ));
            pathFigure1.Segments.Add(
                new ArcSegment(
                    new Point(200, 100),
                    new Size(50, 50),
                    45,
                    true, /* IsLargeArc */
                    SweepDirection.Clockwise,
                    true /* IsStroked */ ));
            myPathGeometry.Figures.Add(pathFigure1);

            // Create another figure.
            PathFigure pathFigure2 = new PathFigure();
            pathFigure2.StartPoint = new Point(10, 100);
            Point[] polyLinePointArray =
                new Point[] { new Point(50, 100), new Point(50, 150) };
            PolyLineSegment myPolyLineSegment = new PolyLineSegment();
            myPolyLineSegment.Points =
                new PointCollection(polyLinePointArray);
            pathFigure2.Segments.Add(myPolyLineSegment);
            pathFigure2.Segments.Add(
                new QuadraticBezierSegment(
                    new Point(200, 200),
                    new Point(300, 100),
                    true /* IsStroked */ ));
            myPathGeometry.Figures.Add(pathFigure2);


        }

        void addPlot()
        {
            PathFigure pathFigure2 = new PathFigure();
            pathFigure2.StartPoint = new Point(10, 100);
            Point[] polyLinePointArray =
                new Point[] { new Point(50, 200), new Point(50, 250) };
            PolyLineSegment myPolyLineSegment = new PolyLineSegment();
            myPolyLineSegment.Points =
                new PointCollection(polyLinePointArray);
            pathFigure2.Segments.Add(myPolyLineSegment);

            myPathGeometry.Figures.Add(pathFigure2);
        }

        public void receiveMsg(string receiveStr)
        {
            SendStr = receiveStr;
        }
        #endregion


        /// <summary>
        /// Initializes a new instance of the ChildViewModel class.
        /// </summary>
        public ChildViewModel()
        {

            

            #region
            LoginCommand = new RelayCommand
            (
                    () =>
                    {
                        //System.Windows.Controls.PasswordBox pb = p as System.Windows.Controls.PasswordBox;

                        //bool isLogon = false;
                        //string isLogon = "ABC";

                        // 发送消息  
                        MessageBox.Show(SendStr);
                        Messenger.Default.Send<string>(SendStr);

                    }
            );

            Plot = new RelayCommand
            (
                () =>
                {
                    MessageBox.Show("OK");
                    PlotLine();
                }
            );

            AddPlot = new RelayCommand
            (
                () =>
                {
                    MessageBox.Show("ok");
                    addPlot();
                }
            );
            #endregion
        }
    }
}