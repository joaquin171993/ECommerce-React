using BusinessLogic.Data;
using Core.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace BusinessLogic.CargarData
{
    public class MarketDbContextData
    {
        public static async Task CargarDataAsync(MarketDbContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.Marca.Any()) /*indica si no tiene algun valor al menos en la tabla*/
                {
                    var marcaData = File.ReadAllText("../BusinessLogic/CargarData/marca.json");
                    var marcas = JsonSerializer.Deserialize<List<Marca>>(marcaData);

                    foreach (var marca in marcas)
                    {
                        await context.Marca.AddAsync(marca);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.Categoria.Any()) /*indica si no tiene algun valor al menos en la tabla*/
                {
                    var categoriaData = File.ReadAllText("../BusinessLogic/CargarData/categoria.json");
                    var categorias = JsonSerializer.Deserialize<List<Categoria>>(categoriaData);

                    foreach (var categoria in categorias)
                    {
                        await context.Categoria.AddAsync(categoria);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.Producto.Any()) /*indica si no tiene algun valor al menos en la tabla*/
                {
                    var productoData = File.ReadAllText("../BusinessLogic/CargarData/producto.json");
                    var productos = JsonSerializer.Deserialize<List<Producto>>(productoData);

                    foreach (var producto in productos)
                    {
                        await context.Producto.AddAsync(producto);
                    }

                    await context.SaveChangesAsync();
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
