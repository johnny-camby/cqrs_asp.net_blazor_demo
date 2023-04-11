using DataLayer.Entities;
using DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories
{
    public class CustomerRepository : IDataRepository<Customer>
    {
        private readonly MainDbContext _mainDbContext;
        private readonly IDataRepository<FullAddress> _fullAddressRepository;
        public CustomerRepository(MainDbContext mainDbContext, IDataRepository<FullAddress> fullAddressRepository)
        {
            _mainDbContext = mainDbContext;
            _fullAddressRepository = fullAddressRepository;
        }

        public async Task<Customer> AddAsync(Customer entity)
        {
            await _mainDbContext.AddAsync(entity);
            await _mainDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(Customer entity)
        {
            _mainDbContext.Remove(entity);
            await _mainDbContext.SaveChangesAsync();
        }

        public async Task<Customer?> GetByIdAsync(Guid id)
        {
            return await _mainDbContext.Customers.FindAsync(id);
        }

        public async Task<IReadOnlyList<Customer>> ListAllAsync()
        {
            return await _mainDbContext.Customers.Include("FullAddress").ToListAsync();
        }

        public async Task UpdateAsync(Customer entity)
        {
            await _fullAddressRepository.AddAsync(entity.FullAddress);
            _mainDbContext.Entry(entity).State = EntityState.Modified;
            await _mainDbContext.SaveChangesAsync();
        }
    }
}
