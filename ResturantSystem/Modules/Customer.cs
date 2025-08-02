using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantSystem.Modules
{
   public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public Customer(int customerId, string name, string phoneNumber, string email = "")
        {
            CustomerId = customerId;
            Name = name;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public override string ToString()
        {
            return $"Customer ID: {CustomerId}, Name: {Name}, Phone: {PhoneNumber}, Email: {Email}";
        }
    }
}
