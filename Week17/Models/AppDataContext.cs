using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week17.Models;

namespace Week17.Models
{
    public class AppDataContext : IdentityDbContext<AppUser>
    {
        
        public AppDataContext(DbContextOptions<AppDataContext> options) :
        base(options)
        { }

        public DbSet<Product> Products { get; set; }

        public DbSet<Basket> Basket { get; set; }

    }
}
