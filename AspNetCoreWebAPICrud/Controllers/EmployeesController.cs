using AspNetCoreWebAPICrud.EmployeeData;
using AspNetCoreWebAPICrud.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWebAPICrud.Controllers
{
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeData _employeeData;
        public EmployeesController(IEmployeeData employeeData)
        {
            _employeeData = employeeData;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetEmployees()
        {
            return Ok(_employeeData.GetEmployees());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetEmployees(Guid id)
        {
            var employee = _employeeData.GetEmployeeById(id);
            if (employee != null)
            {
                return Ok(employee);
            }
            return NotFound($"Employee with Id: {id} not found!");
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddEmployee(Employee employee)
        {
            _employeeData.AddEmployee(employee);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + employee.Id, employee);
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            var employee = _employeeData.GetEmployeeById(id);
            if (employee != null)
            {
                _employeeData.DeleteEmployee(employee);
                return Ok();
            }
            return NotFound($"Employee with Id: {id} not found!");
        }

        [HttpPatch]
        [Route("api/[controller]/{id}")]
        public IActionResult UpdateEmployee(Employee employee, Guid id)
        {
            var emp = _employeeData.GetEmployeeById(id);
            if (emp != null)
            {
                employee.Id = emp.Id;
                _employeeData.EditEmployee(employee);
                return Ok();
            }
            return NotFound($"Employee with Id: {id} not found!");
        }
    }
}
