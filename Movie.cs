using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRentalApp
{
    public class Movie : IMovie
    {
        public List<Movie> movies = new List<Movie>();

        public List<Movie> Movies => movies;

        //feild 
        public string Title { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }
        public double RentalPrice { get; set; }

        public Movie()
        {
        }

        //constructor
        public Movie(string title, string genre, int year, double rentalPrice)
        {
            Title = title;
            Genre = genre;
            Year = year;
            RentalPrice = rentalPrice;
        }

        //methods 

        public static void RentMovie(List<Movie> movies)
        {
            // Display available movies
            ViewMovies(movies);

            Console.WriteLine("Would you like to rent a movie? (Y/N)");
            string answer = Console.ReadLine();

            if (answer.ToUpper() == "Y")
            {
                Console.WriteLine("Enter the title of the movie you want to rent:");
                string movieTitle = Console.ReadLine();

                Movie selectedMovie = movies.FirstOrDefault(m => m.Title.ToLower() == movieTitle.ToLower());

                if (selectedMovie != null)
                {
                    Console.WriteLine($"You have rented '{selectedMovie.Title}'");
                    Console.WriteLine($"Rental Price: ${selectedMovie.RentalPrice}");
                }
                else
                {
                    Console.WriteLine("Movie not found.");
                }
            }
            else
            {
                Console.WriteLine("Returning to menu...");
            }
        }

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
                Console.WriteLine($"price: {movie.RentalPrice}");
            }

        }

        public void AddMovie(Movie movie)
        {
            Movies.Add(movie);
        }

        public void RemoveMovie(string title)
        {
            foreach (Movie movie in Movies)
            {
                if (movie.Title == title)
                {
                    Movies.Remove(movie);
                    Console.WriteLine("Movie removed");
                    return;
                }
            }

            Console.WriteLine("Movie not found");
        }
    }

}
