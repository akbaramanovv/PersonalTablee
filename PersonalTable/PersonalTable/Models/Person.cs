using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PersonalTable.Models
{
    public class Person
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name = "Ad")]

        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        [Column(TypeName = "varchar")]
        [Display(Name = "Soyad")]

        public string Surname { get; set; }
        [Display(Name = "Vəzifə")]

        public string Photo { get; set; }

        public string Days { get; set; }
        public DateTime EnterDate { get; set; }
        public DateTime ExitDate { get; set; }

        [Display(Name ="Vəzifə")]
        public int PositionId { get; set; }
        public List<string> WeekDays { get; set; }
        public virtual Position PositionName { get; set; }
        public List<int> Week { get; set; }
       
    }
}