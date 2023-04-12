using DataLayer.Entities;
using DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories
{
    public class OrderRepository : IDataRepository<Order>
    {
        private readonly CqrsDbContext _ctx;
        public OrderRepository(CqrsDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Order?> GetByIdAsync(Guid id)
        {
            return await _ctx.Orders.FindAsync(id);
        }

        public async Task<IReadOnlyList<Order>> ListAllAsync()
        {
            return await _ctx.Orders.Include("ShipInfo").ToListAsync();
        }

        public async Task<Order> AddAsync(Order entity)
        {
            await _ctx.Orders.AddAsync(entity);
            await _ctx.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(Order entity)
        {
            await _ctx.ShipInfo.AddAsync(entity.ShipInfo);
            _ctx.Entry(entity).State = EntityState.Modified;
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteAsync(Order entity)
        {
            _ctx.Remove(entity);
            await _ctx.SaveChangesAsync();
        }
    }
}
