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
    public class TenancyController : ApiController
    {
        TenancyService service = new TenancyService();
        // GET: api/Tenancy
        public IEnumerable<Tenancy> Get()
        {
            return service.GetTenancies();
        }

        // GET: api/Tenancy/5
        public Tenancy Get(int id)
        {
            return service.GetTenancy(id);
        }

        // POST: api/Tenancy
        public String Post(Tenancy value)
        {
            if (ModelState.IsValid)
            {
                return service.CreateTenancy(value).ToString();
            }
            else
            {
                return "model is not valid";
            }
        }

        // PUT: api/Tenancy/5
        public String Put(Tenancy value)
        {
            if (ModelState.IsValid)
            {
                return service.UpdateTenancy(value).ToString();
            }
            else
            {
                return "model is not valid";
            }
        }

        // DELETE: api/Tenancy/5
        public void Delete(int i)
        {
            service.DeleteTenancy(i);
        }
    }
}
