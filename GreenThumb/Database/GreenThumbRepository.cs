using Microsoft.EntityFrameworkCore;

namespace GreenThumb.Database
{


    internal class GreenThumbRepository<T> where T : class
    {
        private readonly GreenThumbDbContext _context;
        private readonly DbSet<T> _dbSet;
        public GreenThumbRepository(GreenThumbDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public async Task<List<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<T?> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }
        public async Task Add(T entity)
        {
            await _dbSet.AddAsync(entity);
        }
        public async Task Delete(int id)
        {
            T? entityToDelete = await GetById(id);

            if (entityToDelete != null)
            {
                _dbSet.Remove(entityToDelete);
            }
        }
        public async Task Complete()
        {
            await _context.SaveChangesAsync();

        }
    }

}
