using Core.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace DataAccess.Concrete.EntityFramework
{
        public class EfCustomerDal : EfEntityRepositoryBase<Customer, NorthwindContext>, ICustomerDal
        {
            public List<CustomerDetailDto> GetCustomerDetails()
            {
                using (NorthwindContext context = new NorthwindContext())
                {
                var result = from user in context.Users
                             join customer in context.Customers
                             on user.Id equals customer.UserId
                             select new CustomerDetailDto
                             {
                                 CompanyName = customer.CompanyName,
                                 CustomerName = $"{user.FirstName} {user.LastName}"
                             };
                return result.ToList();
                                

                }
            }
        }
    
}
