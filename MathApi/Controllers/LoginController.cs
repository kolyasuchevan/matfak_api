using MathApi.Models;
using System.Linq;
using System.Web.Http;

namespace MathApi.Controllers
{
    [Authorize]
    public class LoginController : ApiController
    {
        private DataContext dataContext;
        public LoginController()
        {
            dataContext = new DataContext();
        }

        // GET api/controllername/5
        public User Get([FromUri]string email, [FromUri] string password)
        {
            User user = dataContext.Users.ToList().FirstOrDefault(u => u.Email == email && u.Password == password);
            return user;
        }
    }
}
