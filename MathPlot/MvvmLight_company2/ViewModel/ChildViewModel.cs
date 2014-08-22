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

        public Border _pannel;
        public Border exampleBorder
        {
            get
            {
                return _pannel;
            }
            set
            {
                if (_pannel == value)
                {
                    return;
                }
                _pannel = value;
                RaisePropertyChanged("exampleBorder");
            }
        }
        private Image _anImage;
        public Image anImage
        {
            get
            {
                return _anImage;
            }
            set
            {
                if (_anImage == value)
                {
                    return;
                }
                _anImage = value;
                RaisePropertyChanged("anImage");
            }
        }

        #region Method
        void PlotLine()
        {
            //
            // Create the Geometry to draw.
            //
            GeometryGroup ellipses = new GeometryGroup();
            ellipses.Children.Add(
                new EllipseGeometry(new Point(50, 50), 45, 20)
                );
            ellipses.Children.Add(
                new EllipseGeometry(new Point(50, 50), 20, 45)
                );


            //
            // Create a GeometryDrawing.
            //
            GeometryDrawing aGeometryDrawing = new GeometryDrawing();
            aGeometryDrawing.Geometry = ellipses;

            // Paint the drawing with a gradient.
            aGeometryDrawing.Brush =
                new LinearGradientBrush(
                    Colors.Blue,
                    Color.FromRgb(204, 204, 255),
                    new Point(0, 0),
                    new Point(1, 1));

            // Outline the drawing with a solid color.
            aGeometryDrawing.Pen = new Pen(Brushes.Black, 10);

            //
            // Use a DrawingImage and an Image control
            // to display the drawing.
            //
            DrawingImage geometryImage = new DrawingImage(aGeometryDrawing);

            // Freeze the DrawingImage for performance benefits.
            geometryImage.Freeze();

            //Image anImage = new Image();
            anImage.Source = geometryImage;
            anImage.Stretch = Stretch.None;
            anImage.HorizontalAlignment = HorizontalAlignment.Left;

            //
            // Place the image inside a border and
            // add it to the page.
            //
            //Border exampleBorder = new Border();
            //exampleBorder.Child = anImage;
            //exampleBorder.BorderBrush = Brushes.Gray;
            //exampleBorder.BorderThickness = new Thickness(1);
            //exampleBorder.HorizontalAlignment = HorizontalAlignment.Left;
            //exampleBorder.VerticalAlignment = VerticalAlignment.Top;
            //exampleBorder.Margin = new Thickness(10);

            //pan.Margin = new Thickness(20);
            //pan.Background = Brushes.White;
            //pan.Content = exampleBorder;

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
            
            #endregion
        }
    }
}