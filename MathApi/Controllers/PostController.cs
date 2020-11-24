using MathApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MathApi.Controllers
{
    public class PostController : ApiController
    {
        private DataContext dataContext;
        public PostController()
        {
            dataContext = new DataContext();
        }
        public IEnumerable<Post> Get()
        {
            return dataContext.Posts.ToList();
        }

        // GET api/controllername/5
        public Post Get(int id)
        {
            Post post = dataContext.Posts.ToList().FirstOrDefault(p => p.Id == id);
            return post;
        }

        // POST api/controllername
        public void Post([FromBody] Post post)
        {
            if (post != null)
            {
                dataContext.Posts.Add(post);
                dataContext.SaveChanges();
            }
        }

        // PUT api/controllername/5
        public void Put(int id, [FromBody] Post post)
        {
            Post findPost = dataContext.Posts.ToList().FirstOrDefault(p => p.Id == id);
            findPost.Name = post.Name;
            findPost.Description = post.Description;
            findPost.AuthorId = post.AuthorId;
            findPost.PublicationTime = post.PublicationTime;
            findPost.PhotoPath = post.PhotoPath;
            dataContext.SaveChanges();
        }

        // DELETE api/controllername/5
        public void Delete(int id)
        {
            Post findPost = dataContext.Posts.ToList().FirstOrDefault(p => p.Id == id);
            dataContext.Posts.Remove(findPost);
        }
    }
}
