using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

using MvvmLightMessenger.WPF4.Model;
using MvvmLightMessenger.WPF4.DataAccess;

namespace MvvmLightMessenger.WPF4.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm/getstarted
    /// </para>
    /// </summary>
    public class CustomerViewModel : DialogViewModelBase
    {
        #region Fields

        readonly Customer _customer;
        readonly CustomerRepository _customerRepository;
        string _customerType;
        string[] _customerTypeOptions;

        #endregion // Fields

        public CustomerViewModel(Customer customer)
        {
            _customerRepository = new CustomerRepository();

            _customer = customer;

            if (_customer.IsCompany)
                _customerType = "公司";
            else
                _customerType = "个人";
 
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real": Connect to service, etc...
            ////}
        }

        public CustomerViewModel()
            : this(new Customer())
        {
        }


        #region Presentation Properties

        public string PageInfo
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets/sets a value that indicates what type of customer this is.
        /// This property maps to the IsCompany property of the Customer class,
        /// but also has support for an 'unselected' state.
        /// </summary>
        public string CustomerType
        {
            get { return _customerType; }
            set
            {
                if (value == _customerType || string.IsNullOrEmpty(value))
                    return;

                _customerType = value;

                if (_customerType == "公司")
                {
                    _customer.IsCompany = true;
                }
                else if (_customerType == "个人")
                {
                    _customer.IsCompany = false;
                }

                base.RaisePropertyChanged("CustomerType");

                base.RaisePropertyChanged("LastName");
            }
        }

        /// <summary>
        /// Returns a list of strings used to populate the Customer Type selector.
        /// </summary>
        public string[] CustomerTypeOptions
        {
            get
            {
                if (_customerTypeOptions == null)
                {
                    _customerTypeOptions = new string[]
                    {
                        "不明",
                        "个人",
                        "公司"
                    };
                }
                return _customerTypeOptions;
            }
        }

        public override string DisplayName
        {
            get
            {
                if (!this.ExistCustomer)
                {
                    return "新顾客";
                }
                else if (_customer.IsCompany)
                {
                    return _customer.FirstName;
                }
                else
                {
                    return string.Format("{0}, {1}", _customer.LastName, _customer.FirstName);
                }
            }
        }

        #endregion // Presentation Properties

        #region Customer Properties

        public string Email
        {
            get { return _customer.Email; }
            set
            {
                if (value == _customer.Email)
                    return;

                _customer.Email = value;

                base.RaisePropertyChanged("Email");
            }
        }

        public int ID
        {
            get { return _customer.ID; }
            set
            {
                if (value == _customer.ID)
                    return;

                _customer.ID = value;

                base.RaisePropertyChanged("ID");
            }
        }

        public string FirstName
        {
            get { return _customer.FirstName; }
            set
            {
                if (value == _customer.FirstName)
                    return;

                _customer.FirstName = value;

                base.RaisePropertyChanged("FirstName");
                base.RaisePropertyChanged("DisplayName");
            }
        }

        public bool IsCompany
        {
            get { return _customer.IsCompany; }
        }

        public string LastName
        {
            get { return _customer.LastName; }
            set
            {
                if (value == _customer.LastName)
                    return;

                _customer.LastName = value;

                base.RaisePropertyChanged("LastName");
                base.RaisePropertyChanged("DisplayName");
            }
        }

        public double TotalSales
        {
            get { return _customer.TotalSales; }
        }

        #endregion // Customer Properties


        /// <summary>
        /// Saves the customer to the repository.  This method is invoked by the SaveCommand.
        /// </summary>
        public int? Save()
        {
            int? result;

            // 新增
            if (_customer.ID == 0)
            {
                result = _customerRepository.AddCustomer(_customer);
            }
            else
            {
                result = _customerRepository.ModifyCustomer(_customer);
            }

            return result;
        }

        protected override void DoOK()
        {
            this.messageCallback = s =>
            {
                // 执行完成则关闭对话框，执行错误，则显示错误信息
                if (string.IsNullOrEmpty(s))
                {
                    CloseDialog();
                    return;
                }

                PageInfo = s;
                base.RaisePropertyChanged("PageInfo");
            };

            base.DoOK();
        }

        public int? Delete()
        {
            return _customerRepository.DeleteCustomer(_customer);
        }

        #region Private Helpers

        /// <summary>
        /// Returns true if this customer was created by the user and it has not yet
        /// been saved to the customer repository.
        /// </summary>
        bool ExistCustomer
        {
            get { return _customerRepository.ContainsCustomer(_customer); }
        }

        #endregion // Private Helpers

        
    }
}