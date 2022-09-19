using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        //>> /movies/random
        private ApplicationDbContext _Data;
        public MoviesController()
        {
            _Data = new ApplicationDbContext();
        }
        public ActionResult Random()
        {
            var theHungerGame = new Movie() { Name = "thehungergame", Id = 1 };
            var customers = new List<Customer> {
                new Customer {Name="ahmad",Id=1},
                new Customer {Name="naseem",Id=2}
                };
            var viewmodel = new RandomMoviesViewModels()
            {
                Movie = theHungerGame,
                Customers = customers
            };

            return View(viewmodel);
            //return Content("hello my name is naseem!");
            //return HttpNotFound();

        }
        /*
        public ActionResult Edit(string id)
        {
            return Content("this id is = " + id);
        }
        */
        protected override void Dispose(bool disposing)
        {
            _Data.Dispose();
        }
        public ActionResult Index()
        {
            var movies = _Data.Movies.Include(m => m.Genre);
            if (User.IsInRole(RoleName.CanManageMovies))
            {
                return View("List",movies);
            }
            return View("ReadOnlyList",movies);
           

            
        }
        [Authorize(Roles =RoleName.CanManageMovies)] 
        public ActionResult New()
        {
            var genres = _Data.Genres.ToList();
            var viewmodel = new MovieFormViewModel()
            {
                Movie=new Movie(), 
                Genres = genres
            };
            return View("MovieForm",viewmodel); 
        }
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var movie = _Data.Movies.SingleOrDefault(m => m.Id == id);
            var genre = _Data.Genres.ToList();
            if (movie == null)
            {
                return HttpNotFound();
            }
            var viewmodel = new MovieFormViewModel()
            {
                Movie = movie,
                Genres = genre
            };
            return View("MovieForm", viewmodel); 
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            
            if (!ModelState.IsValid)
            {
                var viewmodel = new MovieFormViewModel()
                {
                    Movie = movie,
                    Genres = _Data.Genres.ToList()
                };
                return View("MovieForm", viewmodel);
            }
            
            movie.DateAdded = DateTime.Now; //this becuase the dateadded is not nulluble so we assign the currnet time to it.
            if (movie.Id == 0)
            {
                _Data.Movies.Add(movie);
            }
            else
            {
                var updatedmovie = _Data.Movies.Single(m => m.Id == movie.Id);
                updatedmovie.Name = movie.Name;
                updatedmovie.ReleaseDate = movie.ReleaseDate;
                updatedmovie.GenreId = movie.GenreId;
                updatedmovie.NumberInStock = movie.NumberInStock;
            }
            _Data.SaveChanges();
            return RedirectToAction("Index","Movies"); 
        }
        
        public ActionResult Details(int id)
        {
            var movie = _Data.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }
        /*

        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie { Id = 1, Name = "Shrek" },
                new Movie { Id = 2, Name = "Wall-e" }
            };
        }
        */

        // make custom route 
        // regex=regular expression
        [Route("movies/released/{year:max(2018)}/{month:regex(\\d{2})}")]
        public ActionResult Byrealeseyear(int year, int month)
        {
            return Content(year + "/" + month);
        }

    }
}