using CoreEntities.Entities;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BisnessLogic.Data
{
    public class MarketDbContextData
    {

        public static async Task CargarDataAsync(MarketDbContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                //   !  <- si no tiene valores has lo siguiente eso quiere decir
                if (!context.Marca.Any())
                {
                    var marcaData = File.ReadAllText("../BisnessLogic/CargarData/marca.json"); //leemos los datos desde el archiv Json
                    var marcas = JsonSerializer.Deserialize<List<Marca>>(marcaData); // luego los serializamos en un formato de tipo List marcas

                    foreach (var marca in marcas) //acertamos y alamcenamos cada uno de los elementos
                    {
                        context.Marca.Add(marca);
                    }
                    await context.SaveChangesAsync(); //procedimiento asincrono por eso el await
                }

                //   !  <- si no tiene valores has lo siguiente eso quiere decir
                if (!context.Categoria.Any())
                {
                    var categoriaData = File.ReadAllText("../BisnessLogic/CargarData/categoria.json"); //leemos los datos desde el archiv Json
                    var categorias = JsonSerializer.Deserialize<List<Categoria>>(categoriaData); // luego los serializamos en un formato de tipo List marcas

                    foreach (var categoria in categorias) //acertamos y alamcenamos cada uno de los elementos
                    {
                        context.Categoria.Add(categoria);
                    }
                    await context.SaveChangesAsync(); //procedimiento asincrono por eso el await
                }


                if (!context.Producto.Any())
                {
                    var productoData = File.ReadAllText("../BisnessLogic/CargarData/producto.json"); //leemos los datos desde el archiv Json
                    var productos = JsonSerializer.Deserialize<List<Producto>>(productoData); // luego los serializamos en un formato de tipo List marcas

                    foreach (var producto in productos) //acertamos y alamcenamos cada uno de los elementos
                    {
                        context.Producto.Add(producto);
                    }
                    await context.SaveChangesAsync(); //procedimiento asincrono por eso el await
                }


            }
            catch (Exception e)
            {

                var logger = loggerFactory.CreateLogger<MarketDbContextData>();
                logger.LogError(e.Message);
            }
        }
    }
}
