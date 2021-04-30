using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
using Entities.Dtos;

namespace BusinessLogic.Abstract
{

    public interface IUserService
    {
        IDataResult<List<OperationClaim>> GetClaims(User user);
        User GetByMail(string email);

        IDataResult<List<User>> GetAll();
        IDataResult<User> GetByUserId(int id);
        IDataResult<User> GetByEmail(string email);

        IResult Add(User user);
        IResult Delete(User user);
        IResult Update(User user);
        IResult EditProfile(UserUpdateDto user);
        IDataResult<OperationClaim> GetClaimById(int userId);
    }
}
