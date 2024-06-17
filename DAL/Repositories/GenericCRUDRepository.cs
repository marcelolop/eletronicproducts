using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Dependency_Interfaces;
using Microsoft.EntityFrameworkCore;
using Entities.Dependency_Interfaces;

namespace DAL.Repositories
{
    public class GenericCRUDRepository<T> : IGenericCRUDRepository<T> where T : class
    {
        private readonly IProductSystemContext _context;
        private DbSet<T> _entities;

        public GenericCRUDRepository(IProductSystemContext context)
        {
            _context = context;
            _entities = _context.Set<T>();
        }


        public async Task<T> AddEntityAsync(T entity)
        {
            try
            {
                await _entities.AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException($"Couldn't add entity: {ex.Message}");
            }   
        }

        public async Task<T> DeleteEntityAsync(int id)
        {
           var entity = await _entities.FindAsync(id);
            if (entity == null)
            {
                throw new InvalidOperationException("Entity not found");
            }

            try
            {
                _entities.Remove(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException($"Couldn't delete entity: {ex.Message}");
            }
        }

        /// <summary>
        /// Get all entities of type T
        /// </summary>
        /// <returns> List of all entities</returns>
        /// <exception cref="InvalidOperationException"> Throws exception if couldn't retrieve entities</exception>
        public async Task<List<T>> GetAllEntitiesAsync()
        {
            try
            {
                return await _entities.ToListAsync();
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException($"Couldn't get all entities: {ex.Message}");
            }
        }

        /// <summary>
        /// Get entity of type T by Id
        /// </summary>
        /// <param name="id"> Entity Id</param>
        /// <returns> Entity</returns>
        /// <exception cref="InvalidOperationException"> Throws exception if couldn't retrieve entity</exception>
        public async Task<T> GetEntityByIdAsync(int id)
        {
            try
            {
                return await _entities.FindAsync(id);
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException($"Couldn't get entity by Id: {ex.Message}");
            }
        }
        /// <summary>
        /// Update entity of type T
        /// </summary>
        /// <param name="entity"> Entity</param>
        /// <returns> Entity</returns>
        /// <exception cref="ArgumentNullException"> Throws exception if entity is null</exception>
        /// <exception cref="InvalidOperationException"> Throws exception if couldn't update entity</exception>
        public Task<T> UpdateEntityAsync(T entity)
        {
           if (entity == null)
            {
                throw new ArgumentNullException("Entity is null");
            }

            try
            {
                _entities.Update(entity);
                _context.SaveChangesAsync();
                return Task.FromResult(entity);
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException($"Couldn't update entity: {ex.Message}");
            }
        }   
    }
}
