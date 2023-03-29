using AutoMapper;
using CoreEntities.Entities;
using CoreEntities.Interfaces;
using CoreEntities.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dtos;
using WebApi.Errors;

namespace WebApi.Controllers
{
    public class ProductoController : BaseApiController
    {
        private readonly IGenericRepository<Producto> _productoRepository;
        private readonly IMapper _mapper;//para utilizar el autoMAper aqui hay que injectarlo por eso se crea  y tambien en el ProductoConstructor abajo

        public ProductoController(IGenericRepository<Producto> productoRepository, IMapper mapper)
        {
            _productoRepository = productoRepository;
            _mapper = mapper;
        }

        //http://localhost:5289/api/Producto
        [HttpGet]
        public async Task<ActionResult<List<Producto>>> GetProductos()
        {
            var spec = new ProductoWithCategoriaAndMarcaSpecification();// como queremos que nos pase todos los productos que tenemos en la base de datos le quitamoe el parametro id por lo cual no habra filtro
            var productos = await _productoRepository.GetAllWithSpec(spec);

            return Ok(_mapper.Map<IReadOnlyList<Producto>, IReadOnlyList<ProductoDto>>(productos));
        }

        //http://localhost:5289/api/Producto/1
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductoDto>> GetProducto(int id)
        {
            //spec = debe incluir la logica de la condicion de la consulta y tambien las relaciones entre las entidades, la relacion entre producto , marca y categoria.
            //toda esa logica y relaciones debebia estar dentro del objeto spec, pero si hablabamos de un objeto significa de proviene de una clase, pero no existe una clase por lo cual la vamos a crear en coreentities y specifications
            var spec = new ProductoWithCategoriaAndMarcaSpecification(id);//esta clase tiene dos constructuctores y si la inicialisamos con el parametro id lo que va hacer es crear el objeto el filtro y las relaciones entre las tablas y si no pasa el parametro id solo creara las relaciones pero no los filtros
            var producto = await _productoRepository.GetByIdWithSpec(spec);

            if (producto == null)
            {
                return NotFound(new CodeErrorResponse(404)); //tambien se puede personalizar asi CodeErrorResponse(404, "El producto no fue encontroda"));  pero como solo le mandomos el 404 el cual ya lo tiene guardado
            }

            return _mapper.Map<Producto, ProductoDto>(producto);
        }
    }
}