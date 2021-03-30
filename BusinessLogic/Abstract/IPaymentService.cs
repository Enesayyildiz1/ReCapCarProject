﻿using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Abstract
{
    public interface IPaymentService
    {
        IResult CardPaymentAdd(CardPayment card);
    }

   
}
