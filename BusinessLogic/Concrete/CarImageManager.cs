using BusinessLogic.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using Core.Utilities.Business;
using Core.Utilities.FileHelper;
using System.IO;
using System.Linq;

namespace BusinessLogic.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }


        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckCountOfImage(carImage.CarId));
            if (result != null)
            {
                return result;
            }
            carImage.ImagePath = FileHelper.Add(file);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult();
        }



        public IResult Delete(CarImage carImage)
        {
            IResult result = BusinessRules.Run(CarImageDelete(carImage));
            if (result != null)
            {
                return result;
            }
           // FileHelper.Delete(_carImageDal.Get(p => p.Id == carImage.Id).ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }



        public IDataResult<List<CarImage>> GetAll()
        {


            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetByCarId(int id)
        {

            return new SuccessDataResult<List<CarImage>>(CheckIfCarImageNull(id));
        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(x => x.Id == id));
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            carImage.ImagePath = FileHelper.Update(_carImageDal.Get(p => p.Id == carImage.Id).ImagePath, file);
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }
        private IResult CheckCountOfImage(int carId)
        {
            var imageCount = _carImageDal.GetAll(p => p.CarId == carId).Count;
            if (imageCount >= 5)
            {
                return new ErrorResult("Fotoğraf sayısında limite ulaşıldı.");
            }
            return new SuccessResult();
        }
        private IResult CarImageDelete(CarImage carImage)
        {
            try
            {
                File.Delete(carImage.ImagePath);
            }
            catch (Exception exception)
            {

                return new ErrorResult(exception.Message);
            }

            return new SuccessResult();
        }
        private List<CarImage> CheckIfCarImageNull(int id)
        {

            string path = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).FullName + @"\BusinessLogic\Images\logoo.jfif");
            var result = _carImageDal.GetAll(c => c.CarId == id).Any();
            if (!result)
            {
                return new List<CarImage> { new CarImage { CarId = id, ImagePath = path, Date = DateTime.Now } };
            }
            return _carImageDal.GetAll(p => p.CarId == id);
        }
    }
}
