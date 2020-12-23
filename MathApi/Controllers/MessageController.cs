using MathApi.Models;
using MathApi.VIewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace MathApi.Controllers
{
    [Authorize]
    public class MessageController : ApiController
    {
        private DataContext dataContext;
        public MessageController()
        {
            dataContext = new DataContext();
        }
        /*public IEnumerable<Message> Get()
        {
            return dataContext.Chats.ToList();
        }*/
        public IEnumerable<MessageUserViewModel> Get(int id)
        {
            IEnumerable<User> users = dataContext.Users.ToList();
            IEnumerable<Message> messages = dataContext.Messages.ToList();
            IEnumerable<Chat> chats = dataContext.Chats.ToList().Where(c => c.Id == id); ;
            var messagesRes =
                from m in messages
                join u in users on m.AuthorId equals u.Id into table1
                from u in table1.ToList()
                join c in chats on m.ChatId equals c.Id into table2
                from c in table2.ToList()
                select new MessageUserViewModel
                {
                    Message = m,
                    AuthorName = u.FirstName + " " + u.FatherName,
                    AuthorPhotoPath = u.PhotoPath
                };
            return messagesRes;
        }

        // GET api/controllername/5
        /*public Chat Get(int id)
        {
            Post post = dataContext.Posts.ToList().FirstOrDefault(p => p.Id == id);
            return post;
        }
*/
        // POST api/controllername
        public IHttpActionResult Post([FromBody] Message message)
        {
            try
            {
                if (message != null)
                {
                    dataContext.Messages.Add(message);
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
        public IHttpActionResult Put([FromBody] Message message)
        {
            Message findMessage= dataContext.Messages.ToList().FirstOrDefault(m => m.Id == message.Id);
            findMessage.Text = message.Text;
            return Ok(dataContext.SaveChanges());
        }

        // DELETE api/controllername/5
        public IHttpActionResult Delete(int id)
        {
            Message findMessage = dataContext.Messages.ToList().FirstOrDefault(m => m.Id == id);
            if (findMessage != null)
            {
                return Ok(dataContext.Messages.Remove(findMessage));
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
