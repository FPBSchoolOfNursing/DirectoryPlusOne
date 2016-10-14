using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DirectoryPlusOne.Helpers.LDAP;

namespace DirectoryPlusOne.Controllers.API
{
    [Route("directory/[Controller]")]
    public class LDAPAPIController : Controller
    {
        [HttpGet()]
        public IActionResult Get()
        {
            var results = LDAP.Query("ldap.case.edu");
           // var result2 = LDAP.Query("ads.case.edu");
            return new ObjectResult(results);
        }

    }
}
