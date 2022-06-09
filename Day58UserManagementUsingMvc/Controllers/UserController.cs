using Day58UserManagementUsingMvc.Models;
using Day58UserManagementUsingMvc.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace Day58UserManagementUsingMvc.Controllers
{
    public class UserController : Controller
    {
        public async Task<IActionResult> IndexAsync()
        {
            var userService = new UserService();
            var users = await userService.GetAllAsync();

            return View(users);
        }

        public async Task<IActionResult> DatailsAsync(int id)
        {
            var userService = new UserService();
            var user = await userService.GetByIdAsync(id);
            
            return View(user);
        }

        [HttpGet] //By default it is get method
        public IActionResult Create()
        {
            var user = Utility.GenerateFakeData();

            return View(user);
        }

        [HttpPost] // when we want to use post method , must include HttpPost
        public async Task<IActionResult> Create(User user)
        {
            var userService = new UserService();
            await userService.CreateAsync(user);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var userService = new UserService();
            var user = await userService.GetByIdAsync(id);

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Update(User user)
        {
            var userService = new UserService();
            await userService.UpdateAsync(user);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var userService = new UserService();
            var user = await userService.GetByIdAsync(id);

            return View(user);
        }

        public async Task<IActionResult> DeleteUser(int id)
        {
            var userService = new UserService();
            await userService.DeleteAsync(id);

            return RedirectToAction("Index");
        }
    }
}
