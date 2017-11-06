using Final_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Final_Project.Controllers.Api
{
    public class ReviewController : ApiController
    {
        ApplicationDbContext DbContext = new ApplicationDbContext();

        [HttpGet]
        public IHttpActionResult Index(string Rating)
        {
            var AvgRating = DbContext.Reviews.ToList();

            int sum = 0;
            foreach (var item in AvgRating)
            {
                sum += item.Rate;
            }
            return Ok(sum / AvgRating.Count());
        }

        //// Get /api/review
        [HttpGet]
        public IEnumerable<Review> GetListOfContactUs()
        {
            return DbContext.Reviews;
        }

        [HttpPost]
        public IHttpActionResult CreateReview(Review Review)
        {
            double sum = 0;

            if (Review.RestaurantName == null)
            {
                return NotFound();
            }
            var ListOfReviews = DbContext.Reviews.Where(rev => rev.RestaurantName == Review.RestaurantName).ToList();


            DbContext.Restaurants.FirstOrDefault(res => res.Name == Review.RestaurantName).RateNum = DbContext.Restaurants.FirstOrDefault(res => res.Name == Review.RestaurantName).RateNum + 1;

            if (ListOfReviews.Count() == 0)
            {
                DbContext.Restaurants.FirstOrDefault(res => res.Name == Review.RestaurantName).Rating = Review.Rate;
            }
            else
            {
                foreach (var item in ListOfReviews)
                {
                    sum += item.Rate;
                }
                sum += Review.Rate;

                DbContext.Restaurants.FirstOrDefault(res => res.Name == Review.RestaurantName).Rating = sum / (ListOfReviews.Count() + 1);
            }

            DbContext.Reviews.Add(Review);
            DbContext.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = Review.Id }, Review);
        }

        // DELETE /api/Reviews/4 -> delete blog with id 4
        [HttpDelete]
        public IHttpActionResult DeleteReviews(long id)
        {
            Review Reviews = DbContext.Reviews.Find(id);
            if (Reviews == null)
            {
                return NotFound();
            }
            DbContext.Reviews.Remove(Reviews);
            DbContext.SaveChanges();
            return Ok(DbContext.Reviews);
        }
    }
}
