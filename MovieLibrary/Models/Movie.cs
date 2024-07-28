using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int YearOfRelease { get; set; }
        public string Genre { get; set; }

        public Movie(int id , string name, int yearOfRelease , string genre)
        {
            Id = id;
            Name = name;
            YearOfRelease = yearOfRelease;
            Genre = genre;
        }

        public static Movie CreateMovie(int id, string name, int yearOfRelease, string genre)
        {
            return new Movie(id, name, yearOfRelease, genre);
        }

        public override string ToString()
        {
            return $"================{Name}===================\n" +
                $"Id : {Id}\n" +
                $"Year Of Release : {YearOfRelease}\n" +
                $"Genre : {Genre}";
        }
    }
}
