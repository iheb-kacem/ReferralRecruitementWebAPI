using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recruitement.Domain.Entities;
using Recruitement.Data.Configuration;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace Recruitement.Data
{
    public class RecruitementContext : DbContext
    {
        public RecruitementContext() : base("name=RecruitementDB") {
            this.Configuration.LazyLoadingEnabled = false;
            //Database.SetInitializer<RecruitementContext>(new DropCreateDatabaseIfModelChanges<RecruitementContext>());
            Database.SetInitializer<RecruitementContext>(null);
        }

        public DbSet<Personal> Personals { set; get; }
        public DbSet<Administrator> Administrators { set; get; }
        public DbSet<Superuser> Superusers { set; get; }
        public DbSet<Recruiter> Recruiters { set; get; }
        public DbSet<Referral> Referrals { set; get; }
        public DbSet<Tenancy> Tenancies { set; get; }
        public DbSet<Application> Applications { set; get; }
        public DbSet<Feedback> Feedbacks { set; get; }
        public DbSet<Offer> Offers { set; get; }
        public DbSet<Notification> Notifications { set; get; }
        public DbSet<Reward> Rewards { set; get; }



        //public override int SaveChanges()
        //{
        //    try
        //    {
        //        return base.SaveChanges();
        //    }
        //    catch (DbEntityValidationException dbEx)
        //    {
        //        foreach (var validationErrors in dbEx.EntityValidationErrors)
        //        {
        //            foreach (var validationError in validationErrors.ValidationErrors)
        //            {
        //                Trace.TraceInformation("Class: {0}, Property: {1}, Error: {2}",
        //                    validationErrors.Entry.Entity.GetType().FullName,
        //                    validationError.PropertyName,
        //                    validationError.ErrorMessage);
        //            }
        //        }

        //        throw;
        //    }
        //}


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Configurations.Add(new AdministratorConfiguration());
            //modelBuilder.Configurations.Add(new ApplicationConfiguration());
            //modelBuilder.Configurations.Add(new FeedbackConfiguration());
            //modelBuilder.Configurations.Add(new NotificationConfiguration());
            //modelBuilder.Configurations.Add(new OfferConfiguration());
            //modelBuilder.Configurations.Add(new PersonalConfiguration());
            //modelBuilder.Configurations.Add(new RecruiterConfiguration());
            //modelBuilder.Configurations.Add(new ReferralConfiguration());
            //modelBuilder.Configurations.Add(new RewardConfiguration());
            //modelBuilder.Configurations.Add(new SuperuserConfiguration());
            //modelBuilder.Configurations.Add(new TenancyConfiguration());
        }
    }
}