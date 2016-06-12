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
    public class AdministratorController : ApiController
    {
        AdministratorService service = new AdministratorService();

        // GET: api/Administrator
        public IEnumerable<Administrator> Get()
        {
            return service.GetAdministrators();
        }

        // GET: api/Administrator/5
        public Administrator Get(int id)
        {
            return service.GetAdministrator(id);
        }

        // POST: api/Administrator
        public String Post(Administrator value)
        {
            if(ModelState.IsValid)
            {
                 return service.CreateAdministrator(value).ToString();
            }
            else
            {
                return "model is not valid";
            }
        }

        // PUT: api/Administrator/5
        [HttpPut]
        public String Put(int id, Recruitement.Domain.Entities.Administrator a)
        {
            Administrator admin = service.GetAdministrator(id);
            admin.FirstName = a.FirstName;
            admin.LastName = a.LastName;
            admin.Email = a.Email;
            admin.Password = a.Password;
            //admin.Tenancies = a.Tenancies;
            return service.UpdateAdministrator(admin).ToString();
        }

        // DELETE: api/Administrator/5
        public String Delete(int id)
        {
            return service.DeleteAdministrator(id).ToString();
        }
    }
}
