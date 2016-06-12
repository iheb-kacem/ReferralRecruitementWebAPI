using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitement.Domain.Entities
{
    public class Feedback
    {
        //Properties
        [Key]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int FeedbackID { get; set; }

        [DataType(DataType.MultilineText)]
        [Required]
        public string Note { get; set; }
        

        public virtual Application Application { get; set; }
    }
}
