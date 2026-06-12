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

        //Field 
        public string Title { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }
        public double RentalPrice { get; set; }

        //Constructor
        public Movie()
        {
        }

        public Movie(string title, string genre, int year, double rentalPrice)
        {
            Title = title;
            Genre = genre;
            Year = year;
            RentalPrice = rentalPrice;
        }

        //Methods 
        //Renting Movie Method
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
                    movies.Remove(selectedMovie);
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
        }//End of RentMovie method

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
                Console.WriteLine($"Price: {movie.RentalPrice}");
                Console.WriteLine("---------------------------");
            }

        }//End of ViewMovies

        //Method to Add Movies
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
        }//End of AddMovie

        //method to search movies in the main menu of our app
        public static void SearchMovie(List<Movie> movies)
        {
            Console.WriteLine("Enter movie title to search:");
            string title = Console.ReadLine();

            Movie foundMovie = movies.FirstOrDefault(m =>
                m.Title.ToLower() == title.ToLower());

            if (foundMovie != null)
            {
                Console.WriteLine("\nMovie Found");
                Console.WriteLine("-----------");
                Console.WriteLine($"Title: {foundMovie.Title}");
                Console.WriteLine($"Genre: {foundMovie.Genre}");
                Console.WriteLine($"Year: {foundMovie.Year}");
                Console.WriteLine($"Price: ${foundMovie.RentalPrice}");
            }
            else
            {
                Console.WriteLine("Movie not found.");
            }
        }//End of search movie

        //Method to update movie information
        public void UpdateMovie(string title)
        {
            Movie movieUpdate = Movies.FirstOrDefault(
                m => m.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

            if (movieUpdate == null)
            {
                Console.WriteLine("Movie not found.");
                return;
            }

            Console.WriteLine("Current Movie Details");
            Console.WriteLine($"Title: {movieUpdate.Title}");
            Console.WriteLine($"Genre: {movieUpdate.Genre}");
            Console.WriteLine($"Year: {movieUpdate.Year}");
            Console.WriteLine($"Price: {movieUpdate.RentalPrice}");

            Console.WriteLine("Enter new Title:");
            movieUpdate.Title = Console.ReadLine();

            Console.WriteLine("Enter new Genre:");
            movieUpdate.Genre = Console.ReadLine();

            Console.WriteLine("Enter new Year:");
            movieUpdate.Year = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter new rental Price:");
            movieUpdate.RentalPrice = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Movie updated successfully.");
        }//End of UpdateMovie method
    }

}
