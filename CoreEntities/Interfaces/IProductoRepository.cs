using CoreEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreEntities.Interfaces
{
    public interface IProductoRepository
    {
        //de tipo asincrono metodos de tipo asincrono -> varios metodos se ejecutan simultaniamente
        Task<Producto> GetProductoByIdAsync(int id);
        Task<IReadOnlyList<Producto>> GetProductosAsync();//este metodo me vulve todos los pruductos de mi tabla producto

        // la logica la hacemos en bisnesslogic
    }
}
