using System;

namespace AutoRegisterServices.Application.Results
{
    public class EmployeeCreateResult
    {
        public string FirstName { get; set; }
        public string FamilyName { get; set; }
        public DateTime StartDateAtBench { get; set; }
        public string Skillset { get; set; }
    }
}
