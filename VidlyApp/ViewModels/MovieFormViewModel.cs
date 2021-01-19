using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VidlyApp.Models;

namespace VidlyApp.ViewModels
{
    public class MovieFormViewModel
    {


        public IEnumerable<Genre> Genres { get; set; } //In the view, we dont need any of the functionality of a List (add, remove, update etc.) We just need to iterate over and read the elements. IEnumerable is ideal for this purpose.


        [Required]
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Genre ID")]
        public byte? GenreId { get; set; }

        [Required]
        [Range(1, 20)]
        [Display(Name = "Number In Stock")]
        public int? NumberInStock { get; set; }


        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Movie" : "New Movie"; //Condition > If true : Otherwise
            }
        }

        public MovieFormViewModel() //Default constructor
        {
            Id = 0;

        }
        public MovieFormViewModel(Movie movie) //Overloaded constructor
        {

            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
            GenreId = movie.GenreId;
        }
    }
}