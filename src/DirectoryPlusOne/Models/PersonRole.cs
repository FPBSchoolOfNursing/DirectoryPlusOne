using System;

namespace DirectoryPlusOne.Models
{
    public class PersonRole
    {
       
        public int RoleID { get; set; }
        public string Role { get; set; }
        public DateTime? Expires { get; set; }

        public string CaseUserID { get; set; }
        public virtual Person Person { get; set; }
    }
}
