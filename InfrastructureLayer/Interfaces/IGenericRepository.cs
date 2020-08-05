using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace InfrastructureLayer.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        /// <summary>
        /// Return all data of an entity
        /// </summary>
        /// <returns>table's data</returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Search an entity for a given primary key.If no entity found return null.
        /// </summary>
        /// <param name="modelId">primary key</param>
        /// <returns></returns>
        T GetById(int modelId);

        /// <summary>
        /// A new entity is added to context. Changes are applied to database when SaveChanges() get called.
        /// </summary>
        /// <param name="model">entity</param>
        void Insert(T model);

        /// <summary>
        /// Remove an entity from the context. Changes are applied to database when SaveChanges() get called.
        /// </summary>
        /// <param name="modelId">primary key</param>
        void Delete(int modelId);

        /// <summary>
        /// Remove an entity from the context. Changes are applied to database when SaveChanges() get called.
        /// </summary>
        /// <param name="model">entity</param>
        void Delete(T model);

        /// <summary>
        /// Update an entity partially to the context and database when SaveChanges() get called.
        /// </summary>
        /// <param name="model"></param>
        /// <returns>updated entity</returns>
        T Update(T model);

        /// <summary>
        /// Find an entity or entities based on an expression
        /// </summary>
        /// <param name="predicate"> expression</param>
        /// <returns>entities</returns>
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
    }
}
