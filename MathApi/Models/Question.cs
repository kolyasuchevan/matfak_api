﻿namespace MathApi.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int PollId { get; set; }
    }
}