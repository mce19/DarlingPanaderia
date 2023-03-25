using CoreEntities.Entities;

namespace WebApi.Dtos
{
    //
    public class ProductoDto
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public int Stock { get; set; }

        public int MarcaId { get; set; }

        public string MarcaNombre { get; set; }

        public int CategoriaId { get; set; } //cuando se realiza el proceso de migracion para convertir las clases en tablas, entities framewor core  reconocera categoriaId como la clave foranea y tomara la clase categoria como su referencia y asi parasara con Marca

        public string CategoriaNombre { get; set; }

        public decimal Precio { get; set; }

        public string Imagen { get; set; }
    }
}