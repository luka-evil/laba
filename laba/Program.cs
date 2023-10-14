using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using project;

using (ApplicationContext db = new())
{
    User tom = new User { Name = "Tom", Age = 33 };
    User alice = new User { Name = "Alice", Age = 26 };
    User Nikita = new User { Name = "Nikita", Age = 29 };
    User Sasha = new User { Name = "Sasha", Age = 90 };

    db.Users.Add(Sasha);
    db.Users.Add(Nikita);
    db.Users.Add(tom);
    db.Users.Add(alice);
    db.SaveChanges();
    Console.WriteLine("Объекты успешно сохранены");

    var users = db.Users.ToList();
    Console.WriteLine("Список объектов:");
    foreach (User u in users)
    {
        Console.WriteLine($".{u.Name} - {u.Age}");
    }
}

namespace project
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
    }

    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public ApplicationContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=dbLaba;Trusted_Connection=True;");
        }
    }

}