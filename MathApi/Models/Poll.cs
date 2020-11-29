using System;
using System.Collections.Generic;

namespace MathApi.Models
{
    public class Poll
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AuthorId { get; set; }
        public DateTime PublicationTime { get; set; }
        public IEnumerable<Question> Questions { get; set; }
    }
}