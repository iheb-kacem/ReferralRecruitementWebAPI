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
    public class SuperuserController : ApiController
    {
        SuperuserService service = new SuperuserService();
        // GET: api/Superuser
        public IEnumerable<Superuser> Get()
        {
            return service.GetSuperusers();
        }

        // GET: api/Superuser/5
        public Superuser Get(int id)
        {
            return service.GetSuperuser(id);
        }

        // POST: api/Superuser
        public String Post(Superuser value)
        {
            if (ModelState.IsValid)
            {
                return service.CreateSuperuser(value).ToString();
            }
            else
            {
                return "model is not valid";
            }
        }

        // PUT: api/Superuser/5
        public String Put(Superuser value)
        {
            if (ModelState.IsValid)
            {
                return service.UpdateSuperuser(value).ToString();
            }
            else
            {
                return "model is not valid";
            }
        }

        // DELETE: api/Superuser/5
        public void Delete(int i)
        {
            service.DeleteSuperuser(i);
        }
    }
}
