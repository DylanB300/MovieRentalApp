using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRentalApp
{
    public class Admin
    {
        //Fields
        private string adminLogin;
        private string adminPassword;

        //Properties
        public string AdminLogin { get { return adminLogin; } set { adminLogin = value; } }
        public string AdminPassword { get { return adminPassword; } set { adminPassword = value; } }


        //Constructor
        public Admin(string adminLogin, string adminPassword)
        {
            AdminLogin = adminLogin;
            AdminPassword = adminPassword;
        }
    }

}

