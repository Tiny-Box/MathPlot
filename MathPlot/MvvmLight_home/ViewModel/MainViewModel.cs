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

        private PathGeometry _tempData = new PathGeometry();
        public PathGeometry tempData
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
        
       
        #endregion


        #region Method
        void setline(LineData line)
        {
            PathFigure pathFigure = new PathFigure();
           
            pathFigure.StartPoint = line.StartPoint;
           
            PolyLineSegment myPolyLineSegment = new PolyLineSegment();
            myPolyLineSegment.Points = new PointCollection(line.Line.ToArray());
            
            pathFigure.Segments.Add(myPolyLineSegment);

            tempData.Figures.Add(pathFigure);
        }

        void Plotline()
        {
            myPathGeometry = tempData;
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

                            setline(item);
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
                () =>
                {
                    Plotline();
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