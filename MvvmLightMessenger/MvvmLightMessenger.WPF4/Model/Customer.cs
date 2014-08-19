using System;

namespace MvvmLightMessenger.WPF4.Model
{
    public class Customer
    {
        #region Creation
        public Customer()
        {
        }

        #endregion // Creation

        #region State Properties
        public int ID { get; set; }
        /// <summary>
        /// Gets/sets the e-mail address for the customer.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets/sets the customer's first name.  If this customer is a 
        /// company, this value stores the company's name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets/sets whether the customer is a company or a person.
        /// The default value is false.
        /// </summary>
        public bool IsCompany { get; set; }

        /// <summary>
        /// Gets/sets the customer's last name.  If this customer is a 
        /// company, this value is not set.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Returns the total amount of money spent by the customer.
        /// </summary>
        public double TotalSales { get; set; }

        #endregion // State Properties
    }
}
