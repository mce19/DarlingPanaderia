
using BisnessLogic.Data;
using CoreEntities.Entities;
using CoreEntities.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnessLogic.Logic
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly MarketDbContext _context;

        public ProductoRepository(MarketDbContext context) { //para tener acceso a la BD debemos inyectamos el objeto del contexto por eso este constructor  
        
            _context = context; //ya esta inyectado por lo cual lo podemos utiliz este objet para tener acceso a la entidades que representan a las tablas sql  
        }

      public async Task<Producto> GetProductoByIdAsync(int id)
        {
            var producto = await _context.Producto
               .Include(p => p.Marca)
               .Include(p => p.Categoria)
               .FirstOrDefaultAsync(p => p.Id == id);

            if (producto == null)
            {
                throw new ArgumentException($"No se encontró un producto con el ID {id}");
            }

            return producto;
        }

      public async Task<IReadOnlyList<Producto>> GetProductosAsync()
        {
            return await _context.Producto
                .Include(p => p.Marca)
                .Include(p => p.Categoria)
                .ToListAsync();

           

            
        }
    }
}
