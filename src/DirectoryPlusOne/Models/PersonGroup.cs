using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DirectoryPlusOne.Models
{
    public class PersonGroup
    {
        [Key, ForeignKey("Person"), Column(Order = 0)]       
        public string CaseUserID { get; set; }
        [Key, ForeignKey("Group"), Column(Order = 1)]
        public int GroupID { get; set; }

        public virtual Person Person { get; set; }
        public virtual Group Group { get; set; }
    
    }
}
