using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Data;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

using MvvmLightMessenger.WPF4.Model;
using MvvmLightMessenger.WPF4.DataAccess;

namespace MvvmLightMessenger.WPF4.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
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
    public class MainViewModel : ViewModelBase
    {
        public CustomerViewModel selectedCustomer;
        readonly CustomerRepository _customerRepository;

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            _customerRepository = new CustomerRepository();

            this.CreateAllCustomers();

            //if (IsInDesignMode)
            //{
            //    // Code runs in Blend --> create design time data.
            //}
            //else
            //{
            //    _customerRepository = new CustomerRepository();

            //    this.CreateAllCustomers();

            //}


        }

        void CreateAllCustomers()
        {
            List<CustomerViewModel> all =
                (from cust in _customerRepository.GetCustomers()
                 select new CustomerViewModel(cust)).ToList();


            this.AllCustomers = new ObservableCollection<CustomerViewModel>(all);
        }

        #endregion

        #region ICommand
        RelayCommand _AddCustomerCommand;
        public RelayCommand AddCustomerCommand
        {
            get
            {
                if (_AddCustomerCommand == null)
                    _AddCustomerCommand = new RelayCommand(
                        () => AddCustomer());

                return _AddCustomerCommand;
            }
        }

        RelayCommand _EditCustomerCommand;
        public RelayCommand EditCustomerCommand
        {
            get
            {
                if (_EditCustomerCommand == null)
                    _EditCustomerCommand = new RelayCommand(
                        () => EditCustomer(),
                        () => selectedCustomer != null);

                return _EditCustomerCommand;
            }
        }

        RelayCommand _DeleteCustomerCommand;
        public RelayCommand DeleteCustomerCommand
        {
            get
            {
                if (_DeleteCustomerCommand == null)
                    _DeleteCustomerCommand = new RelayCommand(
                        () => DeleteCustomer(),
                        () => selectedCustomer != null);

                return _DeleteCustomerCommand;
            }
        }

        public RelayCommand<IList> SelectionChangeCommand
        {
            get
            {
                return new RelayCommand<IList>
                    (
                        (selectedItems) =>
                        {
                            TotalSelectedSales = 0;

                            CustomerViewModel firstCustomer = null;

                            if (selectedItems.Count > 0)
                                firstCustomer = selectedItems[0] as CustomerViewModel;

                            // 将选中第一条CustomerViewModel传递到主页面
                            selectedCustomer = firstCustomer;

                            // 更新按钮的可执行状态
                            EditCustomerCommand.RaiseCanExecuteChanged();
                            DeleteCustomerCommand.RaiseCanExecuteChanged();

                            foreach (dynamic Item in selectedItems)
                                TotalSelectedSales += Item.TotalSales;

                            RaisePropertyChanged("TotalSelectedSales");
                        }
                    );
            }
        }

        #endregion 

        #region Public Properties
        /// <summary>
        /// Returns a collection of all the CustomerViewModel objects.
        /// </summary>
        public ObservableCollection<CustomerViewModel> AllCustomers { get; private set; }

        /// <summary>
        /// Returns the total sales sum of all selected customers.
        /// </summary>
        public double TotalSelectedSales
        {
            get;
            private set;
        }


        protected DialogViewModelBase _dialogViewModel;
        public DialogViewModelBase DialogViewModel
        {
            get { return _dialogViewModel; }
            private set
            {
                if (value != _dialogViewModel)
                {

                    _dialogViewModel = value;

                    base.RaisePropertyChanged("DialogViewModel");
                }

                // 显示对话框
                if (_dialogViewModel != null)
                    _dialogViewModel.DialogVisibility = System.Windows.Visibility.Visible;
            }
        }
        #endregion

        #region Private Helpers
        /// <summary>
        /// 保存顾客信息
        /// </summary>
        /// <param name="customerViewModel"></param>
        void SavedCustomer(CustomerViewModel customerViewModel, string operation)
        {
            #region 如果操作数据库成功，则更新列表显示
            // 操作类型
            if (operation == "Add")
            {
                AllCustomers.Add(customerViewModel);
            }
            else if (operation == "Delete")
            {
                AllCustomers.Remove(customerViewModel);
            }
            else if (operation == "Edit")
            {

            }
            #endregion
        }

        void AddCustomer()
        {
            CustomerViewModel newCustomerViewModel = new CustomerViewModel();

            // 显示编辑对话框
            DialogViewModel = newCustomerViewModel;

            // 在新增顾客对话框中点击确定时，执行消息的方法
            RegisterDialogMessage(DialogViewModel.MessageID, DialogViewModel, "Add");
        }

        void EditCustomer()
        {
            // 显示编辑对话框
            DialogViewModel = selectedCustomer;

            // 在修改顾客对话框中点击确定时，执行消息的方法
            RegisterDialogMessage(DialogViewModel.MessageID, DialogViewModel, "Edit");
        }

        void DeleteCustomer()
        {
            MessageBoxViewModel messgeboxviewmodel = new MessageBoxViewModel();

            messgeboxviewmodel.Content = string.Format("确定要删除顾客信息：名称：{0}，Emai：{1}?",
                selectedCustomer.DisplayName,
                selectedCustomer.Email);

            // 显示删除对话框
            DialogViewModel = messgeboxviewmodel;

            // 注册删除顾客的消息，
            // 由于MessageBoxViewModel是公共模块，消息标识设置为messgeboxviewmodel的MessageID
            RegisterDialogMessage(DialogViewModel.MessageID, selectedCustomer, "Delete");
        }

        /// <summary>
        /// 与弹出的对话框进行交互，一般将主界面作为消息的载体，原因如下：
        /// 弹出对话框的生命周期较短，而且需要重复打开，将弹出对话框中作为消息的载体会增加
        /// 消息清理的成本，即在每次关闭对话框时要对消息进行清理，否则每打开一次对话框，消息执行次数会递增
        /// </summary>
        /// <param name="messageID">
        /// 作为可以重复使用的模块，需要使用消息标识将消息的载体与发送方进行关联，
        /// 消息标识（messageID）由对话框ViewModel在实例化时自动生成，从而保证消息发送者与接受者一一对应
        /// </param>
        /// <param name="viewModel"></param>
        /// <param name="operation"></param>
        void RegisterDialogMessage(System.Guid messageID, DialogViewModelBase viewModel,string operation)
        {
            string operationText;

            CustomerViewModel customerViewModel = viewModel as CustomerViewModel;

            // 在弹出对话框中点击确定时，执行消息的方法
            Messenger.Default.Register<NotificationMessageAction<string>>(
                this, 
                messageID,
                message =>
                {
                    if (message.Notification.ToUpper() == "OK")
                    {
                        string callbackValue = null;
                        int? iRet = null;

                        if (operation == "Delete")
                        {
                            iRet = customerViewModel.Delete();
                            operationText = "删除";
                        }
                        else
                        {
                            iRet = customerViewModel.Save();
                            operationText = operation == "Add" ? "新增": "修改";
                        }

                        // 如果操作成功，则更新列表显示
                        if (!iRet.HasValue)
                            SavedCustomer(customerViewModel, operation);
                        else
                            callbackValue = string.Format("{0}顾客{0}失败!", operationText, customerViewModel.DisplayName);

                        // 执行回调方法，如果操作失败，则显示错误信息
                        message.Execute(callbackValue);
                    }

                });
           
        }

        #endregion // Private Helpers

        public override void Cleanup()
        {
            // Clean up if needed
            Messenger.Default.Unregister(this);
            base.Cleanup();
        }
    }
}