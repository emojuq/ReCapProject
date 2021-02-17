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
            //BrandAddTest();
            //UserAddTest();
            //RentList();
            //AddRentTest(); //bir şey dönmedi
            //RentUpdateTest();
            //CarDetailsTest();
            //UpdateTest();
            //BrandDeleteTest();
            //RentDetailsTest();
            //GetCarsByBrandIdTest();
            //ColorGetByIdTest();




        }

        private static void AddRentTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result= rentalManager.Add(new Rental {Id=6 , CarId=5 ,CustomerId=5,  RentDate = new DateTime(2021,02,10) });
            Console.WriteLine(result.Message);
            
        }

        private static void RentDetailsTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.GetRentalDetailsDto();
            if (result.Success == true)
            {
                foreach (var rent in result.Data)
                {
                    Console.WriteLine("CustomerName:{0} - CarName:{1} - CompanyName:{2} - RentDate:{3} - ReturnDate:{4}",
                        rent.CustomerName, rent.CarName," " + rent.CustomerName," " + rent.RentDate," " + rent.ReturnDate);
                }
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void RentList()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.GetAll();
            if (result.Success)
            {
                foreach (var rent in result.Data)
                {
                    Console.WriteLine("CarId: {0} -  CustomerId: {1} - Id: {2} - RentDate: {3} - ReturnDate: {4}",
                        rent.CarId, rent.CustomerId, rent.Id, rent.RentDate, rent.ReturnDate);
                }
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void RentUpdateTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.Update(new Rental
            {
                Id = 1,
                CarId = 4,
                CustomerId = 1,
                RentDate = new DateTime(2021, 02, 14),
                ReturnDate = null,
            });
            Console.WriteLine(result.Message);
        }

        
        private static void UserAddTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            var result = userManager.Add(new User {Id=6 ,FirstName = "Yunus", LastName = "Can", EMail = "xxx", Password = "*****" });
            Console.WriteLine(result.Message);
        }

        private static void UpdateTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Update(new Car { BrandId = 6, ColorId = 6, DailyPrice = 300000, Description = "AUDİ", CarId = 5, ModelYear = "2021", });
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Update(new Brand { Name = "BMW", BrandId = 5 });
        }

        private static void BrandDeleteTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Delete(new Brand {  BrandId = 1006 });
        }

        private static void BrandAddTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(new Brand { Name = "Citroen",BrandId=6 });
        }

        private static void ColorGetByIdTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            var search_color = colorManager.GetColorsByBrandId(6).Data;
            Console.WriteLine(search_color.Name);
        }

        private static void GetCarsByBrandIdTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarsByBrandId(5).Data)
            {
                Console.WriteLine(car.Description);
            }
        }

        private static void CarDetailsTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
           
            var result = carManager.GetCarDetails();
            
    
            
                
                
                    foreach (var car in result.Data)
                    {
                    Console.WriteLine(car.CarName + " " + car.ColorName);
                    }
                



            Console.WriteLine(result.Message);
                                                                                                                       
            
          

        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.Name);
            }
        }

        private static void BrandTest2()
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
            
            

        

     
    


