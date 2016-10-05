using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DirectoryPlusOne.Models
{
    public class PersonOffice
    {
        [Key, ForeignKey("Person")]
        public string CaseUserID { get; set; }
        [Key, ForeignKey("Office")]
        public int OfficeID { get; set; }

        public virtual Person Person { get; set; }
        public virtual Office Office { get; set; }
    }
}
