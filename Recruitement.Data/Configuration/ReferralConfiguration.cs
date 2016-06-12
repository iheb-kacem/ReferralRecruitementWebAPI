using Recruitement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitement.Data.Configuration
{
    public class ReferralConfiguration : EntityTypeConfiguration<Referral>
    {
        public ReferralConfiguration()
        {
            HasMany(r => r.Applications).WithRequired(a => a.Referral);
            HasMany(r => r.Notifications).WithRequired(n => n.Referral);
        }
    }
}
