using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using CRMRepository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace CRMRepository.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected CRMContext CRMContext { get; set; }
        public RepositoryBase(CRMContext cRMContext)
        {
            this.CRMContext = cRMContext;
        }
        public IQueryable<T> FindAll()
        {
            return this.CRMContext.Set<T>().AsNoTracking();
        }
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.CRMContext.Set<T>().Where(expression).AsNoTracking();
        }
        public T Create(T entity)
        {
            // 
            entity = UpdateGuidFild(entity);
            this.CRMContext.Set<T>().Add(entity);
            this.CRMContext.SaveChanges();
            return entity;
        }

        private static T UpdateGuidFild(T entity)
        {
            foreach (PropertyInfo pro in typeof(T).GetProperties())
            {

                if (pro.PropertyType.Name.ToString() == "Guid")
                {
                    pro.SetValue(entity, Guid.NewGuid(), null);
                }
            }
            return entity;
        }
        
        public T Update(T entity)
        {
            this.CRMContext.Set<T>().Update(entity);
            this.CRMContext.SaveChanges();
            return entity;
        }

        public void Delete(T entity)
        {
            this.CRMContext.Set<T>().Remove(entity);
        }
    }
}