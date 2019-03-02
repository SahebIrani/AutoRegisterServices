using AutoRegisterServices.Application.Entities;
using AutoRegisterServices.Application.Results;
using AutoRegisterServices.Service;

using Mapster;

using Microsoft.AspNetCore.Mvc;

using System;

namespace AutoRegisterServices.UseCases.EmployeeDetails
{
    [Route("api/[controller]"), ApiController]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService Service;
        public EmployeeController(IEmployeeService service) => Service = service ?? throw new ArgumentNullException(nameof(service));

        public IActionResult GetAllEmployees()
        {
            var employeesFromRepo = Service.GetAll();
            var employees = employeesFromRepo.Adapt<EmployeeResult[]>();
            return Ok(employees);
        }

        [HttpGet("{id}", Name = "GetEmployeeDetails")]
        public IActionResult GetEmployeeDetails(int id)
        {
            var employeeFromRepo = Service.GetById(id);

            if (employeeFromRepo == null)
                return NotFound(new { Error = String.Format("Employee with Id : {0} has not been found", id) });

            var employee = employeeFromRepo.Adapt<EmployeeResult>();

            return Ok(employee);
        }

        [HttpPost]
        public IActionResult AddEmployee(EmployeeCreateResult employeeCreate)
        {
            if (employeeCreate == null) return BadRequest();

            var employeeEntity = employeeCreate.Adapt<Employee>();

            if (!Service.Add(employeeEntity)) throw new Exception($"Creation of employee failed .. !!!!");

            var employeeToReturn = employeeEntity.Adapt<EmployeeResult>();

            return CreatedAtRoute(nameof(GetEmployeeDetails), new { id = employeeToReturn.Id }, employeeToReturn);
        }
    }
}