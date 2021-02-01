using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.ModelYear + " " + " Üretim Tarihli Ve Günlük Fiyatı " + " " + car.DailyPrice + " " + " TL " + " " + " Olan Arabamız :" + " " + car.Description );
            }
        }
    }
}
