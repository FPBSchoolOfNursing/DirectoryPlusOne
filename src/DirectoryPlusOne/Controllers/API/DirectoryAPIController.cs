using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DirectoryPlusOne.DAL;
using DirectoryPlusOne.Models;
// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace DirectoryPlusOne.Controllers.API
{
    [Route("directory")]
    public class DirectoryAPIController : Controller
    {
        private readonly DirectoryContext _context;
        public DirectoryAPIController(DirectoryContext context)
        {
            _context = context;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<DirectoryReturn> Get()
        {            
            var directory = (from p in _context.People
                             join po in _context.PersonOffice on p.CaseUserID equals po.CaseUserID
                             join o in _context.Offices on po.OfficeID equals o.OfficeID
                             select new DirectoryReturn {
                                 Email = p.CaseUserID + "@case.edu",
                                 Location = o.Building + " " + o.RoomNumber,
                                 Name = p.FirstName + " " + p.LastName,
                                 OfficePhone = o.PhoneNumber,
                                 PersonPhone = p.PhoneNumber,
                                 Modified = p.LastModified
                             }).ToArray(); //returning arrays are more savvy

            return directory;
        }

        // GET api/values/5
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
