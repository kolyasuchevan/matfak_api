using MathApi.Models;

namespace MathApi.VIewModels
{
    public class PostUserViewModel
    {
        public Post Post { get; set; }
        public string AuthorPhotoPath { get; set; }
        public string AuthorName { get; set; }
    }
}