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
    public class TenancyService
    {
        static DatabaseFactory dbFactory = new DatabaseFactory();
        IUnitOfWork utOfWork = new UnitOfWork(dbFactory);

        public IEnumerable<Tenancy> GetTenancies()
        {
            return utOfWork.TenancyRepository.GetAll().ToList();
        }

        public Tenancy GetTenancy(int id)
        {
            return utOfWork.TenancyRepository.GetById(id);
        }

        public Boolean CreateTenancy(Recruitement.Domain.Entities.Tenancy d)
        {
            bool t;
            try
            {
                utOfWork.TenancyRepository.Add(d);
                t = utOfWork.Commit();
            }
            catch
            {
                utOfWork = new UnitOfWork(new DatabaseFactory());
                return false;
            }
            return t;
        }

        public Boolean UpdateTenancy(Tenancy d)
        {
            bool t;
            try
            {
                utOfWork.TenancyRepository.Update(d);
                t = utOfWork.Commit();
            }
            catch
            {
                utOfWork = new UnitOfWork(new DatabaseFactory());
                return false;
            }
            return t;
        }

        public Boolean DeleteTenancy(int i)
        {
            bool t;
            try
            {
                utOfWork.TenancyRepository.Delete(i);
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
