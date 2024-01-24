using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using lunettes.Models;

namespace lunettes.Data
{
    public class lunettesContext : DbContext
    {
        public lunettesContext (DbContextOptions<lunettesContext> options)
            : base(options)
        {
        }

        public DbSet<lunettes.Models.Order> Order { get; set; } = default!;
        public DbSet<lunettes.Models.OrderDetails> OrderDetails { get; set; } = default!;
        public DbSet<lunettes.Models.Products> Products { get; set; } = default!;
        public DbSet<lunettes.Models.ProductTypes> ProductTypes { get; set; } = default!;
        public DbSet<lunettes.Models.SpecialTags> SpecialTags { get; set; } = default!;
        public DbSet<lunettes.Models.Panier> Panier { get; set; } = default!;
       
    }
}
