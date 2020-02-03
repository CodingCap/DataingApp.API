using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataingApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DataingApp.API.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Value> Values { get; set; }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options) { }
    }
}
