﻿namespace MathApi.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int VotesCount { get; set; }
        public int QuestionId { get; set; }
    }
}