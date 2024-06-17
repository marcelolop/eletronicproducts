using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Dependency_Interfaces
{
    public interface IGenericCRUDRepository<T> where T : class
    {
        /// <summary>
        /// Get all entities of type T
        /// </summary>
        /// <returns> List of all entities</returns>
        Task<List<T>> GetAllEntitiesAsync();

        /// <summary>
        /// Get entity of type T by Id
        /// </summary>
        /// <param name="id"> Entity Id</param>
        /// <returns> Entity</returns>
        Task<T> GetEntityByIdAsync(int id);

        /// <summary>
        /// Add entity of type T
        /// </summary>
        /// <param name="entity"> Entity</param>
        /// <returns> Entity</returns>
        Task<T> AddEntityAsync(T entity);

        /// <summary>
        /// Update entity of type T
        /// </summary>
        /// <param name="entity"> Entity</param>
        /// <returns> Entity</returns>
        Task<T> UpdateEntityAsync(T entity);

        /// <summary>
        /// Delete entity of type T by Id
        /// </summary>
        /// <param name="id"> Entity Id</param>
        /// <returns> Entity</returns>
        Task<T> DeleteEntityAsync(int id);
    }
}
