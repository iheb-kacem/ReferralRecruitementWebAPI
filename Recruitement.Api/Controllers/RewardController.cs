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
    public class RewardController : ApiController
    {
        RewardService service = new RewardService();

        // GET: api/Reward
        public IEnumerable<Reward> Get()
        {
            return service.GetRewards();
        }

        // GET: api/Reward/5
        public Reward Get(int id)
        {
            return service.GetReward(id);
        }

        // POST: api/Reward
        public String Post(Reward value)
        {
            if (ModelState.IsValid)
            {
                return service.CreateReward(value).ToString();
            }
            else
            {
                return "model is not valid";
            }
        }

        // PUT: api/Reward/5
        [HttpPut]
        public String Put(int id, Recruitement.Domain.Entities.Reward a)
        {
            Reward rwd = service.GetReward(id);
            rwd.Sharing = a.Sharing;
            rwd.HRIntrvw = a.HRIntrvw;
            rwd.TechIntrvw = a.TechIntrvw;
            rwd.MnIntrvw = a.MnIntrvw;
            rwd.Hire = a.Hire;
            return service.UpdateReward(rwd).ToString();
        }

        // DELETE: api/Reward/5
        public String Delete(int id)
        {
            return service.DeleteReward(id).ToString();
        }
    }
}
