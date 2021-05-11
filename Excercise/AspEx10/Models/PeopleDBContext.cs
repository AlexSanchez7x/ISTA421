using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AspEx10.Models
{
    public class PeopleDBContext : DbContext
    {
        public PeopleDBContext(DbContextOptions<PeopleDBContext> options)
        :base(options) { }
        public DbSet<Person> People { get; set; }

    }
}



