using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.DTOs;
using WebApi.Errors;

namespace WebApi.Controllers
{
    public class ProductoController : BaseApiController
    {
        /*se trabaja con la interfaz generica, se pasa la entidad*/
        private readonly IGenericRepository<Producto> productoRepository;
        private readonly IMapper mapper;

        public ProductoController(IGenericRepository<Producto> productoRepository, IMapper mapper)
        {
            this.productoRepository = productoRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<ProductoDto>>> GetProductos([FromQuery] ProductoSpecificationsParams parametros)
        {
            /*para crear la especificacion de la lista de productos*/
            ProductoWithCategoriaAndMarcaSpecification spec = new(parametros);
            IReadOnlyList<Producto> productos = await productoRepository.GetAllWithSpec(spec);

            /*para crear la especificacion del paginado*/
            ProductoForCountingSpecifications specCount = new(parametros);
            int totalProductos = await productoRepository.CountAsync(specCount);

            decimal rounded = Math.Ceiling(Convert.ToDecimal(totalProductos / parametros.PageSize));

            int totalPages = Convert.ToInt32(rounded); /*obtener el total de paginas que se le envia al cliente*/

            /*lista de productos a enviar*/
            IReadOnlyList<ProductoDto> data = mapper.Map<IReadOnlyList<Producto>, IReadOnlyList<ProductoDto>>(productos);

            return Ok(
                new Pagination<ProductoDto>
                {
                    Count = totalProductos,
                    Data = data,
                    PageCount = totalPages,
                    PageIndex = parametros.PageIndex,
                    PageSize = parametros.PageSize
                }
            );
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductoDto>> GetProducto(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            else
            {
                /*este spec debe incluir la logica de la condicion de la consulta y tambien las relaciones entre las entidades
                 la relacion entre producto, marca y categoria*/
                ProductoWithCategoriaAndMarcaSpecification spec = new(id.Value);
                Producto producto = await productoRepository.GetByIdWithSpec(spec);

                if (producto != null)
                {
                    return mapper.Map<Producto, ProductoDto>(producto);
                }

                return NotFound(new CodeErrorResponse(404, "El producto no existe"));
            }

        }

    }
}
