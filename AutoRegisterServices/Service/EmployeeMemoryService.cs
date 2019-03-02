using AutoRegisterServices.Application.Entities;

using System;
using System.Collections.Generic;
using System.Linq;

namespace AutoRegisterServices.Service
{
    public class EmployeeMemoryService : IEmployeeService
    {
        private readonly List<Employee> employees = new List<Employee>();
        public EmployeeMemoryService()
        {
            employees.Add(
                new Employee
                {
                    Id = 1,
                    FirstName = "Sinjul",
                    FamilyName = "MSBH",
                    StartDateAtBench = new DateTime(2019, 03, 02),
                    EndDateAtBench = new DateTime(2019, 03, 02),
                    Skillset = ".NET Tech Arch"
                });

            employees.Add(
                new Employee
                {
                    Id = 2,
                    FirstName = "Jack",
                    FamilyName = "Slater",
                    StartDateAtBench = new DateTime(2019, 03, 02),
                    EndDateAtBench = new DateTime(2019, 03, 02),
                    Skillset = "Angular"
                });
        }
        public bool Add(Employee model)
        {
            model.Id = employees.Max(c => c.Id) + 1;
            employees.Add(model);
            return true;
        }
        public IEnumerable<Employee> GetAll() => employees.AsEnumerable();
        public Employee GetById(int id) => employees.FirstOrDefault(c => c.Id == id);
    }
}
