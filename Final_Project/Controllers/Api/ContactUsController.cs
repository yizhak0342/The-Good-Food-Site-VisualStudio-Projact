using Final_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Final_Project.Controllers.Api
{
    public class ContactUsController : ApiController
    {
        ApplicationDbContext DbContext = new ApplicationDbContext();

        //// POST /api/Contactus
        [HttpGet]
        public IEnumerable<ContactUs> GetListOfMessage()
        {
            return DbContext.ContactUs;
        }


        [HttpPost]
        public IHttpActionResult CreateContactUs(ContactUs Contactus)
        {
            if ((Contactus.Name == null) && !ValidationIsOk(Contactus.Email, Contactus.Phone, Contactus.Message))
            {
                return NotFound();
            }
            DbContext.ContactUs.Add(Contactus);
            DbContext.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = Contactus.Id }, Contactus);
        }

        // DELETE /api/Restaurant/4 -> delete blog with id 4
        [HttpDelete]
        public IHttpActionResult DeleteContactUs(long id)
        {
            ContactUs Contactus = DbContext.ContactUs.Find(id);
            if (Contactus == null)
            {
                return NotFound();
            }
            DbContext.ContactUs.Remove(Contactus);
            DbContext.SaveChanges();
            return Ok(DbContext.ContactUs);
        }

        bool ValidationIsOk(string Name, int Password, string Email)
        {
            return !string.IsNullOrEmpty(Name) && !float.IsNaN(Password) &&
                !string.IsNullOrEmpty(Email);
        }
    }
}
