using GigHub.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;

namespace GigHub.Controllers
{
    public class FolloweesController : Controller
    {
        private ApplicationDbContext _context { get; set; }

        public FolloweesController()
        {
            _context = new ApplicationDbContext();

        }
        // GET: Followees
        public ActionResult Following()
        {
            var userId = User.Identity.GetUserId();
            var Artists = _context.Followings.Where(f => f.FollowerId == userId).Select(f=>f.Followee).ToList();
                          
            
            return View(Artists);
        }
    }
}