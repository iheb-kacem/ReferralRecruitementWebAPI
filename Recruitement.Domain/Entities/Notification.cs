using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitement.Domain.Entities
{
    public class Notification
    {
        //Properties
        [Key]
        public int NotificationID { get; set; }
        
        [DataType(DataType.Text)]
        public string Note { get; set; }
        
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }
        
        
        //Navigation Properties

        public virtual Offer Offer { get; set; }
        
        public virtual Referral Referral { get; set; }

    }
}
