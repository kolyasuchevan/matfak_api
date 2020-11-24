using MathApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MathApi.Controllers
{
    public class UserController : ApiController
    {
        private DataContext dataContext;
        public UserController()
        {
            dataContext = new DataContext();
        }
        public IEnumerable<User> Get()
        {
            return dataContext.Users.ToList();
        }

        // GET api/controllername/5
        public User Get(int id)
        {
            User user = dataContext.Users.ToList().FirstOrDefault(u => u.Id == id);
            return user;
        }

        // POST api/controllername
        public void Post([FromBody] User user)
        {
            if (user != null)
            {
                dataContext.Users.Add(user);
                dataContext.SaveChanges();
            }
        }

        // PUT api/controllername/5
        public void Put(int id, [FromBody] User user)
        {
            User findUser = dataContext.Users.ToList().FirstOrDefault(u => u.Id == id);
            findUser.Login = user.Login;
            findUser.Password = user.Password;
            findUser.Email = user.Email;
            findUser.FirstName = user.FirstName;
            findUser.LastName = user.LastName;
            findUser.FatherName = user.FatherName;
            findUser.Birthday = user.Birthday;
            findUser.IsAdmin = user.IsAdmin;
            findUser.IsTeacher = user.IsTeacher;
            dataContext.SaveChanges();
        }

        // DELETE api/controllername/5
        public void Delete(int id)
        {
            User findUser = dataContext.Users.ToList().FirstOrDefault(u => u.Id == id);
            dataContext.Users.Remove(findUser);
        }
    }
}
