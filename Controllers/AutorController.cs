using AutoresCRUD.Models;
using AutoresCRUD.Services.Autores;
using Microsoft.AspNetCore.Mvc;
using AutoresCRUD.Dtos;

namespace AutoresCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IAutorInterface _autorInterface;

        public AutorController(IAutorInterface autorInterface) 
        {
            _autorInterface = autorInterface;
        }

        [HttpGet("listar-autores")]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> ListarAutores(CancellationToken cancellationToken = default)
        {
            var response = await _autorInterface.ListarAutores(cancellationToken);
            if (response.Success) 
            {
                return Ok(response);
            }
            return NotFound(response);
        }


        [HttpGet("buscar-autor-por-id/{idAutor:int}")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> BuscarAutorPorId(int idAutor, CancellationToken cancellationToken = default)
        {
            var response = await _autorInterface.BuscarAutorPorId(idAutor, cancellationToken);
            if (response.Success) 
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("buscar-autor-por-id-livro/{idLivro:int}")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> BuscarAutorPorIdLivro(int idLivro, CancellationToken cancellationToken = default)
        {
            var response = await _autorInterface.BuscarAutorPorIdLivro(idLivro, cancellationToken);
            if (response.Success) 
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpPost("criar-autor")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> CriarAutor(CriarAutorDto autorDto, CancellationToken cancellationToken = default)
        {
            var response = await _autorInterface.CriarAutor(autorDto, cancellationToken);
            if (response.Success) 
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut("editar-autor/{autorId:int}")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> EditarAutor(int autorId, EditarAutorDto autor, CancellationToken cancellationToken = default)
        {
            var response = await _autorInterface.EditarAutor(autorId, autor, cancellationToken);
            if (response.Success) 
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("excluir-autor/{autorId:int}")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> ExcluirAutor(int autorId, CancellationToken cancellationToken = default)
        {
            var response = await _autorInterface.ExcluirAutor(autorId, cancellationToken);
            if (response.Success) 
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}
