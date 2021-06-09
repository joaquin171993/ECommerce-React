using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.DTOs;
using WebApi.Errors;

namespace WebApi.Controllers
{
    public class ProductoController : BaseApiController
    {
        private readonly IGenericRepository<Producto> productoRepository;
        private readonly IMapper mapper;

        public ProductoController(IGenericRepository<Producto> productoRepository, IMapper mapper)
        {
            this.productoRepository = productoRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Producto>>> GetProductos() 
        {
            var spec = new ProductoWithCategoriaAndMarcaSpecification();
            var productos = await productoRepository.GetAllWithSpec(spec);

            return Ok(mapper.Map<IReadOnlyList<Producto>, IReadOnlyList<ProductoDto>>(productos));
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
                var spec = new ProductoWithCategoriaAndMarcaSpecification(id.Value);
                var producto = await productoRepository.GetByIdWithSpec(spec);

                if (producto != null)
                {
                    return mapper.Map<Producto, ProductoDto>(producto);
                }

                return NotFound(new CodeErrorResponse(404, "El producto no existe"));
            }
        
        }

    }
}
