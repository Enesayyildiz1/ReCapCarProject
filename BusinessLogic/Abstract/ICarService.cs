using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Abstract
{
    public interface ICarService
    {
        IDataResult< List<Car>> GetAll();
        
        IDataResult<Car> GetById (int carId);
        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);
        public IDataResult<List<CarDetailDto>> GetCarDetails();
        IResult TransactionalOperation(Car car);
        IDataResult<List<CarDetailDto>> GetByColorId(int colorId);
        IDataResult<List<CarDetailDto>> GetByBrandId(int brandId);
        IDataResult<List<CarDetailDto>> GetByCarId(int carId);
        IDataResult<List<CarDetailDto>> GetByColorAndBrandId(int colorId, int brandId);
    }
}
