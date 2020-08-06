using InfrastructureLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace InfrastructureLayer.Implementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        #region Private Field

        private readonly DbContext _dataContext;

        #endregion

        #region Constructor

        public GenericRepository(DbContext dataContext)
        {
            _dataContext = dataContext;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Remove an entity from the context. Changes are applied to database when SaveChanges() get called.
        /// </summary>
        /// <param name="modelId">primary key</param>
        public virtual void Delete(int modelId)
        {
            T model = _dataContext.Set<T>().Find(modelId);
            _dataContext.Set<T>().Remove(model);
        }

        /// <summary>
        /// Remove an entity from the context. Changes are applied to database when SaveChanges() get called.
        /// </summary>
        /// <param name="model"> entity</param>
        public virtual void Delete(T model)
        {
            _dataContext.Set<T>().Remove(model);
        }
        /// <summary>
        /// Return all data of an entity
        /// </summary>
        /// <returns>table's data</returns>
        public virtual IEnumerable<T> GetAll()
        {
            return _dataContext.Set<T>();
        }

        /// <summary>
        /// Search an entity for a given primary key.If no entity found return null.
        /// </summary>
        /// <param name="modelId">primary key</param>
        /// <returns></returns>
        public virtual T GetById(int modelId)
        {
            return _dataContext.Set<T>().Find(modelId);
        }

        /// <summary>
        /// A new entity is added to context. Changes are applied to database when SaveChanges() get called.
        /// </summary>
        /// <param name="model">entity</param>
        public virtual void Insert(T model)
        {
            _dataContext.Set<T>().Add(model);
        }

        /// <summary>
        /// Update an entity partially to the context and database when SaveChanges() get called.
        /// </summary>
        /// <param name="model"></param>
        /// <returns>updated entity</returns>
        public virtual T Update(T model)
        {
            _dataContext.Entry(model).State = EntityState.Modified;
            return model;
        }

        /// <summary>
        /// Find an entity or entities based on an expression
        /// </summary>
        /// <param name="predicate"> expression</param>
        /// <returns>entities</returns>
        public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            var a = _dataContext.Set<T>().Where(predicate).AsQueryable();
            return a;
        }

        /// <summary>
        /// Find an entity or entities and related entities based on an expression.
        /// </summary>
        /// <param name="predicate">expression</param>
        /// <param name="includeRelations">entities</param>
        /// <returns>entities</returns>
        public virtual IQueryable<T> FindBy(Func<T, bool> predicate, string[] includeRelations)
        {
            var query = _dataContext.Set<T>().Where(predicate).AsQueryable();
            foreach (string relation in includeRelations)
            {
                query.Include(relation);
            }
            return query;
        }

        #endregion

    }
}
