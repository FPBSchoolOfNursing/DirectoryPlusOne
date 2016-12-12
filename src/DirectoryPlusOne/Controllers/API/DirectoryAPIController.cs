using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DirectoryPlusOne.DAL;
using DirectoryPlusOne.Models;
using DirectoryPlusOne.DAL.Interfaces;
using DirectoryPlusOne.Helpers;
// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace DirectoryPlusOne.Controllers.API
{
    [Route("directory")]
    public class DirectoryAPIController : Controller
    {
        /// <summary>
        /// Remove this later. You will have the context in the services class that handles the API methods.
        /// </summary>
        private readonly IDirectoryContext _context;
        public DirectoryAPIController(IDirectoryContext context)
        {
            _context = context;
        }

        // GET: directory
        
        [HttpGet("{group}", Name ="GetDirectoryByGroup")]
        public IActionResult Get(string group)
        {
            try
            {

                if (String.IsNullOrEmpty(group))
                {
                    return NotFound();
                }
                return new ObjectResult(GetDirectoryByGroup(group));
            }
            catch(Exception ex)
            {
                return NotFound(ex); 
            }
        }

        /*        
        [HttpGet("{group}/{subgroup}", Name = "GetDirectoryBySubGroup")]
        public IActionResult Get(string group, string subgroup)
        {
            if (String.IsNullOrEmpty(group) || String.IsNullOrEmpty(subgroup))
            {
                return NotFound();
            }
            return new ObjectResult(GetDirectoryByGroup(subgroup));            
        }
        */
        private IEnumerable<DirectoryReturn> GetDirectoryByGroup(string querygroup)
        {
            try
            {
                var delete = ActiveDirectory.GetUserGroupsFromADS("ads.case.edu", "bdm4");
            }
            catch(Exception ex)
            {
                throw ex;
            }
            var directory = (from p in _context.People
                             join po in _context.PersonOffice on p.CaseUserID equals po.CaseUserID
                             join o in _context.Offices on po.OfficeID equals o.OfficeID
                             join pg in _context.PersonGroup on p.CaseUserID equals pg.CaseUserID
                             join g in _context.Groups on pg.GroupID equals g.GroupID
                             where g.GroupName == querygroup
                             select new DirectoryReturn
                             {
                                 Email = p.CaseUserID + "@case.edu",
                                 Location = o.Building + " " + o.RoomNumber,
                                 Name = p.FirstName + " " + p.LastName,
                                 OfficePhone = o.PhoneNumber,
                                 PersonPhone = p.PhoneNumber,
                                 Modified = p.LastModified
                             }).ToArray(); //returning arrays are more savvy)
            return directory;
        }
        
        /* GET api/values/5*/
        [HttpGet("{id}")]
        public DirectoryReturn Get(int id)
        {
            var directoryitem = (from p in _context.Offices
                                 where p.OfficeID == id
                                select new DirectoryReturn { OfficePhone = p.PhoneNumber, Name = p.Building + " " + p.RoomNumber }).SingleOrDefault();
            return directoryitem;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
