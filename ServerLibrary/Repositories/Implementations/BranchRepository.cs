using BaseLibrary.Entities;
using BaseLibrary.Responses;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;

namespace ServerLibrary.Repositories.Implementations
{
    public class BranchRepository(AppDbContext appDbContext) :IGenericRepositoryInterface<Branch>
    {

        public async Task<GeneralResponse> DeleteById(int id)
        {
            var branch = await appDbContext.Branches.FindAsync(id);
            if (branch is null) return NotFound();

            appDbContext.Branches.Remove(branch);
            await Commit();
            return Success();
        }

        public async Task<List<Branch>> GetAll()
        {
            return await appDbContext
                .Branches.AsNoTracking()
                .Include( d => d.Department ).ToListAsync();
        }

        public async Task<Branch> GetById(int id)
        {
            return await appDbContext.Branches.FindAsync(id);

        }

        public async Task<GeneralResponse> Insert(Branch item)
        {
            if (!await CheckName(item.Name!)) return new GeneralResponse(false, "Branch already added");
            await appDbContext.Branches.AddAsync(item);
            await Commit();
            return Success();
        }

        private async Task<bool> CheckName(string name)
        {
            var nameExist = await appDbContext.Branches.FirstOrDefaultAsync(x => x.Name!.ToLower().Equals(name.ToLower()));
            return nameExist is null;
        }

        public async Task<GeneralResponse> Update(Branch item)
        {
            var branch = await appDbContext.Branches.FindAsync(item.Id);
            if (branch is null) return NotFound();
            branch.Name = item.Name;
            branch.DepartmentId = item.DepartmentId;
            await Commit();
            return Success();
        }

        public static GeneralResponse NotFound() => new(false, "Sorry, Branch not found");
        public static GeneralResponse Success() => new(true, "Sorry, Process Completed");

        private async Task Commit() => await appDbContext.SaveChangesAsync();
    }
}
