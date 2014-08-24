using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MvvmLight_home.Model;

using System.Windows;
using System.Windows.Media;

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


        #region ICommand
        public RelayCommand Open
        {
            get;
            private set;
        }

        public RelayCommand ReciveCommand
        {
            get;
            private set;
        }

        public RelayCommand<string> BehaviourCommand
        {
            get;
            private set;
        }

        
       
        #endregion


        #region Method
        void Plot(Point[] line)
        {
            PathFigure pathFigure2 = new PathFigure();
            //pathFigure2.StartPoint = new Point(10, 100);
            Point[] polyLinePointArray = line;
            PolyLineSegment myPolyLineSegment = new PolyLineSegment();
            myPolyLineSegment.Points =
                new PointCollection(polyLinePointArray);
            pathFigure2.Segments.Add(myPolyLineSegment);

            myPathGeometry.Figures.Add(pathFigure2);
        }
        #endregion

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IDataService dataService)
        {
            _dataService = dataService;
            //_dataService.GetData(
            //    (item, error) =>
            //    {
            //        if (error != null)
            //        {
            //            // Report error here
            //            return;
            //        }

            //        WelcomeTitle = item.Title;
            //    }
            //);

            Open = new RelayCommand
            (
                () =>
                {
                    MessageBox.Show("Button is ok");
                    _dataService.OpenExcel(
                        (item, error) =>
                        {
                            if (error != null)
                            {
                                return;
                            }

                            Plot(item.Line.ToArray());
                            MessageBox.Show("VM is OK");
                        }
                        );
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