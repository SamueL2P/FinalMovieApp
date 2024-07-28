using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieLibrary.Exceptions;
using MovieLibrary.Repository;

namespace MovieManagement.ViewControllers
{
    internal class MovieStore
    {
        public static void DisplayMenu()
        {
            MovieManager.ManageMovies();

            while (true)
            {
                
                Console.WriteLine("\nWelcome to movie store developed by : Samuel\n" +
                    "1. Add new Movie\n" +
                    "2. Display All Movies\n" +
                    "3. Find Movie by Id\n" +
                    "4. Update Movie\n" +
                    "5. Remove Movie by Id\n" +
                    "6. Clear All Movies\n" +
                    "7. Exit");
                try
                {
                    int choice = Convert.ToInt32(Console.ReadLine());
                    DoTask(choice);
                    
                }
                catch (InvalidMenuChoiceException imc)
                {
                    Console.WriteLine(imc.Message);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }

            }
        }



        static void DoTask(int choice)
        {

            try
            {
                switch (choice)
                {
                    case 1:
                        Add();
                        break;
                    case 2:
                        Display();
                        break;
                    case 3:
                        Find();
                        break;
                    case 4:
                        Update();
                        break;

                    case 5:
                        Remove();
                        break;
                    case 6:
                        MovieManager.ClearAllMovies();
                        Console.WriteLine("All movies cleared!!");
                        break;
                    case 7:
                        MovieManager.ExitMovieStore();
                        Environment.Exit(0);

                        break;
                    default:
                        throw new InvalidMenuChoiceException("Please enter a valid input!");



                }
            }
            catch (MovieStoreCapacityFullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (MovieNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (MovieStoreEmptyException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (InvalidMovieIdException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }



        }

        static void Add()
        {
            Console.WriteLine("Enter Id : ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Name : ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Year Of Release : ");
            int yearOfRelease = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Genre : ");
            string genre = Console.ReadLine();
            MovieManager.AddNewMovie(id, name, yearOfRelease, genre);
            Console.WriteLine("New Movie Added Successfully");

        }

        static void Display()
        {
            var movies = MovieManager.DisplayAllMovies();
            movies.ForEach(movie => Console.WriteLine(movie));
        }

        static void Find()
        {
            Console.WriteLine("Enter Id:");
            int id = Convert.ToInt32(Console.ReadLine());
            var movie = MovieManager.FindMovieById(id);
            Console.WriteLine(movie);
        }

        static void Remove()
        {
            Console.WriteLine("Enter Id:");
            int id = Convert.ToInt32(Console.ReadLine());
            MovieManager.RemoveMovie(id);
            Console.WriteLine("Movie Removed Successfully!");
        }

        static void Update()
        {
            Console.WriteLine("Enter Id:");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Which field do you want to update ?");
            Console.WriteLine("1. Id \n2. Name\n3. Year Of Release \n4. Genre");
            int choice = Convert.ToInt32(Console.ReadLine());
            var findMovie = MovieManager.UpdateMovieDetails(id);
            Console.WriteLine("Enter Updated Field");
            var field = Console.ReadLine();

            try
            {
                MovieManager.UpdateMovieField(choice, findMovie, field);
                Console.WriteLine("Moive Field updated successfully");
            }
            catch (InvalidMenuChoiceException ex)
            {
                Console.WriteLine(ex.Message);
            }
  

        }

            

    }
}

