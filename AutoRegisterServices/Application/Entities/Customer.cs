using System;

namespace AutoRegisterServices.Application.Entities
{
    public class Customer
    {
        public Guid CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastNmae { get; set; }
        public byte Age { get; set; }
    }
}
