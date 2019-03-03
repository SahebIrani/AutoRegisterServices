using AutoRegisterServices.Application.Entities;

using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using System.Collections.Generic;
using System.Linq;

namespace AutoRegisterServices.Data
{
    public static class DatabaseInitializer
    {
        public static IApplicationBuilder EnsureSeedData(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<Context>();

                if (context != null && context.Database.GetPendingMigrations().Count() > 0) context.Database.Migrate();

                if (context.Database.EnsureCreated())
                {
                    if (!context.People.Any())
                    {
                        context.People.AddRange(new List<Person> {
                            new Person{FirstName = "Sinjul" , LastNmae = "MSBH" , Age = 26},
                            new Person{FirstName = "Jack" , LastNmae = "Slater" , Age = 26},
                    });

                        context.SaveChanges();
                    }

                    if (!context.Customers.Any())
                    {
                        context.Customers.AddRange(new List<Customer> {
                            new Customer{FirstName = "Sinjul" , LastNmae = "MSBH" , Age = 26},
                            new Customer{FirstName = "Jack" , LastNmae = "Slater" , Age = 26},
                    });

                        context.SaveChanges();
                    }
                }

                return app;
            }
        }
    }
}
