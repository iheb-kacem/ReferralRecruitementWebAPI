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
    public class ReferralService
    {
        static DatabaseFactory dbFactory = new DatabaseFactory();
        IUnitOfWork utOfWork = new UnitOfWork(dbFactory);

        public IEnumerable<Referral> GetReferrals()
        {
            return utOfWork.ReferralRepository.GetAll().ToList();
        }

        public Referral GetReferral(int id)
        {
            return utOfWork.ReferralRepository.GetById(id);
        }

        public Boolean CreateReferral(Recruitement.Domain.Entities.Referral referral)
        {
            bool t;
            try
            {
                utOfWork.ReferralRepository.Add(referral);
                t = utOfWork.Commit();
            }
            catch
            {
                utOfWork = new UnitOfWork(new DatabaseFactory());
                return false;
            }
            return t;

        }

        public Boolean UpdateReferral(Recruitement.Domain.Entities.Referral referral)
        {
            bool t;
            try
            {
                referral.ConfirmePassword = referral.Password;
                utOfWork.ReferralRepository.Update(referral);
                t = utOfWork.Commit();
            }
            catch
            {
                utOfWork = new UnitOfWork(new DatabaseFactory());
                return false;
            }
            return t;
        }

        public Boolean DeleteReferral(int i)
        {
            bool t;
            try
            {
                utOfWork.ReferralRepository.Delete(i);
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
