using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using DemographicInformation.Data;
using DemographicInformation.Models;

namespace DemographicInformation.Repository
{
    public class PersonRepository<T> : IPerson<T> where T : class
    {
        private DemographicContext db;
        private DbSet<T> dbSet;

        public PersonRepository()
        {
            db      = new DemographicContext();
            dbSet   = db.Set<T>();
        }

        public T GetPersonByID(int personId)
        {
            return dbSet.Find(personId);
        }

        public IEnumerable<T> GetPersons()
        {            
            return dbSet.ToList();
        }

        public void CreatePerson(T person)
        {
            dbSet.Add(person);
        }

        public void UpdatePerson(T person)
        {
            db.Entry(person).State = EntityState.Modified;
        }

        public void DeletePerson(string idsToDelete)
        {
            int id              = -1;
            List<int> intList   = idsToDelete.Split(',')
                                .Select(x => { int.TryParse(x, out id); return id; })
                                .Where(x => x != 0)
                                .ToList();

            foreach (int personId in intList)
            {
                T pId = dbSet.Find(personId);
                dbSet.Remove(pId);
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.db != null)
                {
                    this.db.Dispose();
                    this.db = null;
                }
            }
        }
    }
}