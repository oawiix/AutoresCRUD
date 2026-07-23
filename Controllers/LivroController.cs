using AutoresCRUD.Dtos;
using AutoresCRUD.Models;
using AutoresCRUD.Services.Livros;
using Microsoft.AspNetCore.Mvc;

namespace AutoresCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly ILivroInterface _livroInterface;

        public LivroController(ILivroInterface livroInterface)
        {
            _livroInterface = livroInterface;
        }

        [HttpPost("criar-livro")]
        public async Task<ActionResult<ResponseModel<LivroModel>>> CriarLivro(CriarLivroDto livro, CancellationToken cancellationToken = default)
        {
            var response = await _livroInterface.CriarLivro(livro, cancellationToken);
            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpDelete("excluir-livro/{livroId:int}")]
        public async Task<ActionResult<ResponseModel<LivroModel>>> ExcluirLivro(int livroId)
        {
            var response = await _livroInterface.ExcluirLivro(livroId);
            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return NotFound(response);
            }
        }

        [HttpPut("editar-livro/{livroId:int}")]
        public async Task<ActionResult<ResponseModel<LivroModel>>> EditarLivro(EditarLivroDto livro, int livroId, CancellationToken cancellationToken = default)
        {
            var response = await _livroInterface.EditarLivro(livro, livroId, cancellationToken);
            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return NotFound(response);
            }
        }

        [HttpGet("listar-livros")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> ListarLivros(CancellationToken cancellationToken = default)
        {
            var response = await _livroInterface.ListarLivros(cancellationToken);
            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return NotFound(response);
            }
        }

        [HttpGet("buscar-livro-por-id/{livroId:int}")]
        public async Task<ActionResult<ResponseModel<LivroModel>>> BuscarLivroPorId(int livroId, CancellationToken cancellationToken = default)
        {
            var response = await _livroInterface.BuscarLivroPorId(livroId, cancellationToken);
            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return NotFound(response);
            }
        }


        [HttpGet("buscar-livros-por-autor-id/{autorId:int}")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> BuscarLivrosPorAutorId(int autorId, CancellationToken cancellationToken = default)
        {
            var response = await _livroInterface.BuscarLivrosPorAutorId(autorId, cancellationToken);
            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return NotFound(response);
            }

        }
    }
}
