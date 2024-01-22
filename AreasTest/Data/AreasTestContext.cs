using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AreasTest.Models;

namespace AreasTest.Data
{
    public class AreasTestContext : DbContext
    {
        public AreasTestContext (DbContextOptions<AreasTestContext> options)
            : base(options)
        {
        }

        public DbSet<AreasTest.Models.Chat> Chat { get; set; } = default!;
    }
}
