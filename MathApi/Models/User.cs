using System;

namespace MathApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName{ get; set; }
        public DateTime Birthday { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsTeacher { get; set; }
        public string PhotoPath { get; set; }

    }
}