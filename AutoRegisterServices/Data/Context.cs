using AutoRegisterServices.Application.Entities;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;

namespace AutoRegisterServices.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>().ToTable("People");
            modelBuilder.Entity<Customer>().ToTable("Customers");

            modelBuilder.Entity<Person>().HasData(new List<Person> {
                new Person{PersonId = Guid.NewGuid(), FirstName = "Sinjul" , LastNmae = "MSBH" , Age = 26},
                new Person{PersonId = Guid.NewGuid(), FirstName = "Jack" , LastNmae = "Slater" , Age = 26},
            });

            modelBuilder.Entity<Customer>().HasData(new List<Customer> {
                new Customer{CustomerId = Guid.NewGuid(), FirstName = "Sinjul" , LastNmae = "MSBH" , Age = 26},
                new Customer{CustomerId = Guid.NewGuid(), FirstName = "Jack" , LastNmae = "Slater" , Age = 26},
            });
        }
    }
}
