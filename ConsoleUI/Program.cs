using Business.Abstract;
using Business.Concrete;
using Business.Constants;
using Core.Utilities.Results;
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

            
            //CarTest();
            //ColorTest();
            //BrandTest();
            
            

        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(new Brand { Name = "BMW" });
            //brandManager.Delete(new Brand { Id = 5 });
            brandManager.Update(new Brand { BrandId = 6, Name = "Mercedes2" });
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.Name);
            }
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Add(new Color { Name = "Yellow" });
            //colorManager.Delete(new Color { Id = 6 });
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.Name);
            }

        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car
            {
                BrandId = 5,
                ColorId = 6,
                DailyPrice = 40000,
                Description = "Tesla",
                ModelYear = "2021",
                CarCategoryId=1
            });
            var result = carManager.GetAll();
            //carManager.Delete(new Car
            //{
            //    CarId = 14
            //});
            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.Description + "/" + car.ModelYear);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            



        }
    }
}

