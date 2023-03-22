using CoreEntities.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnessLogic.Data.Configuration
{
    public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            //aqui agregamos todos los requisitos que deben tener cada una de la propiedades de la clase pruducto

            //si el user no envia el dato del nombre producto se dispara un error y tambien le indicamos la logitud del texo con .HasMaxLength(250);
            builder.Property(x => x.Nombre).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Descripcion).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Precio).HasColumnType("decimal()18,2");
            builder.Property(x => x.Imagen).HasMaxLength(1000);
            builder.HasOne(m => m.Marca).WithMany().HasForeignKey(p => p.MarcaId);
            builder.HasOne(c => c.Categoria).WithMany().HasForeignKey(p => p.CategoriaId);

        }
    }
}
