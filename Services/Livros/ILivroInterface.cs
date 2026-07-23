using AutoresCRUD.Dtos;
using AutoresCRUD.Models;

namespace AutoresCRUD.Services.Livros
{
    public interface ILivroInterface
    {
        Task<ResponseModel<LivroModel>> CriarLivro(CriarLivroDto livro, CancellationToken cancellationToken = default);

        Task<ResponseModel<LivroModel>> ExcluirLivro(int idLivro);

        Task<ResponseModel<LivroModel>> EditarLivro(EditarLivroDto livro, int livroId, CancellationToken cancellationToken = default);
        Task<ResponseModel<List<LivroModel>>> ListarLivros(CancellationToken cancellationToken = default);
        Task<ResponseModel<LivroModel>> BuscarLivroPorId(int livroId, CancellationToken cancellationToken = default);
        Task<ResponseModel<List<LivroModel>>> BuscarLivrosPorAutorId(int autorId, CancellationToken cancellationToken = default);

    }
}
