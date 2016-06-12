using Recruitement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitement.Data.Configuration
{
    public class OfferConfiguration : EntityTypeConfiguration<Offer>
    {
        public OfferConfiguration()
        {
            ToTable("Offers");
            HasMany(o => o.Applications).WithRequired(a => a.Offer).WillCascadeOnDelete(false);
            HasMany(o => o.Notifications).WithRequired(n => n.Offer).WillCascadeOnDelete(false);
        }
    }
}
