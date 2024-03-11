
using BaseLibrary.Entities;
using BaseLibrary.Responses;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;

namespace ServerLibrary.Repositories.Implementations
{
    public class GeneralDepartmentRepository(AppDbContext appDbContext) : IGenericRepositoryInterface<GeneralDepartment>
    {
        public async Task<GeneralResponse> DeleteById(int id)
        {
            var dep = await appDbContext.GeneralDepartments.FindAsync(id);
            if(dep is null) return NotFound();

            appDbContext.GeneralDepartments.Remove(dep);
            await Commit();
            return Success();
        }

        public async Task<List<GeneralDepartment>> GetAll()
        {
            return await appDbContext.GeneralDepartments.ToListAsync();
        }

        public async Task<GeneralDepartment> GetById(int id)
        {
            return await appDbContext.GeneralDepartments.FindAsync(id);
          
        }

        public async Task<GeneralResponse> Insert(GeneralDepartment item)
        {
            var checkIfNull = await CheckName(item.Name!);
            if (!checkIfNull) return new GeneralResponse(false, "General Department already added");
            await appDbContext.GeneralDepartments.AddAsync(item);
            await Commit(); 
            return Success();
        }

        private async Task<bool> CheckName(string name)
        {
            var nameExist = await appDbContext.GeneralDepartments.FirstOrDefaultAsync(x => x.Name!.ToLower().Equals(name.ToLower()));
            return nameExist is null;
        }

        public async Task<GeneralResponse> Update(GeneralDepartment item)
        {
            var dep = await appDbContext.GeneralDepartments.FindAsync(item.Id);
            bool nameExist = await CheckName(item.Name!);
            if (dep is null) return NotFound();

            if (!nameExist) return new GeneralResponse(false, "General Department already exist");
            dep.Name = item.Name;
            await Commit();
            return Success();
        }

        public static GeneralResponse NotFound() => new(false, "Sorry, General Department not found");
        public static GeneralResponse Success() => new(true, "Sorry, Process Completed");

        private async Task Commit() => await appDbContext.SaveChangesAsync();
    }
}
