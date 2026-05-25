namespace MovieRentalApp
{
    internal class Program
    {
        //Declare the customer list
        static List<Customer> customers = new List<Customer>();
        static void Main(string[] args)
        {
            Console.WriteLine("movie app");


            int option;
            char choice = 'y';

            do
            {
                Console.WriteLine("1. view movie");
                Console.WriteLine("2. customer info");
                Console.WriteLine("99. exit");
                option = Convert.ToInt32(Console.ReadLine);

                switch (option)
                {
                    case 1:
                        Console.WriteLine("your choice is veiw movies");
                        break;
                    case 2:
                        Console.WriteLine("you choice is view customer information");
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
        }


    }//End of program
}//End of namespace
