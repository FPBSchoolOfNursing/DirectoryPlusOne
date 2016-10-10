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
            
            foreach (Person p in GetFakePeople)
            {
               context.People.Add(p);
            }
            context.SaveChanges();
            
            foreach (Office o in GetFakesOffices)
            {
                context.Offices.Add(o);
            }         
            context.SaveChanges();
          
            foreach (Group g in GetFakeGroups)
            {
                context.Groups.Add(g);
            }            
            context.SaveChanges();

            foreach (PersonOffice po in GetFakePersonOffices)
            {
                context.PersonOffice.Add(po);
            }
            context.SaveChanges();

            foreach (PersonGroup pg in GetFakePersonGroups)
            {
                context.PersonGroup.Add(pg);
            }
            context.SaveChanges();
        }

        public static Person[] GetFakePeople
        {
            get
            {
                return new Person[]
                {
                    new Person { CaseUserID = "abc123", FirstName = "Alice", LastName="Contera", LastModified=DateTime.Now, PhoneNumber="216-368-0000" },
                    new Person { CaseUserID = "abc124", FirstName = "Alice2", LastName="Contera2", LastModified=DateTime.Now, PhoneNumber="216-368-2000"},
                    new Person { CaseUserID = "abc1250", FirstName = "Alice3", LastName="Contera3", LastModified=DateTime.Now, PhoneNumber="216-368-3000" },
                    new Person { CaseUserID = "not146", FirstName = "Not", LastName="InGroup", LastModified=DateTime.Now, PhoneNumber="216-368-4000" },
                    new Person { CaseUserID = "not140", FirstName = "Not", LastName="InOffice", LastModified=DateTime.Now, PhoneNumber="216-368-5000" }
                };
            }
        }

        public static Office[] GetFakesOffices
        {
            get {
                return new Office[] {
                    new Office { Building = "Nursing", RoomNumber="219G" },
                    new Office { Building = "Nursing", RoomNumber="219F" },
                    new Office { Building = "Wood", RoomNumber="215" },
                    new Office { Building = "Nursing", RoomNumber="1115" },
                    new Office { Building = "MiddleEarth", RoomNumber="NOB150" },
                };
            }
        }

        public static Group[] GetFakeGroups
        {
            get
            {
                return new Group[] {
                        new Group { GroupName = "nurs-dept-it", Description="Nursing IT", Email="fpbhelpdesk@case.edu" },
                        new Group { GroupName = "utech", Description="uTech peeps", Email="utech@case.edu" },
                        new Group { GroupName = "onlyonepersoninhere", Description="only1inhere", Email="onlyone@case.edu" },
                };
            }
        }
      
        public static PersonGroup[] GetFakePersonGroups
        {
            get
            {
                return new PersonGroup[] {
                    new PersonGroup {
                        CaseUserID = GetFakePeople.Single(a => a.LastName == "Contera").CaseUserID,
                        GroupID = GetFakeGroups.Single(a => a.GroupName == "utech").GroupID
                    },
                    new PersonGroup {
                        CaseUserID = GetFakePeople.Single(a => a.LastName == "Contera2").CaseUserID,
                        GroupID = GetFakeGroups.Single(a => a.GroupName == "utech").GroupID
                    }
                };
            }
        }

      
        public static PersonOffice[] GetFakePersonOffices
        {
            get
            {
                return new PersonOffice[] {
                    new PersonOffice {
                        CaseUserID = GetFakePeople.Single(a => a.LastName == "Contera").CaseUserID,
                        OfficeID = GetFakesOffices.Single(a => a.Building == "Nursing" && a.RoomNumber == "219G").OfficeID,
                    },
                    new PersonOffice {
                        CaseUserID = GetFakePeople.Single(a => a.LastName == "Contera2").CaseUserID,
                        OfficeID = GetFakesOffices.Single(a => a.Building == "Nursing" && a.RoomNumber == "219F").OfficeID,
                    }
                };
            }
        }
    }
}
