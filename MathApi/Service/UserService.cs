using MathApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MathApi.Service
{
    public class UserService
    {
        private DataContext dataContext;

        public UserService()
        {
            dataContext = new DataContext();
        }
        public User GetUserByCredentials(string email, string password)
        {
            List<User> users = dataContext.Users.ToList();
            User user = users.FirstOrDefault(u => u.Email == email);
            if (user == null || user.Password != password)
            {
                return null;
            }
            return user;
        } 
    }
}