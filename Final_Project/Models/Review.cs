using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final_Project.Models
{
    public class Review
    {
        public long Id { get; set; }//primary key
        public string RestaurantName { get; set; }
        public string Category { get; set; }
        public string Area { get; set; }
        public string DateOfReview { get; set; }
        public string Reviews { get; set; }
        public int Rate { get; set; }
    }
}