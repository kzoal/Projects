using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using DemographicInformation.Models;

namespace DemographicInformation.Data
{
    public class DemographicContext :DbContext
    {
        public DemographicContext() : base("name=DemographicContext")
        {
        }

        public DbSet<Person> Persons { get; set; }
    }
}