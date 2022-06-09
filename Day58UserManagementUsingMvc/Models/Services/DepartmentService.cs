using Day58UserManagementUsingMvc.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace Day58UserManagementUsingMvc.Models.Services
{
    public class DepartmentService
    {
        public async Task<List<Department>> GetAllAsync()
        {
            using var context = new ApplicationDbContext();

            var departments =
                from department in context.Departments
                select department;

            return await departments.ToListAsync();
        }

        public async Task<Department> GetByIdAsync(int id)
        {
            using var context = new ApplicationDbContext();

            var deptById =
                from department in context.Departments
                where department.Id == id
                select department;

            return await deptById.SingleOrDefaultAsync();
        }

        public async Task CreateAsync(Department dept)
        {
            using var context = new ApplicationDbContext();

            await context.Departments.AddAsync(dept);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Department dept)
        {
            using var context = new ApplicationDbContext();

            context.Departments.Update(dept);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            using var context = new ApplicationDbContext();

            var deptToDelete = await
                (from dept in context.Departments
                 where dept.Id == id
                 select dept).SingleAsync();

            context.Departments.Remove(deptToDelete);

            await context.SaveChangesAsync();
        }

    }
}
