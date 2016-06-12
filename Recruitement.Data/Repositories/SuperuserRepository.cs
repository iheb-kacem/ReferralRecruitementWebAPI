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
    public interface ISuperuserRepository : IRepository<Superuser>
    {

    }
    class SuperuserRepository : RepositoryBase<Superuser>, ISuperuserRepository
    {
        public SuperuserRepository(IDatabaseFactory db)
            : base(db)
        {

        }
    }
}
