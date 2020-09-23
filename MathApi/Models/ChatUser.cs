using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MathApi.Models
{
    public class ChatUser
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ChatId { get; set; }
    }
}