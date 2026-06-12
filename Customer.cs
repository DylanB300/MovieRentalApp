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
        private string custLogin;
        private string custPassword;
        private string custName;
        private string custPhone;
        private string custEmail;

        //Properties 
        public string CustLogin { get { return custLogin; } set { custLogin = value; } }
        public string CustPassword { get { return custPassword; } set { custPassword = value; } }
        public string CustName { get { return custName; } set {custName = value; } }
        public string CustPhone { get { return custPhone; } set {custPhone = value; } }
        public string CustEmail { get { return custEmail; } set {custEmail = value; } }

        //Constructor
        public Customer(string custLogin, string custPassword, string custName, string custPhone, string custEmail )
        {
            CustLogin = custLogin;
            CustPassword = custPassword;
            CustName = custName;
            CustPhone = custPhone;
            CustEmail = custEmail;
        }

        //Methods
        public void DisplayCustomerDetails()
        {
            Console.WriteLine($"\nName: \t{CustName} \nPhone: \t{CustPhone}\nEmail: \t{CustEmail}");
        }//End of Display Customer Details Method



    }
}
