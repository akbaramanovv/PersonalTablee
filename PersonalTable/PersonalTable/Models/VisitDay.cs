using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PersonalTable.Models
{
    public class VisitDay
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Visitor")]
        public int VisitorId { get; set; }
        public DateTime EnterTime { get; set; }

        public DateTime ExitTime { get; set; }

        public Visitor Visitor { get; set; }


    }
}