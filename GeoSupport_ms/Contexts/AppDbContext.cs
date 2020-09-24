using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeoSupport_ms.Models;
using Microsoft.EntityFrameworkCore;

namespace GeoSupport_ms.Contexts
{
    public class AppDbContext: DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        public DbSet<Country> Country{ get; set; }
    }
}
