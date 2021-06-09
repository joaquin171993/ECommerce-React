using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    public class MarcaController : BaseApiController
    {
        private readonly IGenericRepository<Marca> marcaRepository;

        public MarcaController(IGenericRepository<Marca> marcaRepository)
        {
            this.marcaRepository = marcaRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Marca>>> GetMarcas()
        {
            var marcas = await marcaRepository.GetAllAsync();

            return Ok(marcas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Marca>> GetMarca(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            else
            {
                var marca = await marcaRepository.GetByIdAsync(id.Value);

                if (marca != null)
                {
                    return marca;
                }

                return BadRequest();
            }

        }
    }
}
