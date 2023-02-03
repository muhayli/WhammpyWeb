using System;
using Microsoft.EntityFrameworkCore;
using WhammyWeb.Models;

namespace WhammyWeb.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        public DbSet<Category> categories { get; set; } 


    }
}

