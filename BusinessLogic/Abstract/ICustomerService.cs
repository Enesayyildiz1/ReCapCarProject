using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Abstract
{
    public interface ICustomerService
    {
        IDataResult<List<Customer>> GetAll();
        IDataResult<Customer> GetById(int id);
        IDataResult<Customer> GetByUserId(int userId);
        IDataResult<Customer> GetByEmail(string email);
        IResult Add(Customer customer);

        IResult Delete(Customer customer);
        IResult Update(Customer customer);
    }
}
