using Day58UserManagementUsingMvc.Models;
using Day58UserManagementUsingMvc.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace Day58UserManagementUsingMvc.Controllers
{
    public class DepartmentController : Controller
    {
        public async Task<IActionResult> IndexAsync()
        {
            var departmentService = new DepartmentService();
            var departments = await departmentService.GetAllAsync();

            return View(departments);
        }

        public async Task<IActionResult> DatailsAsync(int id)
        {
            var departmentService = new DepartmentService();
            var department = await departmentService.GetByIdAsync(id);

            return View(department);
        }

        [HttpGet] //By default it is get method
        public IActionResult Create()
        {
            var department = Utility.GenerateFakeDataForDept();

            return View(department);
        }

        [HttpPost] // when we want to use post method , must include HttpPost
        public async Task<IActionResult> Create(Department department)
        {
            var departmentService = new DepartmentService();
            await departmentService.CreateAsync(department);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var departmentService = new DepartmentService();
            var department = await departmentService.GetByIdAsync(id);

            return View(department);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Department department)
        {
            var departmentService = new DepartmentService();
            await departmentService.UpdateAsync(department);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var departmentService = new DepartmentService();
            var department = await departmentService.GetByIdAsync(id);

            return View(department);
        }
             
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var departmentService = new DepartmentService();
            await departmentService.DeleteAsync(id);

            return RedirectToAction("Index");
        }

    }
}
