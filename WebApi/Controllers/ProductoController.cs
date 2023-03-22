
using CoreEntities.Entities;
using CoreEntities.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {

        private readonly IProductoRepository _productoRepository;

        public ProductoController(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }


        //http://localhost:5289/api/Producto 
        [HttpGet]
        public async Task<ActionResult<List<Producto>>> GetProductos()
        {
            var productos = await _productoRepository.GetProductosAsync();
            return Ok(productos);
        }


        //http://localhost:5289/api/Producto/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> GetProducto(int id)
        {
            return await _productoRepository.GetProductoByIdAsync(id);
        }
    }
}
