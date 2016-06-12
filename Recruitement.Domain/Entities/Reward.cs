using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitement.Domain.Entities
{
    public class Reward
    {
        //Properties
        [Key]
        public int RewardID { get; set; }
        
        [Required]
        public int Sharing { get; set; }
        
        [Required]
        public int HRIntrvw { get; set; }
        
        [Required]
        public int TechIntrvw { get; set; }
        
        [Required]
        public int MnIntrvw { get; set; }
        
        [Required]
        public int Hire { get; set; }
        
        //Navigation Properties
        public virtual ICollection<Offer> Offers { get; set; }
    }
}
