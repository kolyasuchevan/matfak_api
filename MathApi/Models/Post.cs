using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MathApi.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PhotoPath { get; set; }
        public DateTime PublicationTime{ get; set; }
        public string AuthorId { get; set; }
    }
}