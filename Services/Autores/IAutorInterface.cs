using AutoresCRUD.Dtos;
using AutoresCRUD.Models;

namespace AutoresCRUD.Services.Autores
{
    public interface IAutorInterface
    {
        Task<ResponseModel<List<AutorModel>>> ListarAutores(CancellationToken cancellationToken = default);
        Task<ResponseModel<AutorModel>> BuscarAutorPorId(int idAutor, CancellationToken cancellationToken = default);
        Task<ResponseModel<AutorModel>> BuscarAutorPorIdLivro(int idLivro, CancellationToken cancellationToken = default);
        Task<ResponseModel<AutorModel>> CriarAutor(CriarAutorDto autorDto, CancellationToken cancellationToken = default);
        Task<ResponseModel<AutorModel>> EditarAutor(int autorId, EditarAutorDto autor, CancellationToken cancellationToken = default);
        Task<ResponseModel<AutorModel>> ExcluirAutor(int autorId, CancellationToken cancellationToken = default);

    }
}
