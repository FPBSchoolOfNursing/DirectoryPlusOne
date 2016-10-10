using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using DirectoryPlusOne.DAL;

namespace DirectoryPlusOne.Migrations
{
    [DbContext(typeof(DirectoryContext))]
    partial class DirectoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DirectoryPlusOne.Models.Group", b =>
                {
                    b.Property<int>("GroupID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Email");

                    b.Property<string>("GroupName");

                    b.Property<string>("Phone");

                    b.HasKey("GroupID");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("DirectoryPlusOne.Models.Office", b =>
                {
                    b.Property<int>("OfficeID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Building");

                    b.Property<string>("Elevation");

                    b.Property<string>("Latitude");

                    b.Property<string>("Longitude");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("RoomNumber");

                    b.Property<float?>("SquareFeet");

                    b.HasKey("OfficeID");

                    b.ToTable("Offices");
                });

            modelBuilder.Entity("DirectoryPlusOne.Models.Person", b =>
                {
                    b.Property<string>("CaseUserID");

                    b.Property<string>("FirstName");

                    b.Property<string>("HomePageURL");

                    b.Property<string>("ImageURL");

                    b.Property<DateTime?>("LastModified");

                    b.Property<string>("LastName");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("Prefix");

                    b.Property<string>("Suffix");

                    b.Property<string>("Title");

                    b.HasKey("CaseUserID");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("DirectoryPlusOne.Models.PersonGroup", b =>
                {
                    b.Property<string>("CaseUserID");

                    b.Property<int>("GroupID");

                    b.HasKey("CaseUserID", "GroupID");

                    b.HasIndex("CaseUserID");

                    b.HasIndex("GroupID");

                    b.ToTable("PersonGroup");
                });

            modelBuilder.Entity("DirectoryPlusOne.Models.PersonOffice", b =>
                {
                    b.Property<string>("CaseUserID");

                    b.Property<int>("OfficeID");

                    b.HasKey("CaseUserID", "OfficeID");

                    b.HasIndex("CaseUserID");

                    b.HasIndex("OfficeID");

                    b.ToTable("PersonOffice");
                });

            modelBuilder.Entity("DirectoryPlusOne.Models.PersonRole", b =>
                {
                    b.Property<int>("RoleID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CaseUserID");

                    b.Property<DateTime?>("Expires");

                    b.Property<string>("Role");

                    b.HasKey("RoleID");

                    b.HasIndex("CaseUserID");

                    b.ToTable("PersonRole");
                });

            modelBuilder.Entity("DirectoryPlusOne.Models.PersonGroup", b =>
                {
                    b.HasOne("DirectoryPlusOne.Models.Person", "Person")
                        .WithMany("PersonGroup")
                        .HasForeignKey("CaseUserID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DirectoryPlusOne.Models.Group", "Group")
                        .WithMany("PersonGroup")
                        .HasForeignKey("GroupID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DirectoryPlusOne.Models.PersonOffice", b =>
                {
                    b.HasOne("DirectoryPlusOne.Models.Person", "Person")
                        .WithMany("PersonOffice")
                        .HasForeignKey("CaseUserID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DirectoryPlusOne.Models.Office", "Office")
                        .WithMany("PersonOffice")
                        .HasForeignKey("OfficeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DirectoryPlusOne.Models.PersonRole", b =>
                {
                    b.HasOne("DirectoryPlusOne.Models.Person", "Person")
                        .WithMany("Roles")
                        .HasForeignKey("CaseUserID");
                });
        }
    }
}
