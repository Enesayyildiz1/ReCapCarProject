using BusinessLogic.Abstract;
using BusinessLogic.BusinessAspects.Autofac;
using BusinessLogic.Constants;
using BusinessLogic.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transcation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BusinessLogic.Concrete
{
    public class CarManager : ICarService
    {
        private ICarDal _carDal;
       // private IBrandService _brandService;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
           
        }





       [SecuredOperation("admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.GetAll")]
        public IResult Add(Car car)
        {
            IResult result = BusinessRules.Run(CheckIfCarCountOfBrandCorrect(car.BrandId), NotAddedSameCarsName(car.Name));



            if (result != null)
            {
                return new ErrorResult();


            }

            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);



        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult("Araç silindi.");
        }
       // [CacheAspect]
        //[PerformanceScopeAspect(1)]
        
        public IDataResult<List<Car>> GetAll()
        {Thread.Sleep(2000);
            if (DateTime.Now.Hour == 11)
            {
                return new ErrorDataResult<List<Car>>("Sistem kapalı");
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), true, "Araçlar Listelendi.");
        }

        public IDataResult<List<CarDetailDto>> GetByBrandId(int brandId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(p => p.BrandId == brandId));
        }

        public IDataResult<List<CarDetailDto>> GetByCarId(int carId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(p => p.Id == carId));
        }

        public IDataResult<List<CarDetailDto>> GetByColorAndBrandId(int colorId, int brandId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(p => p.BrandId == brandId&&p.ColorId==colorId));
        }

        public IDataResult<List<CarDetailDto>> GetByColorId(int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(p => p.ColorId == colorId));
        }

        [CacheAspect]
        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(p => p.Id == carId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }
        [TransactionScopeAspect]
        public IResult TransactionalOperation(Car car)
        {
            Add(car);
            if (car.DailyPrice<100)
            {
                throw new Exception();
            }
            Add(car);
            return null;
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult("Araç başarıyla güncellendi.");
        }
        private IResult CheckIfCarCountOfBrandCorrect(int brandid)
        {
            var eklenmekistenenmarkadakiaracsayisi = _carDal.GetAll(p => p.BrandId == brandid).ToList();
            if (eklenmekistenenmarkadakiaracsayisi.Count >= 10)
            {
                return new ErrorResult("Hata");
            }
            return new SuccessResult();
        }

      

        private IResult NotAddedSameCarsName(string carname)
        {
            var ayniisim = _carDal.GetAll(p => p.Name == carname).ToList();
            if (ayniisim.Count > 0)
            {
                return new ErrorResult("Ayni isimde farklı bir araç tespit edildi");
            }
            return new SuccessResult();
        }
        //private IResult CheckBrandCountInDatabase()
        //{
        //    var markasayisi = _brandService.GetAll().Data.Count();
        //    if (markasayisi > 15)
        //    {
        //        return new ErrorResult("Marka sayısı 15 den fazla olduğu için araç eklenemedi");
        //    }
        //    return new SuccessResult();
        //}
    }
}
