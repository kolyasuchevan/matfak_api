﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MathApi.Models
{
    public class PollUser
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PollId { get; set; }
        public DateTime Time { get; set; }
    }
}