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
            var result = carManager.GetAll();
            if (result.Success)

            {
                foreach (var car in carManager.GetAll().Data)
                {
                    Console.WriteLine(car.Id + " " + car.Name + " ");
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
           
            Console.ReadLine();
        }
    }
}
