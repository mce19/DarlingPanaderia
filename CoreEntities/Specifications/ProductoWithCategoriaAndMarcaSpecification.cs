using CoreEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreEntities.Specifications
{
    public class ProductoWithCategoriaAndMarcaSpecification : SpecificationEvaluator<Producto>
    {
        public ProductoWithCategoriaAndMarcaSpecification()
        {
            AddInclude(P => P.Categoria);
            AddInclude(P => P.Marca);
        }

        public ProductoWithCategoriaAndMarcaSpecification(int id) : base(x => x.Id == id) // ProductoWithCategoriaAndMarcaSpecification(string nombreProducto) : base(x => x.Nombre == nombreProducto) si buscaramos por nombre
        {
            AddInclude(P => P.Categoria);
            AddInclude(P => P.Marca);
        }
    }
}