﻿using BusinessLogic.Abstract;
using BusinessLogic.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //ICarService carManager = new CarManager(new EfCarDal());
            IBrandService brandManager = new BrandManager(new EfBrandDal());
            IRentalService rentalManager = new RentalManager(new EfRentalDal());
            Rental rental = new Rental()
            {
                CarId = 3,
                CustomerId = 1,
                RentDate = DateTime.Now,
                ReturnDate = new DateTime(2020,5,6),
            };
            var result=rentalManager.Add(rental);
            Console.WriteLine(result.Message);
            




            //Brand brand = new Brand();
            //brand.Name = "BMW";
            //var result=brandManager.Add(brand);
            //Console.WriteLine(result.Message);
            //Console.WriteLine("--------------");
            //var result = carManager.GetAll();
            //if (result.Success)

            //{
            //    foreach (var car in carManager.GetAll().Data)
            //    {
            //        Console.WriteLine(car.Id + " " + car.Name + " ");
            //    }
            //}
            //else
            //{
            //    Console.WriteLine(result.Message);
            //}
           
            Console.ReadLine();
        }
    }
}
