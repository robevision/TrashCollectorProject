using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Trash_Collector_Project.Models
{
    public class Employee
    {
        public int ID { get; set; }
        [Display(Name = "Zip Code")]
        public int ZipCode { get; set; }
    }
}