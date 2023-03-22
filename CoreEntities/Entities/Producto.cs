using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreEntities.Entities
{
    public class Producto : ClaseBase
    {

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public int Stock { get; set; }

        public int MarcaId { get; set; }

        public Marca Marca { get; set; }

        public int CategoriaId { get; set; } //cuando se realiza el proceso de migracion para convertir las clases en tablas, entities framewor core  reconocera categoriaId como la clave foranea y tomara la clase categoria como su referencia y asi parasara con Marca

        public Categoria Categoria { get; set; }

        public decimal Precio { get; set; }

        public string Imagen { get; set; }
        


    }
}
