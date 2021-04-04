using Core.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, NorthwindContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result =
                    from rental in filter == null ? context.Rentals : context.Rentals.Where(filter)
                    join customer in context.Customers
                        on rental.CustomerId equals customer.UserId
                    join user in context.Users
                         on customer.UserId equals user.Id
                    join car in context.Cars
                         on rental.CarId equals car.CarId
                    join brand in context.Brands
                         on car.BrandId equals brand.BrandId
                    join color in context.Colors
                         on car.ColorId equals color.Id
                    select new RentalDetailDto
                    {
                        RentDate = rental.RentDate,
                        ReturnDate = rental.ReturnDate,
                        Id = rental.Id,
                        CarName = brand.Name,
                        ColorName = color.Name,
                        CompanyName = customer.CompanyName,
                        DailyPrice = car.DailyPrice,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        ModelYear = car.ModelYear,
                        CarId=car.CarId,
                        RentEndDate=rental.RentEndDate,
                        CustomerId=customer.UserId,
                        UserName =user.FirstName + user.LastName,
                        BrandName=car.Description
                        
                        
                        
                    };

                return result.ToList();
            }
        }

      
    }

}
    


    
