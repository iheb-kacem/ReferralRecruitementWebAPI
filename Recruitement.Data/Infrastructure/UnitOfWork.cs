using Recruitement.Data.Contracts;
using Recruitement.Data.Repositories;
using Recruitement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Reflection;

namespace Recruitement.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private IApplicationRepository applicationRepository;
        private IFeedbackRepository feedbackRepository;
        private INotificationRepository notificationRepository;
        private IOfferRepository offerRepository;
        private IPersonalRepository personalRepository;
        private IRewardRepository rewardRepository;
        private ITenancyRepository tenancyRepository;
        private IAdministratorRepository administratorRepository;
        private ISuperuserRepository superuserRepository;
        private IRecruiterRepository recruiterRepository;
        private IReferralRepository referralRepository;
        RecruitementContext dataContext = null;
        IDatabaseFactory db = null;

        public UnitOfWork(IDatabaseFactory db)
        {
            this.db = db;
        }

        public RecruitementContext DataContext
        {

            get { return dataContext = db.DataContext; }
        }



        public Repositories.IApplicationRepository ApplicationRepository
        {
            get { return applicationRepository = new ApplicationRepository(db); }
        }

        public Repositories.IFeedbackRepository FeedbackRepository
        {
            get { return feedbackRepository = new FeedbackRepository(db); }
        }
        public Repositories.INotificationRepository NotificationRepository
        {
            get { return notificationRepository = new NotificationRepository(db); }
        }

        public Repositories.IOfferRepository OfferRepository
        {
            get { return offerRepository = new OfferRepository(db); }
        }

        public Repositories.IPersonalRepository PersonalRepository
        {
            get { return personalRepository = new PersonalRepository(db); }
        }



        public Repositories.IRewardRepository RewardRepository
        {
            get { return rewardRepository = new RewardRepository(db); }
        }


        public Repositories.ITenancyRepository TenancyRepository
        {
            get { return tenancyRepository = new TenancyRepository(db); }
        }

        public Repositories.IAdministratorRepository AdministratorRepository
        {
            get { return administratorRepository = new AdministratorRepository(db); }
        }

        public Repositories.ISuperuserRepository SuperuserRepository
        {
            get { return superuserRepository = new SuperuserRepository(db); }
        }

        public Repositories.IRecruiterRepository RecruiterRepository
        {
            get { return recruiterRepository = new RecruiterRepository(db); }
        }

        public Repositories.IReferralRepository ReferralRepository
        {
            get { return referralRepository = new ReferralRepository(db); }
        }

        public Boolean Commit()
        {
            try
            {
                DataContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        //DbContextTransaction transaction

        public Boolean Commit(DbContextTransaction transaction)
        {
            try
            {
                DataContext.SaveChanges();
                if (transaction != null)
                {
                    transaction.Commit();
                }

                return true;
            }
            catch (OptimisticConcurrencyException)
            {

                DataContext.GetType().InvokeMember("ClearCache",
                    BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic,null, DataContext, null);
                DataContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        private static string FormatError(DbEntityValidationException ex)
        {
            var build = new StringBuilder();
            foreach (var error in ex.EntityValidationErrors)
            {
                var errorBuilder = new StringBuilder();

                foreach (var validationError in error.ValidationErrors)
                {
                    errorBuilder.AppendLine(string.Format("Property '{0}' errored:{1}", validationError.PropertyName, validationError.ErrorMessage));
                }
                build.AppendLine(errorBuilder.ToString());
            }
            return build.ToString();
        }

        public void Dispose()
        {
            DataContext.Dispose();
        }
    }
}
