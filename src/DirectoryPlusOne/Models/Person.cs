using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DirectoryPlusOne.Models
{
    public class Person
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]        
        public string CaseUserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string PhoneNumber { get; set; }
        public string ImageURL { get; set; }
        public string HomePageURL { get; set; }
        public string Prefix { get; set; }
        public string Suffix { get; set; }
        public string Title { get; set; }
        public DateTime? LastModified { get; set; }
        public virtual ICollection<PersonRole> Roles { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
        public virtual ICollection<Office> Offices { get; set; }
    }
}
