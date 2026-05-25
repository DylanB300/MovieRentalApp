namespace MovieRentalApp
{
    internal class Program
    {
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
        }
    }
}
