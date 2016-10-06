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
                    new Office { Building = "Nursing", RoomNumber="219G" },
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
                //var nursitgroupid = GetFakeGroups.SingleOrDefault(a => a.GroupName == "nurs-dept-it").GroupID;

                return new PersonGroup[]
                {
                    new PersonGroup { GroupID = 0, CaseUserID = "abc123"}, //put the first two people in nurs-dept-it
                    new PersonGroup { GroupID = 0, CaseUserID = "abc124"},
                    new PersonGroup { GroupID = 1, CaseUserID = "abc1250"}, //put the last two people in utech
                    new PersonGroup { GroupID = 1, CaseUserID = "abc1250"},
                    new PersonGroup { GroupID = 2, CaseUserID = "not140"}, //Not InOffice is in this group
                };
            }
        }
    }
}
