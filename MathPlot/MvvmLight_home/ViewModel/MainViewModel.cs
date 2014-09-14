using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

using MvvmLight_home;
using MvvmLight_home.Model;

using System.Windows;
using System.Windows.Media;
using System.Collections.ObjectModel;

namespace MvvmLight_home.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;

        /// <summary>
        /// The <see cref="WelcomeTitle" /> property's name.
        /// </summary>
        public const string WelcomeTitlePropertyName = "WelcomeTitle";

        private string _welcomeTitle = string.Empty;

        /// <summary>
        /// Gets the WelcomeTitle property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>


        private string _testStr = "abc";
        public string TestStr
        {
            get
            {
                return _testStr;
            }

            set
            {
                if (_testStr == value)
                {
                    return;
                }

                _testStr = value;
                RaisePropertyChanged("TestStr");
            }
        }

        private LineData _tempData = new LineData();
        public LineData tempData
        {
            get
            {
                return _tempData;
            }
            set
            {
                _tempData = value;
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
        public testV a
        {
            get;
            set;
        }

        #region ICommand
        public RelayCommand Open
        {
            get;
            private set;
        }

        public RelayCommand Plot
        {
            get;
            private set;
        }

        public RelayCommand OpenInput
        {
            get;
            private set;
        }

        public RelayCommand OpenArgv
        {
            get;
            private set;
        }
		
		public RelayCommand<object> drag
        {
            get;
            private set;
        }
       
        #endregion


        #region Method
        void Plotline()
        {
            myPathGeometry.Figures.Add(tempData.ToPathFigure());
        }
        private void plottest(DrawingVisual visual, Point topLeftCorner, bool isSelected)
        {
            using (DrawingContext dc = visual.RenderOpen())
            {
                Pen drawingPen = new Pen(Brushes.Black, 3);
                dc.DrawLine(drawingPen, new Point(0, 50), new Point(50, 0));
            }
        }
        #endregion

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IDataService dataService)
        {
            _dataService = dataService;

            Open = new RelayCommand
            (
                () =>
                {
                    
                    _dataService.OpenExcel(
                        (item, error) =>
                        {
                            if (error != null)
                            {
                                return;
                            }

                            tempData = item;
                            
                            MessageBox.Show("Data has been inputed");
                        }
                        );
                }
            );

            OpenInput = new RelayCommand
            (
                () =>
                {
                    InputView input = new InputView();
                    input.Show();
                }
            );

            Plot = new RelayCommand
            (
                ()=>
                {
                    a = new testV();
                    DrawingVisual visual = new DrawingVisual();
                    a.plottest();
                    
                }
            );
			drag = new RelayCommand<object>
            (
                o =>
                {
                    ((Window)o).DragMove();
                }
            );
            a = new testV();
            

            Messenger.Default.Register<LineData>(this, "Main",
                       n =>
                       {
                           tempData = n;
                       }
           );

            Messenger.Default.Register<ArgvL>(this, "Main",
                       n =>
                       {
                           
                       }
           );

        }

        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}
    }
}