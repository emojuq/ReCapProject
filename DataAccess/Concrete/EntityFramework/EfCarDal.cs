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
        public List<CarDetailDto> GetCarDetailsById(int carId)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = (from p in context.Cars
                             join c in context.Colors
                             on p.ColorId equals c.Id
                             join d in context.Brands
                             on p.BrandId equals d.BrandId
                             select new CarDetailDto
                             {
                                 BrandId=d.BrandId,
                                 ColorId=c.Id,
                                 CarName=p.Description,
                                 BrandName = d.Name,
                                 ColorName = c.Name,
                                 DailyPrice = p.DailyPrice,
                                 ModelYear = p.ModelYear,
                                 Id = p.CarId,
                                 Status = !context.Rentals.Any(p => p.CarId == carId && p.ReturnDate == null)
                             }).ToList();

                 return result.ToList();
            }
        }









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
                                 Id = car.CarId,
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
