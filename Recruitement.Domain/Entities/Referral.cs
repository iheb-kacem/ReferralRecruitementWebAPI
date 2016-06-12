using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitement.Domain.Entities
{
    public class Referral : Personal
    {
        //Properties
        public int Bonus { get; set; }
        public int Success { get; set; }
        

        
        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<Application> Applications { get; set; }
    }
}
