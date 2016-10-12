using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DirectoryPlusOne.Models;

namespace DirectoryPlusOne.DAL
{
    public class DirectoryInitilizer
    {
        public static void Initialize(DirectoryContext context)
        {            
            context.Database.EnsureCreated();
            if (context.People.Any())
            {                
                return; //the db is seeded
            }
            var people = new Person[] {
                    new Person { CaseUserID = "abc123", FirstName = "Alice", LastName="Contera", LastModified=DateTime.Now, PhoneNumber="216-368-0000" },
                    new Person { CaseUserID = "abc124", FirstName = "Alice2", LastName="Contera2", LastModified=DateTime.Now, PhoneNumber="216-368-2000"},
                    new Person { CaseUserID = "abc1250", FirstName = "Alice3", LastName="Contera3", LastModified=DateTime.Now, PhoneNumber="216-368-3000" },
                    new Person { CaseUserID = "not146", FirstName = "Not", LastName="InGroup", LastModified=DateTime.Now, PhoneNumber="216-368-4000" },
                    new Person { CaseUserID = "not140", FirstName = "Not", LastName="InOffice", LastModified=DateTime.Now, PhoneNumber="216-368-5000" }
                };


            foreach (Person p in people)
            {
               context.People.Add(p);
            }
            context.SaveChanges();

            var offices = new Office[] {
                    new Office { Building = "Nursing", RoomNumber="219G" },
                    new Office { Building = "Nursing", RoomNumber="219F" },
                    new Office { Building = "Wood", RoomNumber="215" },
                    new Office { Building = "Nursing", RoomNumber="1115" },
                    new Office { Building = "MiddleEarth", RoomNumber="NOB150" },
                };

            foreach (Office o in offices)
            {
                context.Offices.Add(o);
            }         
            context.SaveChanges();

            var groups = new Group[] {                        
                        new Group { GroupName = "Nursing", SubGroupName = "Staff", AdGroupName="nursing@staff.case.edu", Description="Nursing Staff", Email="fpb-staff@case.edu" },
                        new Group { GroupName = "Nursing", SubGroupName = "Faculty", AdGroupName="nursing@faculty.case.edu", Description="Nursing Staff", Email="fpb-staff@case.edu" },
                        new Group { GroupName = "Nursing", AdGroupName="nursing@case.edu", Description="Nursing School", Phone="216-368-4700" },
                        new Group { GroupName = "Nursing" ,SubGroupName="IT", AdGroupName="nurs-dept-it", Description="Nursing School Hackers", Phone="216-368-6322" }
                };
            foreach (Group g in groups)
            {
                context.Groups.Add(g);
            }            
            context.SaveChanges();

            var personoffices = new PersonOffice[] {
                    new PersonOffice {
                        CaseUserID = people.Single(a => a.LastName == "Contera").CaseUserID,
                        OfficeID = offices.Single(a => a.Building == "Nursing" && a.RoomNumber == "219G").OfficeID,
                    },
                    new PersonOffice {
                        CaseUserID = people.Single(a => a.LastName == "Contera2").CaseUserID,
                        OfficeID = offices.Single(a => a.Building == "Nursing" && a.RoomNumber == "219F").OfficeID,
                    }
            };

            foreach (PersonOffice po in personoffices)
            {
                context.PersonOffice.Add(po);
            }
            context.SaveChanges();

            var persongroups = new PersonGroup[] {
                    new PersonGroup {
                        CaseUserID = people.Single(a => a.LastName == "Contera").CaseUserID,
                        GroupID = groups.Single(a => a.GroupName == "Nursing" && a.SubGroupName == "Staff").GroupID
                    },
                    new PersonGroup {
                        CaseUserID = people.Single(a => a.LastName == "Contera2").CaseUserID,
                        GroupID = groups.Single(a => a.GroupName == "Nursing" && a.SubGroupName == null).GroupID
                    }
                };

            foreach (PersonGroup pg in persongroups)
            {
                context.PersonGroup.Add(pg);
            }
            context.SaveChanges();
        }
    }
}
