using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Context;

    public class AppDbContext : DbContext
    {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
        
        public DbSet<Domain.Produto>? Produtos { get; set; }
        public DbSet<Domain.Categoria>? Categorias { get; set; }
    }
