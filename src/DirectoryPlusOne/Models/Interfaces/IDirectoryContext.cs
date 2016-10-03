using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DirectoryPlusOne.Models.Interfaces
{
    public interface IDirectoryContext
    {
        DbSet<Person> People { get; set; }
        DbSet<Office> Offices { get; set; }
        DbSet<PersonRole> Roles { get; set; }
        DbSet<Group> Groups { get; set; }
        int SaveChanges();
    }
}
