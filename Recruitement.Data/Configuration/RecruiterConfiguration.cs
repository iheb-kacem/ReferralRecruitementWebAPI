using Recruitement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitement.Data.Configuration
{
    public class RecruiterConfiguration : EntityTypeConfiguration<Recruiter>
    {
        public RecruiterConfiguration()
        {
            HasMany(r => r.Offers).WithRequired(o => o.Recruiter);
        }
    }
}
