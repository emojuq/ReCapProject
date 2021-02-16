using Core.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
  public class EfCarDal :EfEntityRepositoryBase<Car,NorthwindContext>,ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (NorthwindContext context= new NorthwindContext())
            {
                var result = from c in context.Cars
                             join b in context.Colors

                             on c.ColorId equals b.Id
                             join br in context.Brands
                             on c.BrandId equals br.BrandId
                             select new CarDetailDto
                             {
                                 CarId = c.CarId,
                                 BrandName = br.Name,
                                 ColorName = b.Name,
                                 CarName=c.Description
                             };

                return result.ToList();
            }
        }
    }
}
