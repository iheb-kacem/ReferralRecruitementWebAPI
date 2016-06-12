using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitement.Domain.Entities
{
    public class Application
    {
        //Properties
        [Key]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int ApplicationID { get; set; }
        
        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }
        
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }
        
        [DataType(DataType.PhoneNumber)]
        [Required]
        public string PhoneNumber { get; set; }
        
        [Required]
        public byte[] CV { get; set; }
        
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }
        
        public string Status { get; set; }
        
        //Foreign Keys

        
        //Navigation properties

        public virtual Referral Referral { get; set; }

        public virtual Offer Offer { get; set; }
        
        public virtual ICollection<Feedback> Feedbacks { get; set; }

    }
}
