using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRentalApp
{
    public class Customer
    {

        //Fields
        private string custPassword;
        private string custLogin;
        private string custName;
        private string custPhone;
        private string custEmail;
        
        //Properties 
        public string CustPassword { get { return custPassword; } set { custPassword = value; } }
        public string CustLogin { get { return custLogin; } set { custLogin = value; } }
        public string CustName { get { return custName; } set {custName = value; } }
        public string CustPhone { get { return custPhone; } set {custPhone = value; } }
        public string CustEmail { get { return custEmail; } set {custEmail = value; } }

        //Constructor
        public Customer(string custPassword, string custLogin, string custName, string custPhone, string custEmail )
        {
            CustPassword = custPassword;
            CustLogin = custLogin;
            CustName = custName;
            CustPhone = custPhone;
            CustEmail = custEmail;
        }

        //Methods
        public void DisplayCustomerDetails()
        {
            Console.WriteLine($"\nName: \t{CustName} \nPhone: \t{CustPhone}\nEmail: \t{CustPhone}");
        }



    }
}
