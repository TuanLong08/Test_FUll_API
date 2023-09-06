using A_DaTa.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_DaTa.Context
{
    public class MyDBContext : DbContext
    {
        public MyDBContext()
        {
            
        }

        public MyDBContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<ProDuct> ProDucts { get; set; }
    }
}
