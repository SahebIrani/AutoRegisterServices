using System;

namespace AutoRegisterServices.Application.Entities
{
    public class Person
    {
        public Guid PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastNmae { get; set; }
        public byte Age { get; set; }
    }
}