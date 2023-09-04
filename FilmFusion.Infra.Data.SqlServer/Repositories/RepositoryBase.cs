using FilmFusion.Domain.Repositories;
using FilmFusion.Infra.Data.SqlServer.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FilmFusion.Infra.Data.SqlServer.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly ApplicationSqlServerDbContext _db;
        private readonly DbSet<TEntity> _dbSet;

        public RepositoryBase(ApplicationSqlServerDbContext db)
        {
            _db = db;
            _dbSet = _db.Set<TEntity>();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            var result = await _dbSet.AddAsync(entity);
            _db.Entry(entity).State = EntityState.Added;
            return result.Entity;
        }

        public void DeleteAsync(TEntity entity)
            => _dbSet.Remove(entity);

        public async Task<IQueryable<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[] includes)
            => await Task.Run(() => includes.Aggregate(_dbSet.AsQueryable(), (current, include) => current.Include(include)));

        public async Task<IEnumerable<TEntity>> GetAllAsync()
            => await _dbSet.ToListAsync();

        public async Task<IEnumerable<TEntity>> GetAsync(int limit)
            => await _dbSet.Take(limit).ToListAsync();

        public async Task<TEntity?> GetByIdAsync(Guid id)
            => await _dbSet.FindAsync(id);

        public async Task<TEntity?> Exists(Expression<Func<TEntity, bool>> predicate)
            => await _dbSet.FirstOrDefaultAsync(predicate);

        public async Task<TEntity?> GetByIdAsync(Guid id, params Expression<Func<TEntity, object>>[] includes)
        {
            var model = await _dbSet.FindAsync(id);
            foreach (var item in includes)
            {
                _db.Entry(model).Reference(item).Load();
            }
            return model;
        }

        public async Task<int> SaveChangesAsync()
            => await _db.SaveChangesAsync();

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var result = await Task.Run(() => _db.Update(entity));
            _db.Entry(entity).State = EntityState.Modified;
            return result.Entity;
        }
    }
}
