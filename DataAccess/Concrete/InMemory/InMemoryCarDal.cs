using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>()
            {
               
               new Car{CarId=2, BrandId=2, ColorId=2, DailyPrice=300, ModelYear="2021", Description="BMW İ8"  },
               new Car{CarId=3, BrandId=3, ColorId=3, DailyPrice=80, ModelYear="2009", Description="Renault Symbol"  },
               new Car{CarId=4, BrandId=4, ColorId=4, DailyPrice=90, ModelYear="2010", Description="Honda Civic"  },
               new Car{CarId=5, BrandId=5, ColorId=5, DailyPrice=120, ModelYear="2017", Description="Audi A3"  },
               new Car{CarId=6, BrandId=6, ColorId=6, DailyPrice=100, ModelYear="2011", Description="Peugeot 306"  },
               new Car{CarId=7, BrandId=7, ColorId=7, DailyPrice=70, ModelYear="2008", Description="Ford Focus"  },



            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(car);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAllById(int categoryid)
        {
            return _cars.Where(c => c.CarId == categoryid).ToList();
        }

        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
             carToUpdate = _cars.SingleOrDefault(c => c.ModelYear == car.ModelYear);
             carToUpdate = _cars.SingleOrDefault(c => c.ColorId == car.ColorId);
             carToUpdate = _cars.SingleOrDefault(c => c.DailyPrice == car.DailyPrice);
             carToUpdate = _cars.SingleOrDefault(c => c.Description == car.Description);

        }
    }
}
