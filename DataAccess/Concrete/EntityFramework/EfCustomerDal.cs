using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, ReCapCarDbContext>,ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using (ReCapCarDbContext db = new ReCapCarDbContext())
            {
                var result = from cu in db.Customers
                             join u in db.Users
                             on cu.UserId equals u.Id
                             select new CustomerDetailDto
                             {
                                 Id = cu.Id,
                                 CompanyName = cu.CompanyName,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 Findeks = cu.Findeks,

                             };

                return result.ToList();
            }
        }

        public CustomerDetailDto GetCustomerDetailsById(int customerId)
        {
            using (ReCapCarDbContext db = new ReCapCarDbContext())
            {
                var result = from cu in db.Customers
                             join u in db.Users
                             on cu.UserId equals u.Id
                             where cu.Id == customerId
                             select new CustomerDetailDto
                             {
                                 Id = cu.Id,
                                 CompanyName = cu.CompanyName,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 Findeks = cu.Findeks,

                             };

                return result.SingleOrDefault();
            }
        }

        public CustomerDetailDto GetCustomerDetailsByUserId(int userId)
        {
            using (ReCapCarDbContext db = new ReCapCarDbContext())
            {
                var result = from cu in db.Customers
                             join u in db.Users
                             on cu.UserId equals u.Id
                             where cu.UserId == userId
                             select new CustomerDetailDto
                             {
                                 Id = cu.Id,
                                 CompanyName = cu.CompanyName,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 Findeks = cu.Findeks,

                             };

                return result.SingleOrDefault();
            }
        }
    }
}
