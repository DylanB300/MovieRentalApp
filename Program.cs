using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace MovieRentalApp
{
    internal class Program
    {
        //Declare the customer list
        static List<Customer> customers = new List<Customer>();
        static List<Movie> movies = new List<Movie>();

        static void Main(string[] args)
        {
            LoadMovies();
            //propt user to log in for sign in 
            //variables for switch case menu 
            int menuOption;
            char loginchoice = 'y';
            char choice = 'y';
            bool loggedIn = false;
            //do {
            Console.WriteLine("welcome to the movie app");
            Console.WriteLine("plase selcet an option");
            Console.WriteLine("1. sign in");
            Console.WriteLine("2. log in");
            menuOption = Convert.ToInt32(Console.ReadLine());

            switch (menuOption)
            {
                case 1:
                    AddCustomer();
                    break;
                case 2:
                    loggedIn = LoginCustomer();
                    if (!loggedIn)
                    {
                        Environment.Exit(0);
                    }
                    break;
                default:
                    Console.WriteLine("this was not an option");
                    Console.WriteLine("would you like to try agian (y/n)");
                    break;
            }
            // }while (loginchoice != 'n');

            int option;


            do
            {
                Console.WriteLine("1. view movie");
                Console.WriteLine("2. customer info");
                Console.WriteLine("3. rent movie");
                Console.WriteLine("99. exit");
                option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Console.WriteLine("your choice is veiw movies");
                        Movie.ViewMovies(movies);
                        break;
                    case 2:
                        Console.WriteLine("you choice is view customer information");
                        //customer information method
                        ViewCustomer();
                        break;
                    case 3:
                        Movie.RentMovie(movies);
                        break;
                    case 99:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("this was not an option");
                        break;

                }//end of switch
                Console.WriteLine("do yo wish to continue");
                choice = Convert.ToChar(Console.ReadLine());


            } while (choice != 'n');
        }//End of main
        //Methods
        public static void AddCustomer()
        {
            Console.WriteLine("Adding customer");
            Console.WriteLine("Enter your Log in");
            string custLoginEntered = Console.ReadLine();
            Console.WriteLine("Enter your password");
            string custPasswordEntered = Console.ReadLine();
            Console.WriteLine("Enter your Name");
            string custNameEntered = Console.ReadLine();
            Console.WriteLine("Enter your phone number");
            string custPhoneEntered = Console.ReadLine();
            Console.WriteLine("Enter your Email");
            string custEmailEntered = Console.ReadLine();

            //Creating the object, Call the constructor
            Customer newCustomer = new Customer(custLoginEntered, custPasswordEntered, custNameEntered, custPhoneEntered, custEmailEntered);

            //Add the new Customer list
            customers.Add(newCustomer);
            Console.WriteLine("You have been registered");
        }//end of addcustomer 

        public static bool LoginCustomer()
        {
            int attempts = 0;

            while (attempts < 3)
            {
                Console.WriteLine("what is your login name");
                string login = Console.ReadLine();
                Console.WriteLine("plase enter your pssword");
                string passWord = Console.ReadLine();
                Console.WriteLine();


                if (login == "admin" && passWord == "pass")
                {
                    Console.WriteLine("admin login successful");
                    //admin method 
                    return true;
                }
                else if (customers.Any(c => c.CustLogin == login && c.CustPassword == passWord))
                {
                    Console.WriteLine("customer login successful");
                    return true;
                }


                attempts++;
                Console.WriteLine($"invalid login Attempts remaining: {3 - attempts}");


            }
            Console.WriteLine("You have used all 3 login attempts.");
            return false;
        }//end of login method

        public static void ViewCustomer()
        {
            foreach (Customer cust in customers)
            {
                cust.DisplayCustomerDetails();
            }
        }//End of ViewCustomer Method

        public static void LoadMovies()
        {
            movies.Add(new Movie("Avatar", "Sci-Fi", 2009, 10));
            movies.Add(new Movie("Titanic", "Romance", 1997, 10));
            movies.Add(new Movie("The Dark Knight", "Action", 2008, 10));
            movies.Add(new Movie("Toy Story", "Animation", 1995, 10));
        }
    }//End of program
}//End of namespace
