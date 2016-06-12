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
    public class OfferController : ApiController
    {
        OfferService service = new OfferService();
        // GET: api/Offer
        public IEnumerable<Offer> Get()
        {
            return service.GetOffers();
        }

        // GET: api/Offer/5
        public Offer Get(int id)
        {
            return service.GetOffer(id); ;
        }

        // POST: api/Offer
      
            public String Post(Offer value)
        {
            if(ModelState.IsValid)
            {
                 return service.CreateOffer(value).ToString();
            }
            else
            {
                return "model is not valid";
            }
        }
        

        // PUT: api/Offer/5
            [HttpPut]
            public String Put(int id, Recruitement.Domain.Entities.Offer o)
            {
                Offer offer = service.GetOffer(id);
                offer.OfferName = o.OfferName;
                offer.Note = o.Note;
                offer.Date = o.Date;
                //offer.Password = admin.Password;
                return service.UpdateOffer(offer).ToString();
            }

        // DELETE: api/Offer/5
            public String Delete(int id)
            {
                return service.DeleteOffer(id).ToString();
            }
    }
}
