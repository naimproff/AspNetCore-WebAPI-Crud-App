using AspNetCoreWebAPICrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWebAPICrud.EmployeeData
{
    public class MockEmployeeData : IEmployeeData
    {
        List<Employee> employees = new List<Employee>()
        {
            new Employee(){ Id = Guid.NewGuid(), Name ="Naim", Age = 25 },
            new Employee(){ Id = Guid.NewGuid(), Name ="Ratan", Age = 28 },
            new Employee(){ Id = Guid.NewGuid(), Name ="John", Age = 26 },
        };

              
        public List<Employee> GetEmployees()
        {
            return employees;
        }

        public Employee GetEmployeeById(Guid id)
        {
            return employees.SingleOrDefault(c => c.Id == id);
        }

        public Employee AddEmployee(Employee emp)
        {
            emp.Id = Guid.NewGuid();
            employees.Add(emp);
            return emp;
        }

        public void DeleteEmployee(Employee emp)
        {
            employees.Remove(emp);
        }

        public Employee EditEmployee(Employee emp)
        {
            var employee = GetEmployeeById(emp.Id);
            employee.Name = emp.Name;
            employee.Age = emp.Age;
            return employee;
        }

        

        
    }
}
