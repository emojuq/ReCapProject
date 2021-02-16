﻿using Core.EntityFramework;
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
                var result = from re in filter is null ? context.Rentals : context.Rentals.Where(filter)
                             join ca in context.Cars
                             on re.CarId equals ca.CarId
                             join cus in context.Customers
                             on re.CustomerId equals cus.UserId
                             join us in context.Users
                             on cus.UserId equals us.Id

                             select new RentalDetailDto
                             {
                                 Id = re.Id,
                                 CustomerName = cus.CompanyName,
                                 CarId = ca.CarId,
                                 RentDate = re.RentDate,
                                 ReturnDate = re.ReturnDate,
                                 UserName = us.FirstName + " " + us.LastName
                                 
                             };


                return result.ToList();
            }


            
        }
    }
}
