using System;
using System.ComponentModel.DataAnnotations;

namespace GigHub.Models
{
    public class Notification
    {
        public int Id { get; private set; }
        public DateTime DateTime { get; private set; }
        public NotificationType Type { get; private set; }
        public DateTime?  OriginalDateTime { get; private set; }
        public string OriginalVenue { get; private set; }

        [Required]
        public Gig Gig { get; private set; }

        protected Notification()
        {

        }
        private Notification(Gig gig,NotificationType type)
        {
            if (gig==null)
            {
                throw new ArgumentNullException("gig");
            }

            Gig = gig;
            DateTime = DateTime.Now;
            Type = type;
            
        }

        public static Notification gigCanceled(Gig gig)
        {
            return new Notification(gig, NotificationType.GigCanceled);
        }
        public static Notification gigUpdated(Gig gig,DateTime originalDateTime,string originalVenue)
        {
            var notification= new Notification(gig, NotificationType.GigUpdated);
            notification.OriginalDateTime = originalDateTime;
            notification.OriginalVenue = originalVenue;
            return notification;
        }

        public static Notification gigCreated(Gig gig)
        {
            return new Notification(gig, NotificationType.GigCreated);
        }
    }
}