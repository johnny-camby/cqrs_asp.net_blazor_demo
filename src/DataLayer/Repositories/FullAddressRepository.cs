using DataLayer.Entities;
using DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories
{
    public class FullAddressRepository : IDataRepository<FullAddress>
    {
        private readonly CqrsDbContext _mainDbContext;

        public FullAddressRepository(CqrsDbContext mainDbContext)
        {
            _mainDbContext = mainDbContext;
        }

        public async Task<FullAddress> AddAsync(FullAddress entity)
        {
            _mainDbContext.FullAddresses.Add(entity);
            _mainDbContext.SaveChanges();
            return entity;
        }

        public async Task DeleteAsync(FullAddress entity)
        {
            _mainDbContext.Remove(entity);
            await _mainDbContext.SaveChangesAsync();
        }

        public async Task<FullAddress?> GetByIdAsync(Guid id)
        {
            return await _mainDbContext.FullAddresses.FindAsync(id);
        }

        public async Task<IReadOnlyList<FullAddress>> ListAllAsync()
        {
            return await _mainDbContext.FullAddresses.ToListAsync();
        }

        public async Task UpdateAsync(FullAddress entity)
        {
            _mainDbContext.Entry(entity).State = EntityState.Modified;
            //_mainDbContext.Update(entity);
            await _mainDbContext.SaveChangesAsync();
        }
    }
}
