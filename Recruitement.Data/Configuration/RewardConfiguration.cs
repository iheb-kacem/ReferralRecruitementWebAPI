using Recruitement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitement.Data.Configuration
{
    public class RewardConfiguration : EntityTypeConfiguration<Reward>
    {
        public RewardConfiguration()
        {
            ToTable("Rewards");
            HasMany(r => r.Offers).WithRequired(o => o.Reward);
        }
    }
}
