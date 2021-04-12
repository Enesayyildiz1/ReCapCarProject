using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Abstract
{
    public interface IFakeCardService
    {
        IDataResult<List<FakeCard>> GetByCardNumber(string cardNumber);
        IDataResult<List<FakeCard>> GetAll();
        IDataResult<FakeCard> GetById(int cardId);
        IResult IsCardExist(string cardNumber);
        IResult Add(FakeCard fakeCard);
        IResult Delete(FakeCard fakeCard);
        IResult Update(FakeCard fakeCard);
    }
}
