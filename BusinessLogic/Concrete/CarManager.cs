using BusinessLogic.Abstract;
using BusinessLogic.Constants;
using BusinessLogic.ValidationRules.FluentValidation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic.Concrete
{
    public class CarManager : ICarService
    {
        private ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        public IResult Add(Car car)
        {
            CarValidator carValidator = new CarValidator();
            var result = carValidator.Validate(car);
            if (result.Errors.Count > 0)
            {
                return new ErrorResult(Messages.CarNameInvalid);
               // Console.WriteLine(result.Errors.FirstOrDefault().ToString());

            }
             _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
            
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour==19)
            {
                return new ErrorDataResult<List<Car>>("Sistem kapalı");
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),true,"Araçlar Listelendi.");
        }

        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(p => p.Id == carId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public void Update(Car car)
        {
           
            _carDal.Update(car);
        }
    }
}
