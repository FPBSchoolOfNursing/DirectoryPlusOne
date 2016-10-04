using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DirectoryPlusOne.Models
{
    public class PersonRole
    {
        
        public int RoleID { get; set; }
        public string Role { get; set; }
        public DateTime? Expires { get; set; }
        public virtual Person Person { get; set; }
    }
}
