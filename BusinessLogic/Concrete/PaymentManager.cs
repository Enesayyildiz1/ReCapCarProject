using BusinessLogic.Abstract;
using BusinessLogic.Constants;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Concrete
{
    public class PaymentManager : IPaymentService
    {
        public IResult CardPaymentAdd(CardPayment card)
        {
            return card.Number != "0123456789"
               ? (Result)new ErrorResult(Messages.PaymentError)
               : new SuccessResult(Messages.PaymentSuccess);
        }
    }
}
