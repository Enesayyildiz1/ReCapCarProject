using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(p => p.DailyPrice).GreaterThan(0).WithMessage("Günlük ücret 0 olamaz!");
            RuleFor(p => p.Name.Length).GreaterThan(2).WithMessage("Araba adı uzunluğu 2 karakterde büyük olmalı");
        }
    } 
}
