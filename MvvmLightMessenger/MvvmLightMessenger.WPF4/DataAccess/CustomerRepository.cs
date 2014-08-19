using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Resources;
using System.Xml;
using System.Xml.Linq;
using MvvmLightMessenger.WPF4.Model;

namespace MvvmLightMessenger.WPF4.DataAccess
{
    public class CustomerRepository
    {

        #region Constructor

        /// <summary>
        /// Creates a new repository of customers.
        /// </summary>
        /// <param name="customerDataFile">The relative path to an XML resource file that contains customer data.</param>
        public CustomerRepository()
        {
            LoadCustomers();
        }

        #endregion // Constructor

        #region Public Interface
        public int? AddCustomer(Customer customer)
        {
            // 参数错误
            if (customer == null)
                return 1;

            if (!ContainsCustomer(customer))
            {
                // 编号等于数据库表最大编号+1
                customer.ID = dbCustomers.Max(dc => dc.ID) + 1;

                // 模拟失败（随机）
                if (new Random().Next(1, 10) < 5)
                    return -1;

                // 提交修改到数据库
                dbCustomers.Add(customer);

                // 返回操作成功
                return null;
            }

            // 已存在
            return 2;
        }

        public int? DeleteCustomer(Customer customer)
        {
            // 参数错误
            if (customer == null)
                return 1;

            // 获取要修改的数据库记录
            Customer dbCustomer = dbCustomers.SingleOrDefault(dc => dc.ID == customer.ID);

            // 不存在
            if (dbCustomer == null)
                return 3;

            // 模拟失败（随机）
            if (new Random().Next(1, 10) < 5)
                return -1;

            dbCustomers.Remove(dbCustomer);

            // 返回操作成功
            return null;
        }

        public int? ModifyCustomer(Customer customer)
        {
            // 参数错误
            if (customer == null)
                return 1;

            // 获取要修改的数据库记录
            Customer dbCustomer = dbCustomers.SingleOrDefault(dc=>dc.ID == customer.ID);

            // 不存在
            if (dbCustomer == null)
                return 3;

            // 模拟失败（随机）
            if (new Random().Next(1, 10) < 5)
                return -1;

            // 提交修改到数据库
            dbCustomer.IsCompany = customer.IsCompany;
            dbCustomer.LastName = customer.LastName;
            dbCustomer.FirstName = customer.FirstName;
            dbCustomer.Email = customer.Email;

            // 返回操作成功
            return null;
        }

        /// <summary>
        /// Returns true if the specified customer exists in the
        /// repository, or false if it is not.
        /// </summary>
        public bool ContainsCustomer(Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException("customer");

            return dbCustomers.Count(c => c.Email == customer.Email) > 0;
        }

        /// <summary>
        /// Returns a shallow-copied list of all customers in the repository.
        /// </summary>
        public List<Customer> GetCustomers()
        {
            return (from c in dbCustomers
                    select new Customer
                    {
                        Email = c.Email,
                        FirstName = c.FirstName,
                        ID = c.ID,
                        IsCompany = c.IsCompany,
                        LastName = c.LastName,
                        TotalSales = c.TotalSales
                    }).ToList();
        }

        #endregion // Public Interface

        #region 模拟数据库表数据
        static List<Customer> dbCustomers;
        static void LoadCustomers()
        {
            if (dbCustomers==null)
                dbCustomers =  new List<Customer>
                {
                    new Customer{ID=1,LastName="Smith",FirstName="Josh",IsCompany=false,Email="josh@contoso.com",TotalSales=32132.92},
                    new Customer{ID=2,LastName="Bujak",FirstName="Greg",IsCompany=false,Email="Greg@contoso.com",TotalSales=7642.11},
                    new Customer{ID=3,LastName="Crafton",FirstName="Jim",IsCompany=false,Email="Jim@contoso.com",TotalSales=123989.10},
                    new Customer{ID=4,LastName="Nolan",FirstName="Jordan",IsCompany=false,Email="Jordan@contoso.com",TotalSales=235.12},
                    new Customer{ID=5,LastName="Hinkson",FirstName="Grant",IsCompany=false,Email="Grant@contoso.com",TotalSales=4541.21},
                    new Customer{ID=6,LastName="Shifflett",FirstName="Karl",IsCompany=false,Email="Karl@contoso.com",TotalSales=8577.33},
                    new Customer{ID=7,LastName="Walker",FirstName="Wilfred",IsCompany=false,Email="Wilfred@contoso.com",TotalSales=11102.11},
                    new Customer{ID=8,LastName="McCort",FirstName="Denise",IsCompany=false,Email="Denise@contoso.com",TotalSales=9881.11},
                    new Customer{ID=9,FirstName="Alfreds Futterkiste",IsCompany=true,Email="maria@contoso.com",TotalSales=2322.66},
                    new Customer{ID=10,FirstName="Eastern Connection",IsCompany=true,Email="ann@contoso.com",TotalSales=23562.00},
                    new Customer{ID=11,FirstName="Hanari Carnes",IsCompany=true,Email="alex@contoso.com",TotalSales=232355.11},
                    new Customer{ID=12,FirstName="Königlich Essen",IsCompany=true,Email="philip@contoso.com",TotalSales=454671.55},
                };
        }

        #endregion // Private Helpers
    }
}
