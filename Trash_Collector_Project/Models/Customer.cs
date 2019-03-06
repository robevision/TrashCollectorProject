using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Trash_Collector_Project.Models
{
    public class Customer
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public bool Pickup { get; set; }
        public DateTime StartBreak { get; set; }
        public DateTime EndBreak { get; set; }
        public bool Paid { get; set; }
        public DateTime ExtraPickup { get; set; }
        public int PickupTotalFromMonth { get; set; }
        [ForeignKey("User")]
        public HashSet<string> UserId { get; set; }

    }
}