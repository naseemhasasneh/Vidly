using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _Context;
        public NewRentalsController()
        {
            _Context = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {
            var customer = _Context.Customers.Single(
                c => c.Id == newRental.CustomerId
                );
            var movies = _Context.Movies.Where(
                m => newRental.MovieIds.Contains(m.Id)
                );
            foreach(var movie in movies) { 
                if (movie.NumberAvailable == 0)
                
                   return BadRequest("The movie is not available");
                
                movie.NumberAvailable--;
                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };
                _Context.Rentals.Add(rental);
            }
            _Context.SaveChanges();
            return Ok();
        }
    }
}
