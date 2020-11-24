using MathApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MathApi.Controllers
{
    public class ChatController : ApiController
    {
        private DataContext dataContext;
        public ChatController()
        {
            dataContext = new DataContext();
        }
        public IEnumerable<Chat> Get()
        {
            return dataContext.Chats.ToList();
        }
        public IEnumerable<Chat> Get(int id)
        {
            Post post = dataContext.Posts.ToList().FirstOrDefault(p => p.Id == id);

            return dataContext.Chats.ToList();
        }

        // GET api/controllername/5
        /*public Chat Get(int id)
        {
            Post post = dataContext.Posts.ToList().FirstOrDefault(p => p.Id == id);
            return post;
        }
*/
        // POST api/controllername
        public void Post([FromBody] Chat chat)
        {
            if (chat != null)
            {
                dataContext.Chats.Add(chat);
                dataContext.SaveChanges();
            }
        }
        
        // PUT api/controllername/5
        public void Put(int id, [FromBody] Chat chat)
        {
            Chat findChat = dataContext.Chats.ToList().FirstOrDefault(c => c.Id == id);
            findChat.Name = chat.Name;
            findChat.PhotoPath = chat.PhotoPath;
            dataContext.SaveChanges();
        }

        // DELETE api/controllername/5
        public void Delete(int id)
        {
            Chat findChat = dataContext.Chats.ToList().FirstOrDefault(c => c.Id == id);
            dataContext.Chats.Remove(findChat);
        }
    }
}
