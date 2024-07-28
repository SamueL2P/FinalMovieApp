using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieLibrary.Exceptions;
using MovieLibrary.Models;
using MovieLibrary.Services;

namespace MovieLibrary.Repository
{
    public class MovieManager
    {
        public static List<Movie> movies = new List<Movie>();
        public static void ManageMovies()
        {
            movies = DataSerializer.DeserializeMovies();
        }

        public static void AddNewMovie(int id , string name ,int yearOfRelease, string genre)
        {
            if (movies.Count() >= 5)
            {
                throw new MovieStoreCapacityFullException("Cannot add movie. Store limit exceeded.");
            }
            else
            {  
                Movie newMovie = Movie.CreateMovie(id, name, yearOfRelease, genre);
                movies.Add(newMovie);
               
            }

        }

        public static List<Movie> DisplayAllMovies()
        {
            if (movies.Count == 0)
                throw new MovieStoreEmptyException("Movie store Empty");
            else
                return movies;
        }

        public static Movie FindMovieById(int id)
        {
            try
            {
                Movie findMovie = null;
                
                findMovie = movies.Where(item => item.Id == id).FirstOrDefault();
                if (findMovie == null)
                    throw new MovieNotFoundException("Movie not found!");
                return findMovie;
            }
            catch (FormatException)
            {
                throw new InvalidMovieIdException("Invalid movie ID. Please enter a valid number.");
            }
        }
        public static Movie UpdateMovieDetails(int id)
        {
            Movie findMovie = FindMovieById(id);
            if (findMovie == null)
                throw new MovieNotFoundException("Movie not found!");
            else
            {
                return findMovie;
            }
        }
        public static void UpdateMovieField(int choice, Movie findMovie , string field)
        {

                switch (choice)
                {
                    case 1:
                        int.TryParse(field, out int id);
                        findMovie.Id = id;
                        break;
                    case 2:      
                        findMovie.Name = field;
                        break;
                    case 3:
                        int.TryParse(field, out int year);
                        findMovie.YearOfRelease = year;
                        break;
                    case 4:
                        findMovie.Genre = field;  
                        break;
                    default:
                        throw new InvalidMenuChoiceException("Enter field choice properly");
                        

                }  

        }

        public static void RemoveMovie(int id)
        {
            Movie findMovie = FindMovieById(id);
            if (findMovie != null)
            {
                movies.Remove(findMovie);
                
            }
            else
                throw new MovieNotFoundException("Movie not found!");
        }

        public static void ClearAllMovies()
        {
            if (movies.Count == 0)
                throw new MovieStoreEmptyException("Movie store already empty");
            else
                movies.Clear();
        }

        public static void ExitMovieStore()
        {
            DataSerializer.SerializeMovies(movies);
        }

    }
}
