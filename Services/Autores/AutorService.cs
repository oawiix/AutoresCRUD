using AutoresCRUD.Data;
using AutoresCRUD.Dtos;
using AutoresCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoresCRUD.Services.Autores
{
    public class AutorService : IAutorInterface
    {
        private readonly AppDbContext _context;
        public AutorService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<AutorModel>>> ListarAutores(CancellationToken cancellationToken = default)
        {
            ResponseModel<List<AutorModel>> response = new ResponseModel<List<AutorModel>>();
            try
            {
                var autores = await _context.Autor.AsNoTracking()
                    .ToListAsync(cancellationToken);

                response.Data = autores;
                response.Message = "Autores listados com sucesso.";
                response.Success = true;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = $"Erro ao listar autores: {ex.Message}";
                return response;
            }
        }
        public async Task<ResponseModel<AutorModel>> BuscarAutorPorId(int idAutor, CancellationToken cancellationToken = default)
        {
            ResponseModel<AutorModel> response = new ResponseModel<AutorModel>();
            try
            {
                var autor = await _context.Autor.AsNoTracking()
                    .FirstOrDefaultAsync(a => a.Id == idAutor);

                if (autor == null)
                {
                    response.Message = "Autor não encontrado.";
                    return response;
                }
                response.Data = autor;
                response.Message = "Autor listado com sucesso.";
                response.Success = true;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = $"Erro ao listar autor: {ex.Message}";
                return response;
            }
        }

        public async Task<ResponseModel<AutorModel>> BuscarAutorPorIdLivro(int idLivro, CancellationToken cancellationToken = default)
        {
            ResponseModel<AutorModel> response = new ResponseModel<AutorModel>();
            try
            {
                var autor = await _context.Livro.AsNoTracking()
                    .Where(l => l.Id == idLivro)
                    .Select(l => l.Autor)
                    .FirstOrDefaultAsync(cancellationToken);
                if (autor == null)
                {
                    response.Message = "Autor não encontrado para o livro informado.";
                    return response;
                }

                response.Data = autor;
                response.Message = "Autor encontrado com sucesso.";
                response.Success = true;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = $"Erro ao listar autor: {ex.Message}";
                return response;
            }
        }


        public async Task<ResponseModel<AutorModel>> CriarAutor(CriarAutorDto autorDto, CancellationToken cancellationToken = default)
        {
            ResponseModel<AutorModel> response = new ResponseModel<AutorModel>();
            var novoAutor = new AutorModel(autorDto.Nome, autorDto.Sobrenome);
            if (string.IsNullOrWhiteSpace(novoAutor.Nome) || string.IsNullOrWhiteSpace(novoAutor.Sobrenome))
            {
                response.Message = "Nome e Sobrenome são obrigatórios.";
                return response;
            }
            try
            {
                await _context.Autor.AddAsync(novoAutor, cancellationToken);
                await _context.SaveChangesAsync();
                response.Data = novoAutor;
                response.Message = "Autor criado com sucesso.";
                response.Success = true;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = $"Erro ao criar autor: {ex.Message}";
                return response;
            }
        }

        public async Task<ResponseModel<AutorModel>> EditarAutor(int autorId, EditarAutorDto autor, CancellationToken cancellationToken = default)
        {
            ResponseModel<AutorModel> response = new ResponseModel<AutorModel>();
            try
            {
                if(string.IsNullOrWhiteSpace(autor.Nome) || string.IsNullOrWhiteSpace(autor.Sobrenome))
                {
                    response.Message = "Nome e Sobrenome são obrigatórios.";
                    return response;
                }
                var oldAutor = await _context.Autor.FirstOrDefaultAsync(a => a.Id == autorId, cancellationToken);
                if (oldAutor == null)
                {
                    response.Message = "Autor não encontrado.";
                    return response;
                }

                oldAutor.Nome = autor.Nome;
                oldAutor.Sobrenome = autor.Sobrenome;
                await _context.SaveChangesAsync();

                response.Data = oldAutor;
                response.Message = "Autor editado com sucesso.";
                response.Success = true;
                return response;

            }
            catch (Exception ex)
            {
                response.Message = $"Erro ao editar autor: {ex.Message}";
                return response;
            }
        }

        public async Task<ResponseModel<AutorModel>> ExcluirAutor(int autorId, CancellationToken cancellationToken = default)
        {
            ResponseModel<AutorModel> response = new ResponseModel<AutorModel>();
            try
            {
                var autor = await _context.Autor.FirstOrDefaultAsync(a => a.Id == autorId, cancellationToken);
                if (autor == null)
                {
                    response.Message = "Autor não encontrado.";
                    return response;
                }
                _context.Autor.Remove(autor);
                await _context.SaveChangesAsync();
                response.Data = autor;
                response.Message = "Autor excluído com sucesso.";
                response.Success = true;
                return response;


            }
            catch (Exception ex)
            {
                response.Message = $"Erro ao excluir autor: {ex.Message}";
                return response;
            }
        }
    }
}
