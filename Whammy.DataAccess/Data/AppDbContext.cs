using System;
using Microsoft.EntityFrameworkCore;
using Whammy.Models;

namespace Whammy.DataAccess.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Category> categories { get; set; }
        public DbSet<FoodType> foodTypes { get; set; }
    }
}

