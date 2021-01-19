using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Http;
using VidlyApp.Dtos;
using AutoMapper;

namespace VidlyApp.Models.Api
{
    public class MoviesController : ApiController
    {


        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext(); //Instantiate it
        }

        // GET /api/movies
        public IHttpActionResult GetMovies()
        {
            return Ok(_context.Movies.Include("Genre").ToList().Select(Mapper.Map<Movie, MovieDto>));
        }

        // GET /api/movies/1
        public IHttpActionResult GetMovie(int Id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == Id); //Get the movie record if it's there

            if (movie == null)
                throw new HttpResponseException(HttpStatusCode.NotFound); //If not there, throw exception

            return Ok(Mapper.Map<Movie, MovieDto>(movie)); //Otherwise, return customer mapped to Dto
        }

        // POST /api/movies
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            movieDto.DateAdded = DateTime.Now;
            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie); //Add object to ApplicationDBContext
            _context.SaveChanges(); //Persist chagnes to the DB
           

            movieDto.Id = movie.Id;
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto); //When you successfully make a post request, RESTful convention states you should respond with the URI of the newwly created resource, as well as a copy of that resource, all wrapped up i a 201:OK response
        }

        // PUT /api/movies/1
        [HttpPut]
        public void UpdateMovie(int id, MovieDto movieDto) //Id is read from the URL, while customer is passed in the request body
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(movieDto, movieInDb);

            _context.SaveChanges();
        }

        // DELETE /api/customers/1
        [HttpDelete]
        public void DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Movies.Remove(movieInDb); // Remove customer from memory
            _context.SaveChanges(); // Persist memory changes to DB
        }


    }
}