using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trash_Collector_Project.Models
{
    public class CustomerAddressViewModels
    {
        public Customer Customer {get; set;}
        public Address Address { get; set; }

        public List<Customer> Customers { get; set;}
        public List<Address> Addresses { get; set;}
        
    }
}