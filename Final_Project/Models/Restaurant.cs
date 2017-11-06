using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final_Project.Models
{
    public class Restaurant
    {
        public long Id { get; set; }//primary key
        public string Name { get; set; }
        public string Location { get; set; }
        public string Category { get; set; }
        public double Rating { get; set; }
        public int RateNum { get; set; }
        public string Reservations { get; set; }
    }
}