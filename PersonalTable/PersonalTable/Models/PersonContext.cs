using PersonalTable.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;

namespace PersonalTable
{
    public class PersonContext : DbContext
    {
       

        public PersonContext():base("name=PersonCS")
        {

        }
        public DbSet<Person> Persons { get; set; }

        public DbSet<Visitor> Visitors { get; set; }
        public DbSet<VisitDay> VisitDays { get; set; }


        public DbSet<Position> Positions { get; set; }
        
    }
}