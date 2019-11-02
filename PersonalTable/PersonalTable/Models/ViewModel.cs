using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalTable.Models
{
    public class ViewModel
    {
        public List<Person> Person { get; set; }

        public Person Employee { get; set; }

        public List<Position> Positions { get; set; }


    }
}