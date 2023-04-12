
using DataLayer.Entities;
using DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories
{
    public class ShipInfoRepository : IDataRepository<ShipInfo>
    {
        private readonly CqrsDbContext _ctx;

        public ShipInfoRepository(CqrsDbContext ctx) 
        {
            _ctx = ctx;
        }

        public async Task<ShipInfo?> GetByIdAsync(Guid id)
        {
            return await _ctx.ShipInfo.FindAsync(id);
        }

        public async Task<IReadOnlyList<ShipInfo>> ListAllAsync()
        {
            return await _ctx.ShipInfo.ToListAsync();
        }

        public async Task<ShipInfo> AddAsync(ShipInfo entity)
        {
            await _ctx.ShipInfo.AddAsync(entity);
            await _ctx.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(ShipInfo entity)
        {
            _ctx.Entry(entity).State = EntityState.Modified;
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteAsync(ShipInfo entity)
        {
            _ctx.ShipInfo.Remove(entity);
            await _ctx.SaveChangesAsync();
        }        
    }
}
