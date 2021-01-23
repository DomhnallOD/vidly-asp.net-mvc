using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyApp.Models;
using VidlyApp.ViewModels;
using System.Data.Entity;

namespace VidlyApp.Controllers
{
    public class MoviesController : Controller
    {

        private ApplicationDbContext _context; //Create an instance of the ApplicationDdContext

        public MoviesController()
        {
            _context = new ApplicationDbContext(); //Initialise it with the creation of a new Customerscontroller object
        }

        protected override void Dispose(bool disposing) //Override the displose method of the controller to tell it to dispose of the ApplicationDbContext instance when it's done
        {
            _context.Dispose();
        }
        // GET: Movies/Details
        // The controller action which is called when the Movies/Random URL is requested
        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
            {
                return HttpNotFound();
            }
            else
            {

                return View(movie);
            }
        }

        // PUT: Movies/Edit
        [Authorize(Roles = "CanManageMovies")]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
            {
                return HttpNotFound();
            }
            else
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };
                return View("MovieForm", viewModel);
            }
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        [Route("Movies/New")] 
        public ActionResult New() //The action that returns the movie form
        {
            var genres = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel
            {
                Genres = genres
            };
            return View("MovieForm", viewModel);
        }

        [HttpPost] //Ensure this action can only be called by HttpPost not HttpGet. If actions modify data, they should never be accessible by HTttpGet
        [ValidateAntiForgeryToken]
        [Route("Movies/Save")]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Save(Movie movie) //MVC Framework will automatically map request data to this model
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };

                return View("MovieForm", viewModel);
            }

            if (movie.Id == 0) //If user is posing a new movie (without an ID value)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie); //Add new movie
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id); //Else, get the Movie object from DBModel
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.DateAdded = movie.DateAdded;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;

            }

            _context.SaveChanges();//Persist data to the DB. SaveChanges() goes through all the modified objects as recorded in the DBContex, and generates an SQL statement for each change.

            return RedirectToAction("Movies", "Movies");
        }

        [Route("Movies")]
        public ActionResult Movies()
        {
            if (User.IsInRole(RoleName.CanManageMovies))
                return View("Movies");

                return View("ReadOnlyMovies");


        }

        public ActionResult Index(int? pageIndex, string sortBy)
        {
            //Default params if values are null
            if (!pageIndex.HasValue)
                pageIndex = 1;
            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            return Content(String.Format("pageIndex={0}&sortBy ={1}", pageIndex, sortBy));
        }


        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);

        } 
    }


}