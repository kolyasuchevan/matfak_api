using MathApi.Models;

namespace MathApi.VIewModels
{
    public class PollUserViewModel
    {
        public Poll Poll { get; set; }
        public string AuthorName { get; set; }
        public string AuthorPhotoPath { get; set; }
    }
}