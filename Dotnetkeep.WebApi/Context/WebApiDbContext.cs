using Dotnetkeep.WebApi.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dotnetkeep.WebApi.Context
{
   
    public class WebApiDbContext : DbContext
    {

        public WebApiDbContext(DbContextOptions<WebApiDbContext> options)
       : base(options)
        {


        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }

    }
}
