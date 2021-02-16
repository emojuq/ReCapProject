using Core.DataAccess;
using Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.EntityFramework
{
   public class EfEntityRepositoryBase<TEntity,TContext>:IEntityRepository<TEntity> where TEntity:class,IEntity,new() where TContext:DbContext,new()
    {
       public void Add(TEntity car)
        {
            using (TContext context = new TContext())
            {
               var AddedEntity = context.Entry(car);
               AddedEntity.State = EntityState.Added;
                context.SaveChanges();


            }
        }

        public void Delete(TEntity car)
        {
            using (TContext context = new TContext())
            {

                var deletedEntity = context.Entry(car);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();

            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }


        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
            }
        }



        public void Update(TEntity car)
        {
            using (TContext context = new TContext())
            {
                var UptatedEntity = context.Entry(car);
                UptatedEntity.State = EntityState.Modified;
                context.SaveChanges();

            }
        }
    }
}
