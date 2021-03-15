using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [CacheRemoveAspect("ICarService.Get")]
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
                    
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
          
        }

        [CacheRemoveAspect("ICarService.Get")]
        [SecuredOperation("admin")]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

       
        public IDataResult<List<CarDetailDto>> GetAll()
        {
            if (DateTime.Now.Hour==00)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintenanceTime);
            }

            return new DataResult<List<CarDetailDto>>(_carDal.GetCarDetails(),true,Messages.CarListed);
            
        }


        [CacheAspect]
        [SecuredOperation("admin,user")]
        public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max));
        }

        [CacheAspect]
        [SecuredOperation("admin,user")]
        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId));
        }

        [CacheAspect]
        [SecuredOperation("admin,user")]
        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId));
        }

        
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        [CacheAspect]
        [SecuredOperation("admin,user")]
        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        [CacheAspect]
        [SecuredOperation("admin,user")]
        IDataResult<List<CarDetailDto>> ICarService.GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>> (_carDal.GetCarDetails());
        }

        



    }
}
