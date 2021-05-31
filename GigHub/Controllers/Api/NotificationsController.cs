using GigHub.Dtos;
using GigHub.Models;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace GigHub.Controllers.Api
{
    [Authorize]
    public class NotificationsController : ApiController
    {
        private ApplicationDbContext _context;

        public NotificationsController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<NotificationDto> GetNewNotifications()
        {
            var userId = User.Identity.GetUserId();
            var notifications = _context.UserNotifications
                .Where(un => un.UserId == userId && !un.IsRead)
                .Select(un => un.Notification)
                .Include(n => n.Gig.Artist)
                .ToList();
            /*
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ApplicationUser, UserDto>();
            });

            var config1 = new MapperConfiguration(cfg => {
                cfg.CreateMap<Gig, GigDto>();
            });


            var config2 = new MapperConfiguration(cfg => {
                cfg.CreateMap<Notification, NotificationDto>();
            });

           */
          

            return notifications.Select(n => new NotificationDto()
            {
                DateTime = n.DateTime,
                Type = n.Type,
                Gig = new GigDto()
                {
                    DateTime = n.Gig.DateTime,
                    Artist = new UserDto
                    {
                        Id = n.Gig.Artist.Id,
                        Name = n.Gig.Artist.Name
                    },
                    Id = n.Gig.Id,
                    Venue = n.Gig.Venue,
                    IsCanceled = n.Gig.IsCanceled
                },
                OriginalDateTime = n.OriginalDateTime,
                OriginalVenue = n.OriginalVenue
            });

           

        }
    }
}
