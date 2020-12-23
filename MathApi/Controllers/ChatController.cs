using MathApi.Models;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace MathApi.Controllers
{
    [Authorize]
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
        public IEnumerable<Chat> Get(int UserId)
        {
            IEnumerable<User> users = dataContext.Users.ToList();
            IEnumerable<Chat> chats = dataContext.Chats.ToList();
            IEnumerable<ChatUser> tmp = dataContext.ChatUser.ToList();
            IEnumerable<ChatUser> chatsUsers = tmp.Where(u => u.UserId == UserId);
            var chatsRes = 
                from cu in chatsUsers
                    join u in users on cu.UserId equals u.Id into table1
                    from u in table1.ToList()
                    join c in chats on cu.ChatId equals c.Id into table2
                    from c in table2.ToList()
                    select c;
            return chatsRes;
        }

        // GET api/controllername/5
        /*public Chat Get(int id)
        {
            Post post = dataContext.Posts.ToList().FirstOrDefault(p => p.Id == id);
            return post;
        }
*/
        // POST api/controllername
        public IHttpActionResult Post([FromBody] JObject obj)
        {
            List<int> userIds = obj["UserIds"].ToObject<List<int>>();
            Chat chat= obj["Chat"].ToObject<Chat>();
            try
            {
                if (userIds != null && chat != null)
                {
                    dataContext.Chats.Add(chat);
                    dataContext.SaveChanges();
                    foreach (var userId in userIds)
                    {
                        dataContext.ChatUser.Add(new ChatUser() { UserId = userId, ChatId = chat.Id });
                    }

                    dataContext.SaveChanges();
                }
            }
            catch
            {
                return BadRequest();
            }
            return Ok();
        }
        
        // PUT api/controllername/5
        public IHttpActionResult Put(int id, [FromBody] Chat chat)
        {
            Chat findChat = dataContext.Chats.ToList().FirstOrDefault(c => c.Id == id);
            findChat.Name = chat.Name;
            findChat.PhotoPath = chat.PhotoPath;
            return Ok(dataContext.SaveChanges());
        }

        // DELETE api/controllername/5
        public IHttpActionResult Delete(int id)
        {
            Chat findChat = dataContext.Chats.ToList().FirstOrDefault(c => c.Id == id);
            return Ok(dataContext.Chats.Remove(findChat));
        }
    }
}

