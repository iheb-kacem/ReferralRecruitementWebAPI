using Recruitement.Domain.Entities;
using Recruitement.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Recruitement.Api.Controllers
{
    public class NotificationController : ApiController
    {
        NotificationService service = new NotificationService();
        // GET: api/Notification
        public IEnumerable<Notification> Get()
        {
            return service.GetNotifications();
        }

        // GET: api/Notification/5
        public Notification Get(int id)
        {
            return service.GetNotification(id); ;
        }

        // POST: api/Notification
        public String Post(Notification value)
        {
            if (ModelState.IsValid)
            {
                return service.CreateNotification(value).ToString();
            }
            else
            {
                return "model is not valid";
            }
        }

        // PUT: api/Notification/5
        [HttpPut]
        public String Put(int id, Recruitement.Domain.Entities.Notification o)
        {
            Notification notif = service.GetNotification(id);
            notif.Note = o.Note;
            notif.Date = o.Date;


            return service.UpdateNotification(notif).ToString();
        }

        // DELETE: api/Notification/5
        public String Delete(int id)
        {
            return service.DeleteNotification(id).ToString();
        }
    }
}
