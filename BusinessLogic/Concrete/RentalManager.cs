using BusinessLogic.Abstract;
using Core.Utilities.Business;
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
    public class RentalManager : IRentalService
    {
        private IRentalDal _rentalDal;
        private ICarDal _carDal;
        private ICustomerDal _customerDal;
        public RentalManager(IRentalDal rentalDal, ICarDal carDal, ICustomerDal customerDal)
        {
            _rentalDal = rentalDal;
            _carDal = carDal;
            _customerDal = customerDal;
        }

        public IResult Add(Rental rental)
        {
           
            IResult result = BusinessRules.Run(CheckFindexPuanIsEnough(rental.CarId,rental.CustomerId), CheckIsAlreadyRented(rental));
            if (result!=null)
            {
                return new ErrorResult();
            }
            var car = _carDal.Get(x => x.Id == rental.CarId);
            var customer = _customerDal.Get(x => x.Id == rental.CustomerId);
            customer.Findeks = customer.Findeks + car.FindeksScore;
            _customerDal.Update(customer);

            rental.RentDate = DateTime.Now;
            _rentalDal.Add(rental);
            return new SuccessResult("Araç başarıyla kiralandı");
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult("Araç başarıyla teslim edildi.");
        }

        public IDataResult<List<Rental>> GetAll()
        {
            _rentalDal.GetAll();
            return new SuccessDataResult<List<Rental>>("Araç başarıyla listelendi");

        }

        public IDataResult<Rental> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Rental rental)
        {
            throw new NotImplementedException();
        }
        public IResult RentalCarControl(int carId)
        {
            var result = _rentalDal.GetAll(r => r.CarId == carId ).Any();
            if (result)
            {
                return new ErrorResult("Araç teslim edilmedi");
            }

            return new SuccessResult();
        }
        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }
        public IResult CheckFindexPuanIsEnough(int carId,int customerId)
        {
            int aracFindeks = _carDal.Get(x => x.Id == carId).FindeksScore;           
           
            int customerFindeks = _customerDal.Get(x => x.Id == customerId).Findeks;
           

            if (customerFindeks < aracFindeks)
            {
                return new ErrorResult("Yetersiz findeks puanı");
            }

            return new SuccessResult();
        }
        private IResult CheckIsAlreadyRented(Rental rental)

        {
            if (rental.ReturnDate == null && _rentalDal.GetRentalDetails(n => n.CarId == rental.CarId).Count > 0)

            {
                return new ErrorResult("Araç şuan kiralanamaz");
            }
            
            return new SuccessResult();
        }
    }
    }
