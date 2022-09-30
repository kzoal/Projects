using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemographicInformation.Models;

namespace DemographicInformation.Repository
{
    internal interface IPerson<T> where T: class
    {
        void CreatePerson(T Person);

        IEnumerable<T> GetPersons();

        T GetPersonByID(int PersonId);

        void UpdatePerson(T Person);

        void DeletePerson(string idsToDelete);

        void Save();
    }
}
