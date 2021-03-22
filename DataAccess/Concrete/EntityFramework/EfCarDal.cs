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
    public class EfCarDal : EfEntityRepositoryBase<Car, NorthwindContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from car in context.Cars
                             join color in context.Colors on car.ColorId equals color.Id
                             join brand in context.Brands on car.BrandId equals brand.BrandId
                             join carImage in context.CarImages on car.CarId equals carImage.CarId
                             select new CarDetailDto()
                             {
                                 CarId = car.CarId,
                                 ImagePath = carImage.ImagePath,
                                 Description = car.Description,
                                 BrandId = brand.BrandId,
                                 BrandName = brand.Name,
                                 CarImageDate = carImage.Date,
                                 ColorId = color.Id,
                                 ColorName = color.Name,
                                 DailyPrice = car.DailyPrice,
                                 CarName = car.Description,
                                 ModelYear=car.ModelYear

                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();

            }
        }
    }
}
