using CoreEntities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BisnessLogic.Data
{
    public class MarketDbContext :DbContext
    {
        public MarketDbContext(DbContextOptions<MarketDbContext> options) : base(options) { }//esta esperando como parametro la cadena de conexion 

        public DbSet<Producto> Producto { get; set; }

        public DbSet<Categoria> Categoria { get; set; }

        public DbSet<Marca> Marca { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
