using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitement.Domain.Entities
{
    public class Tenancy
    {
        //Properties
        [Key]
        public int EntrepriseID { get; set; }
        
        [Required]
        public string EntrepriseName { get; set; }
        
        public byte[] Logo { get; set; }
        public string TextColor { get; set; }
        public string TmpColor { get; set; }
        public bool Status { get; set; }
        

        
        //Navigation Properties

        public virtual Administrator Administrator { get; set; }

        public  virtual ICollection<Referral> Referrals { get; set; }
        public virtual  ICollection<Recruiter> Recruiters{ get; set; }
    }
}
