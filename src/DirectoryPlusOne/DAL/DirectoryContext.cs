
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DirectoryPlusOne.DAL.Interfaces;
using DirectoryPlusOne.Models;
using Microsoft.EntityFrameworkCore;


namespace DirectoryPlusOne.DAL
{
    public class DirectoryContext : DbContext, IDirectoryContext
    {

        public DirectoryContext(DbContextOptions<DirectoryContext> options) : base(options)
        {
        }
        public DbSet<Office> Offices { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<PersonRole> Roles { get; set; }
        public DbSet<Group> Groups { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           //optionsBuilder.UseSqlServer()
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {           
            modelBuilder.Entity<Person>().ToTable("Person"); //Remove the pluralization of table names.
            modelBuilder.Entity<PersonRole>().ToTable("PersonRole");
        }      
        
    }
}
