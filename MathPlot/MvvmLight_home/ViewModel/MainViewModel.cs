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
        private readonly DataService _dataService;

        /// <summary>
        /// The <see cref="WelcomeTitle" /> property's name.
        /// </summary>
        public const string WelcomeTitlePropertyName = "WelcomeTitle";

        private string _welcomeTitle = string.Empty;

        /// <summary>
        /// Gets the WelcomeTitle property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>

        #region Value
        public string _title = string.Empty;
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                RaisePropertyChanged("Title");
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

        private string _color = "Black";
        public string Color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
                RaisePropertyChanged("Color");
            }
        }

        private ArgvL _tempArgv = new ArgvL();
        public ArgvL tempArgv
        {
            get
            {
                return _tempArgv;
            }
            set
            {
                _tempArgv = value;
            }
        }
        #endregion 

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
            //myPathGeometry.Figures.Add(tempData.ToPathFigure(tempArgv.xmax, tempArgv.xmin, tempArgv.ymax, tempArgv.ymin));
            myPathGeometry.Figures.Add(tempData.ToSmooth(tempArgv.xmax, tempArgv.xmin, tempArgv.ymax, tempArgv.ymin));
        }
        #endregion

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(DataService dataService)
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
                    Plotline();
                    
                }
            );

            OpenArgv = new RelayCommand
            (
                () =>
                {

                    
                    Argv argv = new Argv();
                    argv.Show();
         
                }
            );
			drag = new RelayCommand<object>
            (
                o =>
                {
                    ((Window)o).DragMove();
                }
            );



            Messenger.Default.Register<LineData>(this, "Main", n => { tempData = n; Messenger.Default.Send<string>(tempData.getYpar(), "Argv"); }); 
                       //n =>
                       //{
                       //    tempData = n;
                       //}


            Messenger.Default.Register<ArgvL>(this, "Main", n => { tempArgv = n; Color = tempArgv.color.ToString(); Title = tempArgv.title; });
           //            n =>
           //            {
           //                tempArgv = n;
           //                Color = tempArgv.color.ToString();
           //                Title = tempArgv.title;
           //            }
           //);

        }

        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}
    }
}