using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
  public class EfCarDal : ICarDal
    {
        public void Add(Car car)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var AddedEntity = context.Entry(car);
                AddedEntity.State = EntityState.Added;
                context.SaveChanges();
                

            }
        }

        public void Delete(Car car)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var deletedEntity = context.Entry(car);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();

            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (NorthwindContext context= new NorthwindContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);
            }
        }

     
        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (NorthwindContext context=new NorthwindContext())
            {
                return filter == null ? context.Set<Car>().ToList() : context.Set<Car>().Where(filter).ToList();
            }
        }

      

        public void Update(Car car)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var UptatedEntity = context.Entry(car);
                UptatedEntity.State = EntityState.Modified;
                context.SaveChanges();

            }
        }
    }
}
