using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DirectoryPlusOne.Models;

namespace DirectoryPlusOne.DAL.Interfaces
{
    public interface IDirectoryContext
    {
        DbSet<Person> People { get; set; }
        DbSet<Office> Offices { get; set; }
        DbSet<PersonRole> Roles { get; set; }
        DbSet<Group> Groups { get; set; }
        DbSet<PersonOffice> PersonOffice { get; set; }
        DbSet<PersonGroup> PersonGroup { get; set; }
        int SaveChanges();
    }
}
