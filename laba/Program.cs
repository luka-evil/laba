using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using project;

using (ApplicationContext db = new())
{
    Human Nikita = new Human { Name = "Niklta", Age = 13 };
    Human 卄凵长凵丅卂 = new Human { Name = "卄凵长凵丅卂", Age = 17 };
    Human 匚卂尺 = new Human { Name = "匚卂尺", Age = 1000 };
    Human TomasShelbi = new Human { Name = "丅口从卂丂 丂卄乇乚乃工", Age = -7 };

    CarShop IliaBudanov = new CarShop { Name = "凵人乚牙 万丫丑卂卄口乃", Quantity = 1000 };

    Car Porshe = new Car { Name = "亡丹乇几", Release = 2001, Shop = IliaBudanov };
    Car Bmw = new Car { Name = "匚卂丫乇冂冂乇", Release = 2011, Shop = IliaBudanov };
    Car Audi = new Car { Name = "R8", Release = 2021, Shop = IliaBudanov };
    Car Mazda = new Car { Name = "RX8", Release = 2111, Shop = IliaBudanov };

    db.CarShops.Add(IliaBudanov);

    db.Humans.Add(Nikita);
    db.Humans.Add(卄凵长凵丅卂);
    db.Humans.Add(匚卂尺);
    db.Humans.Add(TomasShelbi);

    db.Cars.Add(Porshe);
    db.Cars.Add(Bmw);
    db.Cars.Add(Audi);
    db.Cars.Add(Mazda);

    db.SaveChanges();
    Console.WriteLine("Объекты успешно сохранены");

 
    Console.WriteLine("Список объектов:");
    foreach ( Human u in db.Humans.ToArray() )
    {
        Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
    }

    foreach (Car u in db.Cars.ToArray())
    {
        Console.WriteLine($"{u.Name}.{u.Release} - {u.ShopId} - {u.Id}");
    }

    foreach (CarShop u in db.CarShops.ToArray())
    {
        Console.WriteLine($"{u.Id}.{u.Name} - {u.Quantity}");
    }

}

namespace project
{
    public class Human
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
    }

    public class Car
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Release { get; set; }
        public int ShopId { get; set; }
        public CarShop Shop { get; set; }
    }

    public class CarShop
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Quantity { get; set; }
        public List<Car> ArrayCars { get; set; }
    }

    public class ApplicationContext : DbContext
    {
        public DbSet<Human> Humans => Set<Human>();
        public DbSet<Car> Cars => Set<Car>();
        public DbSet<CarShop> CarShops => Set<CarShop>();
        public ApplicationContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=dbAA;Trusted_Connection=True;");
        }
    }

}
