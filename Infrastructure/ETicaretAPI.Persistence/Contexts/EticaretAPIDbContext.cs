﻿using ETicaretAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Contexts
{
    public class EticaretAPIDbContext : DbContext
    { 
        public EticaretAPIDbContext(DbContextOptions options) : base(options)
        { 

        }
        //veri tabanına P.O.C entityleri ile alakalı tabloları oluşturma
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}