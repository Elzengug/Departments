using System;
using System.Linq;
using System.Threading.Tasks;
using Departments.BLL.Providers.Contracts;
using Departments.ViewModels;
using Departments.ViewModels.Converters;
using Microsoft.AspNetCore.Mvc;

namespace Departments.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeProvider _employeeProvider;
        //private readonly IDepartmentStaffProvider _departmentStaffProvider;
        public EmployeeController( IEmployeeProvider employeeProvider)
        {
            //_departmentStaffProvider = departmentStaffProvider;
            _employeeProvider = employeeProvider;
        }

        #region GetAllEmployees

        [HttpGet]
        [Route("GetAllEmployees")]
        public IActionResult GetAllEmployees()
        {
            try
            {
                var employees = _employeeProvider.GetAllEmployeesAsync();
                return Ok(employees);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        #endregion

        #region GetAllEmployees

        [HttpGet]
        [Route("GetEmployeesById")]
        public async Task<IActionResult> GetEmployeesById(int id, int page)
        {
            int pageSize = 3;
            try
            {
                var employees = await _employeeProvider.GetEmployeesByDepartmentIdAsync(id);
                var count = employees.Count;
                var items = employees.Skip((page - 1) * pageSize).Take(pageSize).ToList();

                PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
                EmployeePageViewModel employeePageViewModel = new EmployeePageViewModel
                {
                    PageViewModel = pageViewModel,
                    Employees = employees
                };

                return Ok(employeePageViewModel);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        #endregion
        #region CreateEmployee

        [HttpPost]
        [Route("CreateEmployee")]
        public async Task<IActionResult> CreateEmployee([FromBody]EmployeeViewModel model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest();
                }

                await _employeeProvider.CreateEmployeeAsync(ViewToData.ConvertEmployee(model));
                return Ok();
            }
            catch (ArgumentException)
            {
                return StatusCode(403);
            }
            catch (OperationCanceledException)
            {
                return StatusCode(403);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        #endregion

        #region UpdateEmployee

        [HttpPut]
        [Route("UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployee([FromBody]EmployeeViewModel model, int id)
        {
            try
            {
                if (model.Name == null)
                {
                    return BadRequest();
                }

                model.Id = id;
                await _employeeProvider.EditEmployeeAsync(ViewToData.ConvertEmployee(model));
                return Ok();
            }
            catch (ArgumentException)
            {
                return StatusCode(403);
            }
            catch (OperationCanceledException)
            {
                return StatusCode(403);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        #endregion

        #region DeleteEmployee

        [HttpDelete]
        [Route("DeleteEmployee")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            try
            {
                await _employeeProvider.RemoveEmployeeAsync(id);
                return Ok();
            }
            catch (ArgumentException)
            {
                return StatusCode(403);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        #endregion

    }
}