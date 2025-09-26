using System.Linq.Expressions;
using System.Threading;


namespace SalesDatePrediction.Application.Interfaces
{
    /// <summary>
    /// Interface Repositorio Generico con métodos CRUD y consultas de uso frecuente.
    /// </summary>
    /// <typeparam name="TEntity">Entidad relacional.</typeparam>
    public interface IRepository<TEntity> where TEntity : class
    {

        /// <summary>
        /// Obtener objeto de la entidad de manera asincrónica por su id.
        /// </summary>
        /// <param name="id"> Id del registro de la entidad.</param>
        /// <returns>Objeto de la entidad si se encuentra, y nulo en caso contrario.</returns>
        Task<TEntity?> GetById(long id);

        /// <summary>
        /// Listado de los elementos que conforman una entidad.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetAll();

        /// <summary>
        /// Comprueba si existe una entidad que coincide con <paramref name="predicate"/>
        /// </summary>
        /// <param name="predicate">El predicado por el que se validará existencia.</param>
        /// <returns>Booleano si existe una entidad que coincida con <paramref name="predicate"/></returns>
        Task<bool> Exists(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Conteo de registros filtrados opcionalmente por <paramref name="predicate"/>
        /// </summary>
        /// <param name="predicate">El predicado por el que se filtrarán los registros.</param>
        /// <returns>Contador para los registros coincidentes <paramref name="predicate"/></returns>
        Task<int> Counts(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Insertar un nuevo objeto de entidad.
        /// </summary>
        /// <param name="entity"> Objeto a insertar. </param>
        /// <returns>  Resultado de la operación. </returns>
        Task<TEntity> Insert(TEntity entity);

        /// <summary>
        /// Eliminar objeto de la entidad.
        /// </summary>
        /// <param name="id"> Id del registro de la entidad.</param>
        /// <returns> Boleano del resultado de la operación. </returns>
        Task<TEntity?> Delete(int id);

        /// <summary>
        /// Modificar un objeto de entidad.
        /// </summary>
        /// <param name="entity"> Objeto a modificar. </param>
        /// <returns> Resultado de la operación. </returns>
        Task Update(TEntity entity);

        /// <summary>
        /// Buscar en una entidad.
        /// </summary>
        /// <param name="predicate"> Función para filtar cada objeto respecto a una condición. </param>
        /// <returns> Listado de objetos de la entidad que satisfacen la función evalauda.</returns>
        Task<TEntity?> Find(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Listado filtrado de una entidad.
        /// </summary>
        /// <param name="predicate"> Función para filtar cada objeto respecto a una condición. </param>
        /// <returns> Listado de objetos de la entidad que satisfacen la función evalauda.</returns>
        Task<IEnumerable<TEntity>?> FindList(Expression<Func<TEntity, bool>> predicate);
    }
}
