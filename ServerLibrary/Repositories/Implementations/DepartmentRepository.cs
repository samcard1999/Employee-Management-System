using BaseLibrary.Entities;
using BaseLibrary.Responses;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;

namespace ServerLibrary.Repositories.Implementations
{
    public class DepartmentRepository(AppDbContext appDbContext) : IGenericRepositoryInterface<Department>
    {
        
            public async Task<GeneralResponse> DeleteById(int id)
            {
                var dep = await appDbContext.Departments.FindAsync(id);
                if (dep is null) return NotFound();

                appDbContext.Departments.Remove(dep);
                await Commit();
                return Success();
            }

            public async Task<List<Department>> GetAll()
            {
                return await appDbContext
                .Departments.AsNoTracking()
                .Include(gd => gd.GeneralDepartment)
                .ToListAsync();
            }

            public async Task<Department> GetById(int id)
            {
                return await appDbContext.Departments.FindAsync(id);

            }

            public async Task<GeneralResponse> Insert(Department item)
            {
                if (!await CheckName(item.Name!)) return new GeneralResponse(false, "Department already added");
                await appDbContext.Departments.AddAsync(item);
                await Commit();
                return Success();
            }

            private async Task<bool> CheckName(string name)
            {
                var nameExist = await appDbContext.Departments.FirstOrDefaultAsync(x => x.Name!.ToLower().Equals(name.ToLower()));
                return nameExist is null;
            }

            public async Task<GeneralResponse> Update(Department item)
            {
                var dep = await appDbContext.Departments.FindAsync(item.Id);
                if (dep is null) return NotFound();
                dep.Name = item.Name;
                dep.GeneralDepartmentId = item.GeneralDepartmentId;
                await Commit();
                return Success();
            }

            public static GeneralResponse NotFound() => new(false, "Sorry, Department not found");
            public static GeneralResponse Success() => new(true, "Sorry, Process Completed");

            private async Task Commit() => await appDbContext.SaveChangesAsync();
        }
    }

