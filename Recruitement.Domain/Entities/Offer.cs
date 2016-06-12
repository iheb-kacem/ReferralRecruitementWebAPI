using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitement.Domain.Entities
{
    public class Offer
    {
        //Properties
        [Key]
        public int OfferID { get; set; }
        
        public string OfferName { get; set; }
        
        [DataType(DataType.Text)]
        [Required]
        public string Note { get; set; }
        
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }
        
        
        //Navigation Properties

        public virtual Recruiter Recruiter { get; set; }
       
        public virtual Reward Reward { get; set; }
        
        public virtual ICollection<Application> Applications { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
    }
}
