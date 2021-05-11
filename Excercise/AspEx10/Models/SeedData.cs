using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace AspEx10.Models
{
    public class SeedData
    {


        public static void EnsurePopulated(IApplicationBuilder app)
        {
            PeopleDBContext context = app.ApplicationServices
            .CreateScope().ServiceProvider.GetRequiredService<PeopleDBContext>();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            if (!context.People.Any())
            {
                context.People.AddRange(
                new Person
                {
                    Name = "Alex",
                    FatherName = "Jose",
                    MotherName = "Claudia",
                    LastName = "Sanchez"
                },
                new Person
                {
                    Name = "Jake",
                    FatherName = "Bill",
                    MotherName = "Hana",
                    LastName = "Williams"
                },
                new Person
                {
                    Name = "Claudia",
                    FatherName = "Jim",
                    MotherName = "Jane",
                    LastName = "George"
                },
                new Person
                {
                    Name = "Lucy",
                    FatherName = "Vincent",
                    MotherName = "Lucretia",
                    LastName = "Valentine"
                }
                );
                context.SaveChanges();
            }
        }

    }
}
