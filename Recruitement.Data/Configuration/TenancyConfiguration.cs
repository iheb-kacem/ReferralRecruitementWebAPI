using Recruitement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitement.Data.Configuration
{
    public class TenancyConfiguration : EntityTypeConfiguration<Tenancy>
    {
        public TenancyConfiguration()
        {
            ToTable("Tenancies");
            //HasMany(t => t.Personals).WithRequired(p => p.Tenancy);
            //HasRequired(t => t.Administrator).WithMany(a => a.Tenancies);
            //HasMany(t => t.Recruiters).WithRequired(r => r.Tenancy);
            //HasMany(t => t.Referrals).WithRequired(r => r.Tenancy);
            //HasOptional(t => t.Superuser).WithRequired(s => s.Tenancy);
            
            //HasMany(t => t.Personals)
            //    .WithRequired(r => r.Tenancy)
            //    .HasForeignKey(r => r.EntrepriseID);
            //HasRequired(t => t.Personal)
            //    .WithRequiredPrincipal(s => s.Tenancy);
        }
    }
}
