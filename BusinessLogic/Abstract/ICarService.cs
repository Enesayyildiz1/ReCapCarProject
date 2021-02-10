using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
       
        void Add(Car car);
        void Delete(Car car);
        void Update(Car car);
        public List<CarDetailDto> GetCarDetails();
    }
}
