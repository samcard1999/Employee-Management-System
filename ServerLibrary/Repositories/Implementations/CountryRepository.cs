﻿using BaseLibrary.Entities;
using BaseLibrary.Responses;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;

namespace ServerLibrary.Repositories.Implementations
{
    public class CountryRepository(AppDbContext appDbContext): IGenericRepositoryInterface<Country>
    {

        public async Task<GeneralResponse> DeleteById(int id)
        {
            var country = await appDbContext.Countries.FindAsync(id);
            if (country is null) return NotFound();

            appDbContext.Countries.Remove(country);
            await Commit();
            return Success();
        }

        public async Task<List<Country>> GetAll()
        {
            return await appDbContext.Countries.ToListAsync();
        }

        public async Task<Country> GetById(int id)
        {
            return await appDbContext.Countries.FindAsync(id);

        }

        public async Task<GeneralResponse> Insert(Country item)
        {
            if (!await CheckName(item.Name!)) return new GeneralResponse(false, "Country already added");
            await appDbContext.Countries.AddAsync(item);
            await Commit();
            return Success();
        }

        private async Task<bool> CheckName(string name)
        {
            var nameExist = await appDbContext.Countries.FirstOrDefaultAsync(x => x.Name!.ToLower().Equals(name.ToLower()));
            return nameExist is null;
        }

        public async Task<GeneralResponse> Update(Country item)
        {
            var country = await appDbContext.Countries.FindAsync(item.Id);
            if (country is null) return NotFound();
            country.Name = item.Name;
            await Commit();
            return Success();
        }

        public static GeneralResponse NotFound() => new(false, "Sorry, Country not found");
        public static GeneralResponse Success() => new(true, "Sorry, Process Completed");

        private async Task Commit() => await appDbContext.SaveChangesAsync();
    }
}
