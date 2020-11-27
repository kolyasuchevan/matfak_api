using System;

namespace MathApi.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int AuthorId { get; set; }
        public int ChatId { get; set; }
        public DateTime SentTime{ get; set; }
    }
}