using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Historia.Modelos;

    public class DataContext : DbContext
    {
        public DataContext (DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Historia.Modelos.Dios> Dioses { get; set; } = default!;

        public DbSet<Historia.Modelos.Mitologia>? Mitologias { get; set; }
    }
