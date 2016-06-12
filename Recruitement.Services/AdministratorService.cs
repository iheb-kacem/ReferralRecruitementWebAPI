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
    public class AdministratorService
    {
        static DatabaseFactory dbFactory = new DatabaseFactory();
        IUnitOfWork utOfWork = new UnitOfWork(dbFactory);

        public IEnumerable<Administrator> GetAdministrators()
        {
            return utOfWork.AdministratorRepository.GetAll().ToList();
        }

        public Administrator GetAdministrator(int id)
        {
            return utOfWork.AdministratorRepository.GetById(id);
        }

        public Boolean CreateAdministrator(Recruitement.Domain.Entities.Administrator a)
        {
            bool t;
            try
            {
                utOfWork.AdministratorRepository.Add(a);
                t = utOfWork.Commit();
            }
            catch
            {
                utOfWork = new UnitOfWork(new DatabaseFactory());
                return false;
            }
            return t;
            
        }

        public Boolean UpdateAdministrator(Recruitement.Domain.Entities.Administrator a)
        {
            bool t;
            try
            {
                a.ConfirmePassword = a.Password;
                utOfWork.AdministratorRepository.Update(a);
                t = utOfWork.Commit();
            }
            catch
            {
                utOfWork = new UnitOfWork(new DatabaseFactory());
                return false;
            }
            return t;
        }

        public Boolean DeleteAdministrator(int i)
        {
            bool t;
            try
            {
                utOfWork.AdministratorRepository.Delete(i);
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
