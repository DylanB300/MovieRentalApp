using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRentalApp
{
    public class Movie
    {
        //feild 
        public string Title { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }
        public double RentalPrice { get; set; }

        //properties 

        //constructor
        public Movie(string title, string genre, int year, double rentalPrice)
        {
            Title = title;
            Genre = genre;
            Year = year;
            RentalPrice = rentalPrice;
        }

        //methods 

        public static void ViewMovies(List<Movie> movies)
        {
            //this method displays movies from the list 
            Console.WriteLine("\nAvailable Movies");
            Console.WriteLine("----------------");

            foreach (Movie movie in movies)
            {
                Console.WriteLine($"Title: {movie.Title}");
                Console.WriteLine($"Genre: {movie.Genre}");
                Console.WriteLine($"Year: {movie.Year}");
                Console.WriteLine();
            }
        }
    }

}
