using AutoRegisterServices.Application.Entities;

using System.Collections.Generic;

namespace AutoRegisterServices.Service
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAll();
        Employee GetById(int id);
        bool Add(Employee model);
    }
}