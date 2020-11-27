using MathApi.Models;

namespace MathApi.VIewModels
{
    public class MessageUserViewModel
    {
        public Message Message { get; set; }
        public string AuthorPhotoPath { get; set; }
        public string AuthorName { get; set; }
    }
}