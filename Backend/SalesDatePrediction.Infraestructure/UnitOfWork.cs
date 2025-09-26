using Microsoft.EntityFrameworkCore;
using SalesDatePrediction.Application.Interfaces;
using System.Diagnostics;

namespace SalesDatePrediction.Infraestructure
{
#nullable disable

    /// <summary>
    /// Clase de UnitOfWork para Guamito Dosificado
    /// </summary>
    public class UnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
    {
        /// <summary>
        /// Contexto genérico.
        /// </summary>
        /// 
        private readonly TContext _context;


        /// <summary>
        /// Booleano implementado al liberar el contexto.
        /// </summary>
        private bool _disposed = false;


        //public UnitOfWork(TContext context)
        //{
        //    _context = context;

        //    if (_context == null)
        //        throw new ArgumentException(string.Format(" {0} no fue instanciado ", nameof(_context)));
        //}

        public UnitOfWork(DbContextOptions<TContext> options)
        {
            _context = (TContext)Activator.CreateInstance(typeof(TContext), options);

            if (_context == null)
                throw new ArgumentException(string.Format(" {0} no fue instanciado ", nameof(_context)));
        }

        public T Repository<T>() where T : class
        {
            var result = (T)Activator.CreateInstance(typeof(T), _context);
            return result == null
                 ? throw new ArgumentException($" El repositorio {0} no existe o no está implementado. ")
                 : (T) result;
        }


        /// <summary>
        /// Efectua operación en la base de datos
        /// </summary>
        public async Task Commit()
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (DbUpdateException ex)
            {
                await transaction.RollbackAsync();
                Debug.WriteLine(ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                Debug.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                DetachAll();
            }
        }


        /// <summary>
        /// Separa todas las entidades del contexto que fueron agregadas o modificadas.
        /// </summary>
        private void DetachAll()
        {
            foreach (var dbEntityEntry in _context.ChangeTracker.Entries().ToArray())
            {
                if (dbEntityEntry.Entity != null)
                {
                    dbEntityEntry.State = EntityState.Detached;
                }
            }
        }

        /// <summary>
        /// Desecha el elemento actual.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(obj: this);
        }

        /// <summary>
        /// Desecha todos los recursos externos.
        /// </summary>
        /// <param name="disposing">Indicador del proceso.</param>
        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_context != null)
                    {
                        _context.DisposeAsync();
                        _disposed = true;
                    }
                }
              
                _disposed = true;
            }
        }

    }
}


