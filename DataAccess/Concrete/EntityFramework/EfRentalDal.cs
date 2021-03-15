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
                var result = from car in context.Cars
                             join rental in context.Rentals
                             on car.CarId equals rental.CarId
                             join customer in context.Customers
                             on rental.CustomerId equals customer.UserId
                             join user in context.Users
                             on customer.UserId equals user.Id
                             select new RentalDetailDto
                             {
                                 CarName = car.Description,
                                 CustomerName = user.FirstName + " " + user.LastName,
                                 CompanyName = customer.CompanyName,
                                 RentDate = rental.RentDate,
                                 ReturnDate = (DateTime)rental.ReturnDate
                             };
                return result.ToList();

            }


            
        }
    }
}
