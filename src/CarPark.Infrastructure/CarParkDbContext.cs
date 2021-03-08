using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using CarPark.Domain.ApplicationUsers;

namespace CarPark.Infrastructure
{
    public class CarParkDbContext : DbContext
    {
        public CarParkDbContext(DbContextOptions<CarParkDbContext> options)
            : base(options)
        {

        }

        public DbSet<ApplicationUser> Users { get; set; }
    }
}
