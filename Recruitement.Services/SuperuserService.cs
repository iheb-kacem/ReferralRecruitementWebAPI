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
    public class SuperuserService
    {
        static DatabaseFactory dbFactory = new DatabaseFactory();
        IUnitOfWork utOfWork = new UnitOfWork(dbFactory);

        public IEnumerable<Superuser> GetSuperusers()
        {
            return utOfWork.SuperuserRepository.GetAll().ToList();
        }

        public Superuser GetSuperuser(int id)
        {
            return utOfWork.SuperuserRepository.GetById(id);
        }

        public Boolean CreateSuperuser(Recruitement.Domain.Entities.Superuser s)
        {
            bool t;
            try
            {
                utOfWork.SuperuserRepository.Add(s);
                t = utOfWork.Commit();
            }
            catch
            {
                utOfWork = new UnitOfWork(new DatabaseFactory());
                return false;
            }
            return t;
        }

        public Boolean UpdateSuperuser(Superuser s)
        {
            bool t;
            try
            {
                s.ConfirmePassword = s.Password;
                utOfWork.SuperuserRepository.Update(s);
                t = utOfWork.Commit();
            }
            catch
            {
                utOfWork = new UnitOfWork(new DatabaseFactory());
                return false;
            }
            return t;
        }

        public Boolean DeleteSuperuser(int i)
        {
            bool t;
            try
            {
                utOfWork.SuperuserRepository.Delete(i);
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
