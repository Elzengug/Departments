using System;
using System.Linq;
using System.Threading.Tasks;
using Departments.BLL.Providers.Contracts;
using Departments.DAL.Models.DomainModels;
using Departments.ViewModels;
using Departments.ViewModels.Converters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Departments.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentProvider _departmentProvider;
        public DepartmentController(IDepartmentProvider departmentProvider)
        {
            _departmentProvider = departmentProvider;
        }

        #region GetAllDepartments

        [HttpGet]
        [Route("GetAllDepartments")]
        public async Task<IActionResult> GetAllDepartmentsAsync(int page=1)
        {
            int pageSize = 3;
            try
            {
                var departments =  await _departmentProvider.GetAllDepartmentsAsync();
                var count = departments.Count;
                var items = departments.Skip((page - 1) * pageSize).Take(pageSize).ToList();

                PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
                DepartmentsPageViewModel departmentViewModel = new DepartmentsPageViewModel
                {
                    PageViewModel = pageViewModel,
                    Departments = items
                };

                return Ok(departmentViewModel);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        #endregion

        #region CreateDepartment

        [HttpPost]
        [Route("CreateDepartment")]
        public async Task<IActionResult> CreateDepartment([FromBody]DepartmentViewModel model)
        {
            try
            {
                if (model.Name == null)
                {
                    return BadRequest();
                }

                await _departmentProvider.CreateDepartmentAsync(ViewToData.ConvertDepartment(model));
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

        #region UpdateDepartment

        [HttpPut]
        [Route("UpdateDepartment")]
        public async Task<IActionResult> UpdateDepartment([FromBody]DepartmentViewModel model, int id)
        {
            try
            {
                if (model.Name == null)
                {
                    return BadRequest();
                }

                model.Id = id;
                await _departmentProvider.EditDepartmentAsync(ViewToData.ConvertDepartment(model));
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

        #region DeleteDepartment

        [HttpDelete]
        [Route("DeleteDepartment")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            try
            {
                await _departmentProvider.RemoveDepartmentAsync(id);
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