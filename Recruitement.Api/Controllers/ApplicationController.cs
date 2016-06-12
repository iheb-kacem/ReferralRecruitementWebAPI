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
    public class ApplicationController : ApiController
    {
        ApplicationService service = new ApplicationService();
        // GET: api/Application
        public IEnumerable<Application> Get()
        {
            return service.GetApplication();
        }

        // GET: api/Application/5
        public Application Get(int id)
        {
            return service.GetApplication(id);
        }

        // POST: api/Application
        public String Post(Application value)
        {
            //Application app = new Application();
            //app = value;
            if (service.CreateApplication(value))
            {
                return "ok";
            }
            else
            {
                return "fail";
            }

        }

        // PUT: api/Application/5
        public void Put(Application ap)
        {
            service.UpdateApplication(ap);
        }

        // DELETE: api/Administrator/5
        public void Delete(int id)
        {
            service.DeleteApplication(id);
        }
    }
}
