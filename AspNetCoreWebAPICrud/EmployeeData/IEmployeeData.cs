using AspNetCoreWebAPICrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWebAPICrud.EmployeeData
{
    public interface IEmployeeData
    {
        List<Employee> GetEmployees();

        Employee GetEmployeeById(Guid id);

        Employee AddEmployee(Employee emp);

        Employee EditEmployee(Employee emp);

        void DeleteEmployee(Employee emp);

    }
}
