using Final_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Final_Project.Controllers.Api
{
    public class RestaurantController : ApiController
    {
        ApplicationDbContext DbContext = new ApplicationDbContext();

        // /api/Restaurant
        [HttpGet]
        public IEnumerable<Restaurant> GetRestaurant()
        {
            return DbContext.Restaurants;
        }

        // DELETE /api/Restaurant/4 -> delete blog with id 4
        [HttpDelete]
        public IHttpActionResult DeleteRestaurant(long id)
        {
            Restaurant restaurant = DbContext.Restaurants.Find(id);
            if (restaurant == null)
            {
                return NotFound();
            }
            DbContext.Restaurants.Remove(restaurant);
            DbContext.SaveChanges();
            return Ok(DbContext.Restaurants);
        }

        [HttpPost]
        public IHttpActionResult CreateContactUs(Restaurant restaurants)
        {
            if ((restaurants.Name == null) && !ValidationIsOk(restaurants.Category, restaurants.Location, restaurants.Reservations))
            {
                return NotFound();
            }
            DbContext.Restaurants.Add(restaurants);
            DbContext.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = restaurants.Id }, restaurants);
        }


        bool ValidationIsOk(string Category, string Location, string Reservations)
        {
            return !string.IsNullOrEmpty(Location) && !string.IsNullOrEmpty(Reservations) &&
                !string.IsNullOrEmpty(Category);
        }
    }
}
