using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal :EfEntityRepositoryBase<Rental,ReCapCarDbContext>,IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (ReCapCarDbContext db = new ReCapCarDbContext())
            {
                var result = from p in db.Rentals
                             join c in db.Customers
                             on p.CustomerId equals c.Id
                             join b in db.Cars
                            on  p.CarId equals b.Id
                            select new RentalDetailDto
                             { 
                                RentalId=p.Id,
                                CarId=b.Id,
                                CustomerId=c.Id,
                                CarName=b.Name,
                                CustomerName=c.CompanyName,
                                RentDate=p.RentDate,
                                ReturnDate=p.ReturnDate,


                            };
                return result.ToList();



            }
        }
    }
}
