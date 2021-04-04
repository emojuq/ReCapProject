using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.BusinessRules;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

       
        public IResult Add(Rental rental)
        {
            var result = BusinessRules.Run(CheckCarAvailable(rental.CarId));
            if (result!=null)
            {
                return result;
            }
            _rentalDal.Add(rental);

            return new SuccessResult(Messages.RentalAdded);        
            
        }


       
        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

       
        public IDataResult<List<Rental>> GetAll()
        {
            return new DataResult<List<Rental>>(_rentalDal.GetAll(),true,Messages.RentalListed);
        }

        
        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r=>r.Id==id));
        }

        public IResult GetRentalDetailsById(int id)
        {
            var result = _rentalDal.GetAll(r => r.CarId == id && r.ReturnDate == null).Any();

            if (result)
            {
                return new ErrorResult("Hata");
            }

            return new SuccessResult();

        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetailsDto()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }



        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }

       

        private IResult CheckCarAvailable(int carId)
        {
            if(_rentalDal.Get(r=>r.CarId==carId && r.ReturnDate==null) != null)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
    }

   
}
