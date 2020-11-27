using MathApi.Models;
using System.Linq;
using System.Web.Http;

namespace MathApi.Controllers
{
    public class SettingsController : ApiController
    {
        private DataContext dataContext;
        public SettingsController()
        {
            dataContext = new DataContext();
        }

        // GET api/controllername/5
        public Settings Get(int id)
        {
            Settings settings = dataContext.Settings.ToList().FirstOrDefault(s => s.UserId == id);
            return settings;
        }

        // POST api/controllername
        public IHttpActionResult Post([FromBody] Settings settings)
        {
            if (settings != null)
            {
                dataContext.Settings.Add(settings);
                dataContext.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }

        // PUT api/controllername/5
        public IHttpActionResult Put([FromBody] Settings settings)
        {
            if (settings != null)
            {
                var res = dataContext.Settings.FirstOrDefault(s => s.UserId == settings.UserId);
                res.MessageNotification = settings.MessageNotification;
                res.PhotoPath = settings.PhotoPath;
                dataContext.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }

        // DELETE api/controllername/5
        public IHttpActionResult Delete(int id)
        {
            Settings settings = dataContext.Settings.ToList().FirstOrDefault(s => s.UserId == id);
            if (settings != null)
            {
                return Ok(dataContext.Settings.Remove(settings));
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
