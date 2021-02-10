using BusinessLogic.Abstract;
using BusinessLogic.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ICarService carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.Id+" "+car.Name+ " " + car.BrandName+ " " + car.ColorName+ " " + car.ModelYear+ " " + car.DailyPrice+ " " + car.Description);
            }
            Console.ReadLine();
        }
    }
}
