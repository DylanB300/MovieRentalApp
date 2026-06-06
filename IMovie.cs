using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRentalApp
{
    public interface IMovie
    {
        List<Movie> Movies { get; }
        void AddMovie(Movie movie);
        void RemoveMovie(string title); 
    }
}
