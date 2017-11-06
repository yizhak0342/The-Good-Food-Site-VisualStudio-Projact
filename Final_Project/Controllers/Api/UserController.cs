using Final_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Final_Project.Controllers.Api
{
    public class UserController : ApiController
    {
        ApplicationDbContext DbContext = new ApplicationDbContext();

        // /api/User
        [HttpGet]
        public IEnumerable<AppUser> GetUser()
        {
            return DbContext.AppUsers;
        }

        // POST /api/User
        [HttpPost]
        public IHttpActionResult CreateUser(AppUser user)
        {
            if ((user.Name != null) &&!ValidationIsOk(user.Name, user.Password,user.Email))
            {
                return BadRequest();
            }
            DbContext.AppUsers.Add(user);
            DbContext.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = user.Id }, user);
        }

        //[HttpPost]
        //public IHttpActionResult ChackLogin(long id, AppUser user)
        //{
        //    AppUser appuser = DbContext.AppUsers.Find(id);
        //    if ((user.Name != null) && (user.Password != null)) { return BadRequest(); }
                       
            //appuser = new AppUser { Name = user.Name, Password = user.Password };
            
            //m_db.SaveChanges();
            //return CreatedAtRoute("DefaultApi", new { id = blog.Id }, blog);
        //}

        bool ValidationIsOk(string Name, string Password, string Email)
        {
            return !string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Password) &&
                !string.IsNullOrEmpty(Email);
        }
    }
}
