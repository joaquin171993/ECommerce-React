using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Controllers
{

    public class CategoriaController : BaseApiController
    {
        private readonly IGenericRepository<Categoria> categoriaRepository;

        public CategoriaController(IGenericRepository<Categoria> categoriaRepository)
        {
            this.categoriaRepository = categoriaRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Categoria>>> GetCategorias()
        {
            IReadOnlyList<Categoria> categorias = await categoriaRepository.GetAllAsync();

            return Ok(categorias);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Categoria>> GetCategoria(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            else
            {
                Categoria categoria = await categoriaRepository.GetByIdAsync(id.Value);

                if (categoria != null)
                {
                    return categoria;
                }

                return BadRequest();
            }

        }
    }
}
