using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using DirectoryPlusOne.DAL;
using DirectoryPlusOne.DAL.Interfaces;
using DirectoryPlusOne.Models;

namespace DirectoryPlusOne.Services
{
    public class DirectoryService : IRepository<Person>
    {
        private IDirectoryContext _context;
        public DirectoryService(IDirectoryContext context)
        {
            _context = context;
        }

        public bool Delete(int entityid)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Person entity)
        {
            bool deleted = false;
            var persontodelete = _context.People.SingleOrDefault(a => a.CaseUserID == entity.CaseUserID);
            if (persontodelete != null)
            {
                _context.People.Remove(entity);
                int changes = _context.SaveChanges();
                deleted = (changes > 0);                
            }
            else
            {
                deleted = false;
            }
            return deleted;
        }

        public IQueryable<Person> GetAll()
        {
            return _context.People.Select(a => a);
        }

        [Obsolete("This method can not be used in with the Person entity. Please use GetByCaseUserID(string)", true)]
        public Person GetById(int entityid)
        {
            throw new NotImplementedException("The Person table uses Case User ID as a primary key. Please use the GetByCaseUserID Method");
        }

        public Person GetByCaseUserID(string CaseUserID)
        {
            return _context.People.SingleOrDefault(a => a.CaseUserID == CaseUserID);
        }

        public bool Insert(Person entity)
        {
            _context.People.Add(entity);
            int changes = _context.SaveChanges();
            return (changes > 0);
        }

        public bool InsertOrUpdate(Person entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Person> SearchFor(Expression<Func<Person, bool>> predicate)
        {
            return _context.People.Where(predicate);
        }
    }
}
