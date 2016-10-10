
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
        public virtual DbSet<Office> Offices { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<PersonOffice> PersonOffice { get; set; }
        public virtual DbSet<PersonGroup> PersonGroup { get; set; }
        public virtual DbSet<PersonRole> Roles { get; set; }
        public virtual DbSet<Group> Groups { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           //optionsBuilder.UseSqlServer()
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {           
            modelBuilder.Entity<Person>().ToTable("Person"); //Remove the pluralization of table names.
            modelBuilder.Entity<PersonRole>().ToTable("PersonRole");

            #region Primary Keys
            modelBuilder.Entity<PersonRole>()
                .HasKey(t => t.RoleID);

            modelBuilder.Entity<Person>()
                .HasKey(t => t.CaseUserID);

            modelBuilder.Entity<Office>()
                .HasKey(t => t.OfficeID);
            #endregion

            #region Person to Group Many-Many
            modelBuilder.Entity<PersonGroup>()
                .HasKey(t => new { t.CaseUserID, t.GroupID });

            modelBuilder.Entity<PersonGroup>()
                .HasOne(t => t.Person)
                .WithMany(t => t.PersonGroup)
                .HasForeignKey(t => t.CaseUserID);

            modelBuilder.Entity<PersonGroup>()
                .HasOne(t => t.Group)
                .WithMany(t => t.PersonGroup)
                .HasForeignKey(t => t.GroupID);
            #endregion

            #region Person to Office Many-Many
            modelBuilder.Entity<PersonOffice>()
                .HasKey(t => new { t.CaseUserID, t.OfficeID });

            modelBuilder.Entity<PersonOffice>()
                .HasOne(t => t.Person)
                .WithMany(t => t.PersonOffice)
                .HasForeignKey(t => t.CaseUserID);

            modelBuilder.Entity<PersonOffice>()
                .HasOne(t => t.Office)
                .WithMany(t => t.PersonOffice)
                .HasForeignKey(t => t.OfficeID);
            #endregion



        }      
        
    }
}
