using GraphDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GraphDemo
{
    public class OMSOrdersContext : DbContext
    {
        public OMSOrdersContext(DbContextOptions<OMSOrdersContext> options)
            : base(options)
        {
        }

        public DbSet<Orders> Orders { get; set; }
    }
}
