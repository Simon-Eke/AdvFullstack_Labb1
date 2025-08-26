using AdvFullstack_Labb1.Data;
using AdvFullstack_Labb1.Models.Entities;
using AdvFullstack_Labb1.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace AdvFullstack_Labb1.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly MyCafeLabb1Context _context;
        protected readonly DbSet<T> _dbSet;

        public Repository(MyCafeLabb1Context context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }
        public async Task<int> CreateAsync(T entity)
        {
            _dbSet.Add(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }
        public async Task<bool> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null)
                return false;

            _dbSet.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
