using Recruitement.Data.Contracts;
using Recruitement.Data.Infrastructure;
using Recruitement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitement.Services
{
    public class OfferService
    {
        static DatabaseFactory dbFactory = new DatabaseFactory();
        IUnitOfWork utOfWork = new UnitOfWork(dbFactory);

        public IEnumerable<Offer> GetOffers()
        {
            return utOfWork.OfferRepository.GetAll().ToList();
        }

        public Offer GetOffer(int id)
        {
            return utOfWork.OfferRepository.GetById(id);
        }


        public Boolean CreateOffer(Recruitement.Domain.Entities.Offer o)
        {
            bool t;
            try
            {
                utOfWork.OfferRepository.Add(o);
                t = utOfWork.Commit();
            }
            catch
            {
                utOfWork = new UnitOfWork(new DatabaseFactory());
                return false;
            }
            return t;

        }

        public Boolean UpdateOffer(Recruitement.Domain.Entities.Offer o)
        {
            bool t;
            try
            {

                utOfWork.OfferRepository.Update(o);
                t = utOfWork.Commit();
            }
            catch
            {
                utOfWork = new UnitOfWork(new DatabaseFactory());
                return false;
            }
            return t;
        }

        public Boolean DeleteOffer(int i)
        {
            bool t;
            try
            {
                utOfWork.OfferRepository.Delete(i);
                t = utOfWork.Commit();
            }
            catch
            {
                utOfWork = new UnitOfWork(new DatabaseFactory());
                return false;
            }
            return t;
        }

    }
}
