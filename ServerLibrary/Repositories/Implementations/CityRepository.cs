using BaseLibrary.Entities;
using BaseLibrary.Responses;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;


namespace ServerLibrary.Repositories.Implementations
{
    public class CityRepository(AppDbContext appDbContext): IGenericRepositoryInterface<City>
    {

        public async Task<GeneralResponse> DeleteById(int id)
        {
            var city = await appDbContext.Cities.FindAsync(id);
            if (city is null) return NotFound();

            appDbContext.Cities.Remove(city);
            await Commit();
            return Success();
        }

        public async Task<List<City>> GetAll()
        {
            return await appDbContext
                .Cities
                .AsNoTracking()
                .Include(c=>c.Country)
                .ToListAsync();
        }

        public async Task<City> GetById(int id)
        {
            return (await appDbContext.Cities.FindAsync(id))!;

        }

        public async Task<GeneralResponse> Insert(City item)
        {
            if (!await CheckName(item.Name!)) return new GeneralResponse(false, "City already added");
            await appDbContext.Cities.AddAsync(item);
            await Commit();
            return Success();
        }

        private async Task<bool> CheckName(string name)
        {
            var nameExist = await appDbContext.Cities.FirstOrDefaultAsync(x => x.Name!.ToLower().Equals(name.ToLower()));
            return nameExist is null;
        }

        public async Task<GeneralResponse> Update(City item)
        {
            var city = await appDbContext.Cities.FindAsync(item.Id);
            if (city is null) return NotFound();
            city.Name = item.Name;
            city.CountryId = item.CountryId;
            await Commit();
            return Success();
        }

        public static GeneralResponse NotFound() => new(false, "Sorry, City not found");
        public static GeneralResponse Success() => new(true, "Sorry, Process Completed");

        private async Task Commit() => await appDbContext.SaveChangesAsync();
    }
}
