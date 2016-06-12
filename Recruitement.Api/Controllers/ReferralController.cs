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
    public class ReferralController : ApiController
    {
        ReferralService service = new ReferralService();

        // GET: api/Referral
        public IEnumerable<Referral> Get()
        {
            return service.GetReferrals();
        }

        // GET: api/Referral/5
        public Referral Get(int id)
        {
            return service.GetReferral(id);
        }

        // POST: api/Referral
        public String Post(Referral value)
        {
            if (ModelState.IsValid)
            {
                return service.CreateReferral(value).ToString();
            }
            else
            {
                return "model is not valid";
            }
        }

        // PUT: api/Referral/5
        [HttpPut]
        public String Put(int id, Recruitement.Domain.Entities.Referral referral)
        {
            Referral refe = service.GetReferral(id);
            refe.FirstName = referral.FirstName;
            refe.LastName = referral.LastName;
            refe.Email = referral.Email;
            refe.Password = referral.Password;
            refe.Bonus = referral.Bonus;
            refe.Success = referral.Success;
            //refe.Notifications = referral.Notifications;
            //refe.Applications = referral.Applications;
            return service.UpdateReferral(refe).ToString();
        }

        // DELETE: api/Referral/5
        public String Delete(int id)
        {
            return service.DeleteReferral(id).ToString();
        }
    }
}
