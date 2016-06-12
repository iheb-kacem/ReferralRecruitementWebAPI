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
    public class RecruiterController : ApiController
    {
        RecruiterService service = new RecruiterService();

        // GET: api/Recruiter
        public IEnumerable<Recruiter> Get()
        {
            return service.GetRecruiters();
        }

        // GET: api/Recruiter/5
        public Recruiter Get(int id)
        {
            return service.GetRecruiter(id);
        }

        // POST: api/Recruiter
        public String Post(Recruiter value)
        {
            if (ModelState.IsValid)
            {
                return service.CreateRecruiter(value).ToString();
            }
            else
            {
                return "model is not valid";
            }
        }

        // PUT: api/Recruiter/5
        [HttpPut]
        public String Put(int id, Recruitement.Domain.Entities.Recruiter recruiter)
        {
            Recruiter rec = service.GetRecruiter(id);
            rec.FirstName = recruiter.FirstName;
            rec.LastName = recruiter.LastName;
            rec.Email = recruiter.Email;
            rec.Password = recruiter.Password;
            //rec.Offers = recruiter.Offers;
            return service.UpdateRecruiter(rec).ToString();
        }

        // DELETE: api/Recruiter/5
        public String Delete(int id)
        {
            return service.DeleteRecruiter(id).ToString();
        }
    }
}
