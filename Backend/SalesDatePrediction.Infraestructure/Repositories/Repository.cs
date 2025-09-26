
using Microsoft.EntityFrameworkCore;
using SalesDatePrediction.Application.Interfaces;
using SalesDatePrediction.Infraestructure.Persistence;
using System.Linq.Expressions;
using System.Threading;


namespace SalesDatePrediction.Infraestructure.Repositories
{
    /// <summary>
    /// Clase de Repositorio Generico con métodos CRUD y consultas de uso frecuente.
    /// </summary>
    /// <typeparam name="TEntity">Entidad relacional. Esta clase debe heredar el contexto genérico.</typeparam>
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        internal readonly ApplicationDbContext _context;
        public Repository(ApplicationDbContext context) => _context = context;

        internal DbSet<TEntity> dbSet => _context.Set<TEntity>();


        public async Task<TEntity?> Delete(int id)
        {
            TEntity? entity = await dbSet.FindAsync(id);
            if (entity != null)
            {
                dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
            return entity;
        }

        public virtual async Task<bool> Exists(Expression<Func<TEntity, bool>> predicate) => await dbSet.AnyAsync(predicate);

        public virtual async Task<int> Counts(Expression<Func<TEntity, bool>> predicate = null)
        {
            if (predicate == null)
                return await dbSet.CountAsync();
            return await dbSet.CountAsync(predicate);
        }

        public async Task<TEntity?> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return await dbSet.AsNoTracking().FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<TEntity>?> FindList(Expression<Func<TEntity, bool>> predicate)
        {
            return await dbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<TEntity?> GetById(long id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<TEntity> Insert(TEntity entity)
        {
            var result = await dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

     
    }
}
