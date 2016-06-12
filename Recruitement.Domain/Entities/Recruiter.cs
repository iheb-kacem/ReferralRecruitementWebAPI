using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitement.Domain.Entities
{
    public class Recruiter : Personal
    {
        public virtual ICollection<Offer> Offers { get; set; }

    }
}
