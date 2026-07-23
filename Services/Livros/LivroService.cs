using AutoresCRUD.Data;
using AutoresCRUD.Dtos;
using AutoresCRUD.Models;
using Microsoft.EntityFrameworkCore;
namespace AutoresCRUD.Services.Livros
{
    public class LivroService : ILivroInterface
    {
        private readonly AppDbContext _context;

        public LivroService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<LivroModel>> CriarLivro(CriarLivroDto livro, CancellationToken cancellationToken = default)
        {
            ResponseModel<LivroModel> response = new ResponseModel<LivroModel>();
            try
            {
                var autor = await _context.Autor.FirstOrDefaultAsync(a => a.Id == livro.AutorId, cancellationToken);

                if (autor == null)
                {
                    response.Message = "Autor não encontrado";
                    return response;
                }

                var novoLivro = new LivroModel()
                {
                    Titulo = livro.Titulo,
                    Autor = autor
                };

                await _context.Livro.AddAsync(novoLivro, cancellationToken);
                await _context.SaveChangesAsync();

                response.Data = novoLivro;
                response.Message = "Livro criado com sucesso";
                response.Success = true;
                return response;
            }

            catch (Exception ex)
            {
                response.Message = $"Erro ao criar livro: {ex.Message}";
                return response;
            }

        }

        public async Task<ResponseModel<LivroModel>> ExcluirLivro(int idLivro)
        {
            ResponseModel<LivroModel> response = new ResponseModel<LivroModel>();
            var livro = await _context.Livro.Include(a => a.Autor).FirstOrDefaultAsync(l => l.Id == idLivro);
            response.Data = livro;
            if (livro == null)
            {
                response.Message = "Livro não encontrado";
                return response;
            }
            _context.Livro.Remove(livro);
            await _context.SaveChangesAsync();
            response.Message = "Livro excluído com sucesso";
            response.Success = true;
            return response;
        }


        public async Task<ResponseModel<LivroModel>> EditarLivro(EditarLivroDto livro, int livroId, CancellationToken cancellationToken = default)
        {
            ResponseModel<LivroModel> response = new ResponseModel<LivroModel>();
            try
            {
                var oldlivro = await _context.Livro.FirstOrDefaultAsync(l => l.Id == livroId, cancellationToken);
                if (oldlivro == null)
                {
                    response.Message = "Livro não encontrado";
                    return response;
                }
                var autor = await _context.Autor.FindAsync(livro.AutorId, cancellationToken);
                if (autor == null)
                {
                    response.Message = "Autor não encontrado";
                    return response;
                }
                oldlivro.Titulo = livro.Titulo;
                oldlivro.Autor = autor;
                await _context.SaveChangesAsync();
                response.Data = oldlivro;
                response.Message = "Livro editado com sucesso";
                response.Success = true;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = $"Erro ao editar livro: {ex.Message}";
                return response;
            }
        }

        public async Task<ResponseModel<List<LivroModel>>> ListarLivros(CancellationToken cancellationToken = default)
        {
            ResponseModel<List<LivroModel>> response = new ResponseModel<List<LivroModel>>();
            try
            {
                var livros = await _context.Livro.AsNoTracking()
                        .Include(a => a.Autor)
                        .ToListAsync(cancellationToken);
                response.Data = livros;
                response.Message = "Livros listados com sucesso";
                response.Success = true;
                return response;

            }
            catch (Exception ex)
            {

                response.Message = $"Erro ao listar livros: {ex.Message}";
                return response;
            }
        }

        public async Task<ResponseModel<LivroModel>> BuscarLivroPorId(int livroId, CancellationToken cancellationToken = default)
        {
            ResponseModel<LivroModel> response = new ResponseModel<LivroModel>();
            try
            {
                var livro = await _context.Livro.AsNoTracking()
                    .Include(a => a.Autor)
                    .FirstOrDefaultAsync(l => l.Id == livroId, cancellationToken);
                if (livro == null)
                {
                    response.Message = "Livro não encontrado";
                    return response;
                }
                response.Data = livro;
                response.Message = "Livro encontrado com sucesso";
                response.Success = true;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = $"Erro ao buscar livro: {ex.Message}";
                return response;
            }
        }

        public async Task<ResponseModel<List<LivroModel>>> BuscarLivrosPorAutorId(int autorId, CancellationToken cancellationToken = default)
        {
            ResponseModel<List<LivroModel>> response = new ResponseModel<List<LivroModel>>();
            try
            {
                var livros = await _context.Livro.AsNoTracking()
                    .Include(a => a.Autor)
                    .Where(l => l.Autor.Id == autorId)
                    .ToListAsync(cancellationToken);
                if (livros.Count == 0)
                {
                    response.Message = "Nenhum livro encontrado para o autor especificado";
                    return response;
                }
                response.Data = livros;
                response.Message = "Livros encontrados com sucesso";
                response.Success = true;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = $"Erro ao buscar livros por autor: {ex.Message}";
                return response;
            }
        }
    }
}
