using GigHub.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace GigHub.Controllers.Api
{
    [Authorize]
    public class UserReadNotificationsController : ApiController
    {
        private ApplicationDbContext _context { get; set; }
        public UserReadNotificationsController()
        {
            _context = new ApplicationDbContext();
        }

        
        [HttpPost]
        public IHttpActionResult MarkAsRead()
        {
            var userId = User.Identity.GetUserId();
            var usernotifications = _context.UserNotifications
                .Where(un=>un.UserId==userId & !un.IsRead)
                .ToList();
            usernotifications.ForEach(un => un.Read());
             
            
            _context.SaveChanges();
            return Ok();
        }

    }
}
