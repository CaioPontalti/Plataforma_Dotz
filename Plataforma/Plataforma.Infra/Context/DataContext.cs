using Microsoft.EntityFrameworkCore;
using Plataforma.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Plataforma.Infra.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> opt) : base(opt)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<AddressUser> AddressUsers { get; set; }
        public DbSet<Balance> Balances { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

    }
}
