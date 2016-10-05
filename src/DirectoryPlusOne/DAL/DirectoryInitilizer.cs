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

            var people = new Person[]
                {
                    new Person { CaseUserID = "abc123", FirstName = "Alice", LastName="Contera", LastModified=DateTime.Now, PhoneNumber="216-368-0000" },
                    new Person { CaseUserID = "abc124", FirstName = "Alice2", LastName="Contera2", LastModified=DateTime.Now, PhoneNumber="216-368-2000"},
                    new Person { CaseUserID = "abc1250", FirstName = "Alice3", LastName="Contera3", LastModified=DateTime.Now, PhoneNumber="216-368-3000" }
                };

            foreach (Person p in people)
            {
               context.People.Add(p);
            }
            context.SaveChanges();

            var offices = new Office[] {
                    new Office { CaseUserID = "abc123", Building = "Nursing", RoomNumber="219G" },
                    new Office { CaseUserID = "abc124", Building = "Nursing", RoomNumber="219G" },
                    new Office { CaseUserID = "abc1250", Building = "Wood", RoomNumber="215" },
                    new Office { Building = "Nursing", RoomNumber="1115" },
                    new Office { Building = "MiddleEarth", RoomNumber="NOB150" },
                };

            foreach(Office o in offices)
            {
                context.Offices.Add(o);
            }         
            context.SaveChanges();

            var groups = new Group[]
                {
                    new Group { GroupName = "nurs-dept-it", Description="Nursing IT", Email="fpbhelpdesk@case.edu" },
                    new Group { GroupName = "utech", Description="uTech peeps", Email="utech@case.edu" },
                };

            foreach (Group g in groups)
            {
                context.Groups.Add(g);
            }            
            context.SaveChanges();
        }
    }
}
