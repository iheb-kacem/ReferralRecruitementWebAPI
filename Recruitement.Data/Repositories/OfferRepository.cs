using Recruitement.Data.Contracts;
using Recruitement.Data.Infrastructure;
using Recruitement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitement.Data.Repositories
{
    public interface IOfferRepository : IRepository<Offer>
    {

    }
    class OfferRepository : RepositoryBase<Offer>, IOfferRepository
    {
        public OfferRepository(IDatabaseFactory db):base(db)
        {
                
        }
    }
}
