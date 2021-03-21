using BusinessLogic.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Concrete
{
    public class RentalManager : IRentalService
    {
        private IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {

            if (rental.ReturnDate == null && _rentalDal.GetRentalDetails(n => n.CarId == rental.CarId).Count > 0)

            {
                return new ErrorResult("Araç şuan kiralanamaz");
            }
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
            throw new NotImplementedException();
        }

        public IDataResult<Rental> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Rental rental)
        {
            throw new NotImplementedException();
        }
        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }
    }
    }
