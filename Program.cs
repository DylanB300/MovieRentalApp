using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace MovieRentalApp
{
    internal class Program
    {
        //Declare the customer list
        static List<Customer> customers = new List<Customer>();
        static IMovie Movies = new Movie();
        static Admin admin = new Admin("admin", "pass");

        static void Main(string[] args)
        {
            LoadMovies();
            //propt user to log in for sign in 
            //variables for switch case menu 
            int menuOption;
            char choice = 'y';
            string user = "";
            do {
                Console.WriteLine("Welcome to the movie app");
                Console.WriteLine("Please select an option");
                Console.WriteLine("1. Sign up");
                Console.WriteLine("2. Log in");
                Console.WriteLine("99. Exit");

                menuOption = Convert.ToInt32(Console.ReadLine());

                switch (menuOption)
                {
                    case 1:
                        AddCustomer();
                        break;
                    case 2:
                        user = LoginCustomer();
                        if (user == "none")
                        {
                            Environment.Exit(0);
                        }
                        else
                        {
                            choice = 'n';
                        }
                        break;
                        case 99:
                            Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("this was not an option");
                        Console.WriteLine("would you like to try agian (y/n)");
                        break;
                }
            }while (choice == 'y');

            if (user == "admin")
            {
                AdminMenu();
            }
            else if (user == "customer")
            {
                CustomerMenu();
            }

        }//End of main
        
        //Methods
        public static void AddCustomer()
        {
            Console.WriteLine("Adding customer");
            Console.WriteLine("Enter your Log in");
            string custLoginEntered = Console.ReadLine();
            Console.WriteLine("Enter your password");
            string custPasswordEntered = ReadPassword();
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

        public static string LoginCustomer()
        {
            int attempts = 0;

            while (attempts < 3)
            {
                Console.WriteLine("what is your login name");
                string login = Console.ReadLine();
                Console.WriteLine("please enter your password");
                string passWord = ReadPassword();
                Console.WriteLine();


                if (login == admin.AdminLogin && passWord == admin.AdminPassword)
                {
                    Console.WriteLine("Admin login successful");
                    return "admin";
                }
                else if (customers.Any(c => c.CustLogin == login && c.CustPassword == passWord))
                {
                    Console.WriteLine("Customer login successful");
                    return "customer";
                }


                attempts++;
                Console.WriteLine($"invalid login Attempts remaining: {3 - attempts}");


            }
            Console.WriteLine("You have used all 3 login attempts.");
            return "none";
        }//end of login method

        //Method for Admin user switch case
        public static void AdminMenu()
        {
            int option;
            char choice;

            do
            {
                Console.WriteLine("1. View Movies");
                Console.WriteLine("2. Add Movie");
                Console.WriteLine("3. Remove Movie");
                
                Console.WriteLine("99. Exit");

                option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Movie.ViewMovies(Movies.Movies);
                        break;

                    case 2:
                        AddingMovie();
                        break;

                    case 3:
                        RemovingMovie();
                        break;

                    case 99:
                        Environment.Exit(0);
                        return;

                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }

                Console.WriteLine("Continue? (y/n)");
                choice = Convert.ToChar(Console.ReadLine());

            } while (choice != 'n');
        }//End of AdminMenu

        //Method for Customer user switch case
        public static void CustomerMenu()
        {
            int option;
            char choice;

            do
            {
                Console.WriteLine("1. View Movies");

                Console.WriteLine("2. Customer Info");
                Console.WriteLine("3. Rent Movie");
                Console.WriteLine("4. search movie");
                Console.WriteLine("99. Exit");

                option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Movie.ViewMovies(Movies.Movies);
                        break;

                    case 2:
                        ViewCustomer();
                        break;

                    case 3:
                        Movie.RentMovie(Movies.Movies);
                        break;

                    case 4:
                        Movie.SearchMovie(Movies.Movies);
                        break;

                    case 99:
                        Environment.Exit(0);
                        return;

                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }

                Console.WriteLine("Continue? (y/n)");
                choice = Convert.ToChar(Console.ReadLine());

            } while (choice != 'n');
        }//End of CustomerMenu






        public static void ViewCustomer()
        {
            foreach (Customer cust in customers)
            {
                cust.DisplayCustomerDetails();
            }
        }//End of ViewCustomer Method

        public static void LoadMovies()
        {
            Movies.AddMovie(new Movie("Avatar", "Sci-Fi", 2009, 10));
            Movies.AddMovie(new Movie("Titanic", "Romance", 1997, 10));
            Movies.AddMovie(new Movie("The Dark Knight", "Action", 2008, 10));
            Movies.AddMovie(new Movie("Toy Story", "Animation", 1995, 10));
        }//End of LoadMovies

        //Adding Movies to the list
        public static void AddingMovie()
        {
            Console.WriteLine("Adding Movie");

            Console.WriteLine("Enter Title: ");
            string titleEntered = Console.ReadLine();

            Console.WriteLine("Enter Genre: ");
            string genreEntered = Console.ReadLine();

            Console.Write("Enter Year: ");
            int yearEntered = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Cost of Movie: ");
            double priceEntered = Convert.ToDouble(Console.ReadLine());

            Movie newMovie = new Movie(titleEntered, genreEntered, yearEntered, priceEntered);

            Movies.AddMovie(newMovie);

            Console.WriteLine("Movie has been added");
        }//End of AddingMovie

        //Removing Movies from the list
        public static void RemovingMovie()
        {
            Console.WriteLine("Removing Movie");

            Console.WriteLine("Enter Title of Movie you wish to Remove: ");
            string titleEntered = Console.ReadLine();
            
            Movies.RemoveMovie(titleEntered);
        }//End of Removing Movies


        public static string ReadPassword()
        {
            string password = "";
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);

                if (key.Key != ConsoleKey.Backspace &&
                    key.Key != ConsoleKey.Enter)
                {
                    password += key.KeyChar;
                    Console.Write("*");
                }
                else if (key.Key == ConsoleKey.Backspace &&
                         password.Length > 0)
                {
                    password = password.Substring(0, password.Length - 1);
                    Console.Write("\b \b");
                }

            } while (key.Key != ConsoleKey.Enter);

            Console.WriteLine();
            return password;
        }


        
    }//End of program
}//End of namespace
