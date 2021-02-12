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
        void Delete(Car car);
        void Update(Car car);
        public IDataResult<List<CarDetailDto>> GetCarDetails();
    }
}
