using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DirectoryPlusOne.Models
{
    public class Group
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GroupID { get; set; }
        [Required]
        public string GroupName { get; set; }
        public string SubGroupName { get; set; }
        [Required]
        public string AdGroupName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }

        public virtual ICollection<PersonGroup> PersonGroup { get; set; }
    }
}
