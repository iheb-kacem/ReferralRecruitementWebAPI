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
    public class RecruiterService
    {
        static DatabaseFactory dbFactory = new DatabaseFactory();
        IUnitOfWork utOfWork = new UnitOfWork(dbFactory);

        public IEnumerable<Recruiter> GetRecruiters()
        {
            return utOfWork.RecruiterRepository.GetAll().ToList();
        }

        public Recruiter GetRecruiter(int id)
        {
            return utOfWork.RecruiterRepository.GetById(id);
        }

        public Boolean CreateRecruiter(Recruitement.Domain.Entities.Recruiter recruiter)
        {
            bool t;
            try
            {
                utOfWork.RecruiterRepository.Add(recruiter);
                t = utOfWork.Commit();
            }
            catch
            {
                utOfWork = new UnitOfWork(new DatabaseFactory());
                return false;
            }
            return t;

        }

        public Boolean UpdateRecruiter(Recruitement.Domain.Entities.Recruiter recruiter)
        {
            bool t;
            try
            {
                recruiter.ConfirmePassword = recruiter.Password;
                utOfWork.RecruiterRepository.Update(recruiter);
                t = utOfWork.Commit();
            }
            catch
            {
                utOfWork = new UnitOfWork(new DatabaseFactory());
                return false;
            }
            return t;
        }

        public Boolean DeleteRecruiter(int i)
        {
            bool t;
            try
            {
                utOfWork.RecruiterRepository.Delete(i);
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
