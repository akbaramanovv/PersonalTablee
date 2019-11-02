using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PersonalTable.Models
{
    public class PersonWM
    {
        public Person Person { get; set; }

        public string Enterdate { get; set; }
        public string Exitdate { get; set; }

        public List<string> WeekDays { get; set; }
        [Display(Name ="Bazar ertəsi")]
        public bool Be { get; set; }
        [Display(Name = "Çərşənbə axşamı ")]

        public bool Ca { get; set; }
        [Display(Name = "Çərşənbə ")]

        public bool C { get; set; }
        [Display(Name = "Cümə axşamı ")]

        public bool CumaA { get; set; }
        [Display(Name = "Cümə ")]

        public bool Cuma { get; set; }
        [Display(Name = "Şənbə ")]

        public bool S { get; set; }
        [Display(Name = "Bazar ")]
        public HttpPostedFileBase File { get; set; }
        public bool B { get; set; }







    }
}