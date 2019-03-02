using System;

namespace AutoRegisterServices.Application.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string FamilyName { get; set; }
        public DateTime StartDateAtBench { get; set; }
        public DateTime? EndDateAtBench { get; set; }
        public string Skillset { get; set; }
    }
}
