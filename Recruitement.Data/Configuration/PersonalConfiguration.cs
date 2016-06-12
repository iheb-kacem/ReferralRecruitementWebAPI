using Recruitement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitement.Data.Configuration
{
    public class PersonalConfiguration : EntityTypeConfiguration<Personal>
    {
        public PersonalConfiguration()
        {
            ToTable("Personals");
            //Map<Superuser>(m => m.Requires("Position").HasValue("Superuser"));
               // .HasRequired(t => t.Tenancy).WithRequiredDependent(s => s.Personal);

            //Map<Referral>(m => m.Requires("Position").HasValue("Referal"));
               // .HasMany(r => r.Applications).WithRequired(a => a.Personal);

            //Map<Referral>(m => m.Requires("Position").HasValue("Referal"))
            //    .HasMany(r => r.Notifications).WithRequired(n => n.Personal);
            
            //Map<Recruiter>(m => m.Requires("Position").HasValue("Recruiter"));
              //  .HasMany(r => r.Offers).WithRequired(o => o.Personal);


            //HasMany(a => a.Tenancies)
            //    .WithRequired(c => c.Personal)
            //    .HasForeignKey(c => c.PersonalID);

            //HasMany(r => r.Applications)
            //    .WithRequired(a => a.Personal)
            //    .HasForeignKey(a => a.PersonalID);

            //HasMany(r => r.Offers)
            //    .WithRequired(o => o.Personal)
            //    .HasForeignKey(o => o.PersonalID).WillCascadeOnDelete(false);

            //HasMany(r => r.Notifications)
            //    .WithRequired(n => n.Personal)
            //    .HasForeignKey(n => n.PersonalID);
        }
    }
}
