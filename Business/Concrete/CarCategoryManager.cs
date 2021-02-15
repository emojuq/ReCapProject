using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    class CarCategoryManager:ICategoryService
    {
        ICarCategoryDal _carCategoryDal;
        public CarCategoryManager(ICarCategoryDal carCategoryDal)
        {
            _carCategoryDal = carCategoryDal;
        }

        public List<CarCategory> GetAll()
        {
            return _carCategoryDal.GetAll();
        }

        public CarCategory GetById(int categoryid)
        {
            return _carCategoryDal.Get(c=>c.CarCategoryId==categoryid);
        }

        IDataResult<List<CarCategory>> ICategoryService.GetAll()
        {
            throw new NotImplementedException();
        }

        IDataResult<CarCategory> ICategoryService.GetById(int categoryid)
        {
            throw new NotImplementedException();
        }
    }
}
