using MathApi.Models;
using MathApi.VIewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace MathApi.Controllers
{
    [Authorize]
    public class PollController : ApiController
    {
        private DataContext dataContext;
        public PollController()
        {
            dataContext = new DataContext();
        }
        public IEnumerable<PollUserViewModel> Get()
        {
            IEnumerable<User> users = dataContext.Users.ToList();
            IEnumerable<Poll> polls = dataContext.Polls.ToList();
            IEnumerable<Question> questions = dataContext.Questions.ToList();
            IEnumerable<Answer> answers = dataContext.Answers.ToList();
            var pollsRes =
                from u in users
                join p in polls on u.Id equals p.AuthorId into table1
                from p in table1.ToList()
                select new PollUserViewModel
                {
                    Poll = p,
                    AuthorPhotoPath = u.PhotoPath,
                    AuthorName = u.FirstName + " " + u.FatherName
                };
            if(pollsRes != null)
            {
                foreach (var pollUser in pollsRes)
                {
                    pollUser.Poll.Questions = questions.Where(q => q.PollId == pollUser.Poll.Id);
                    if (pollUser.Poll.Questions != null)
                    {
                        foreach (var question in pollUser.Poll.Questions)
                        {
                            question.Answers = answers.Where(a => a.QuestionId == question.Id);
                        }
                    }
                }
                
            }
            return pollsRes;
        }

        // GET api/controllername/5
        public Poll Get(int id)
        {
            Poll poll = dataContext.Polls.ToList().FirstOrDefault(p => p.Id == id);
            return poll;
        }

        // POST api/controllername
        public void Post([FromBody] Poll poll)
        {
            if (poll != null)
            {
                dataContext.Polls.Add(poll);
                dataContext.SaveChanges();
                if (poll.Questions != null)
                {
                    foreach (var question in poll.Questions)
                    {
                        question.PollId = poll.Id;
                        dataContext.Questions.Add(question);
                        dataContext.SaveChanges();
                        if (question.Answers != null)
                        {
                            foreach (var answer in question.Answers)
                            {
                                answer.QuestionId = question.Id;
                                dataContext.Answers.Add(answer);
                                dataContext.SaveChanges();
                            }
                        }
                    }
                }
            }
        }

        // PUT api/controllername/5
        public void Put(int id, [FromBody] Poll poll)
        {
            Poll findPoll = dataContext.Polls.ToList().FirstOrDefault(p => p.Id == id);
            findPoll.Name = poll.Name;
            findPoll.AuthorId = poll.AuthorId;
            findPoll.PublicationTime = poll.PublicationTime;
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
