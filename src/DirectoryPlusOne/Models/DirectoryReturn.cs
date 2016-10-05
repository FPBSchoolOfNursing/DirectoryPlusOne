using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DirectoryPlusOne.Models
{
    public class DirectoryReturn
    {
        public string Name { get; set; }
        public string PersonPhone { get; set; }
        public string OfficePhone { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
        public DateTime? Modified { get; set; }
    }
}
