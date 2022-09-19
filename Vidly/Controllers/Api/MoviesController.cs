using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;
using Vidly.ViewModels;
using Vidly.Dtos;
using AutoMapper;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _Data;
        public MoviesController()
        {
            _Data = new ApplicationDbContext();
        }
        //get api/Movies
        public IEnumerable<MovieDto> GetMovies()
        {
            
         return _Data.Movies.ToList().Select(Mapper.Map<Movie, MovieDto>);
        }
        //get api/Movies/id
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _Data.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }
        //post api/Movies
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto moviedto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var movie = Mapper.Map<MovieDto, Movie>(moviedto);
            _Data.Movies.Add(movie);
            _Data.SaveChanges();
            moviedto.Id = movie.Id;
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), moviedto);

        }
        [HttpPut]
        //put api/Movies/id
        public IHttpActionResult UpdateMovie(int id,MovieDto moviedto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var movieindb = _Data.Movies.SingleOrDefault(m => m.Id == id);
            if (movieindb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            //update Movie
            Mapper.Map(moviedto, movieindb);

            _Data.SaveChanges();
            return Ok<string>("the movie has been updated.");
        }
        //delete api/Movies/1
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movieindb = _Data.Movies.SingleOrDefault(m => m.Id == id);
            if (movieindb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _Data.Movies.Remove(movieindb);
            _Data.SaveChanges();
            return Ok<string>("the movie has been deleted");
        }
    }
}
