using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ICarService carService = new CarManager(new EfCarDal());
            carService.Add(new Car
            {
                
                BrandId = 1,
                ColorId = 1,
                DailyPrice = 500,
                Description = "Araba",          
                ModelYear = "2019"
            });

            foreach (var car in carService.GetCarsByBrandId(1))
            {
                Console.WriteLine("Ürünün Adı" + " " + car.Description + " " + " Ürünün günlük fiyatı:" + " " + car.DailyPrice  + " " + " Ürünün üretim yılı:" + " " + car.ModelYear);
            }

        }
    } }

