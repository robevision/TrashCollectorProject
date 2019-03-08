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
        [Display(Name = "Garbage Day Preference")]
        public string PickupDay { get; set; }
        public bool? Pickup { get; set; }
        [Display(Name = "Suspend Service")]
        public DateTime? StartBreak { get; set; }
        [Display(Name = "Restart Service")]
        public DateTime? EndBreak { get; set; }
        public bool Paid { get; set; }
        [Display(Name = "One-Time Additional Complimentary Pick-up")]
        public DateTime? ExtraPickup { get; set; }
        public int PickupTotalFromMonth { get; set; }
        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        
    }
}