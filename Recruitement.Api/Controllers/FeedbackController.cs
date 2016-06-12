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
    public class FeedbackController : ApiController
    {
        FeedbackService service = new FeedbackService();
        // GET: api/Feedback
        public IEnumerable<Feedback> Get()
        {
            return service.GetFeedback();
        }

        // GET: api/Feedback/5
        public Feedback Get(int id)
        {
            return service.GetFeedback(id);
        }

        // POST: api/Feedback
        public String Post(Feedback value)
        {

            if (service.CreateFeedback(value))
            {
                return "ok";
            }
            else
            {
                return "fail";
            }

        }

        // PUT: api/Administrator/5
        public void Put(Feedback f)
        {
            service.UpdateFeedback(f);
        }

        // DELETE: api/Feedback/5
        public void Delete(int id)
        {
            service.DeleteFeedback(id);
        }
    }
}