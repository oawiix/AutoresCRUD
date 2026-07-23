using System.Text.Json.Serialization;
using AutoresCRUD.Dtos;

namespace AutoresCRUD.Models
{
    public class AutorModel
    {
        public int Id { get; set;}
        public  string Nome { get; set;} = string.Empty;
        public  string Sobrenome { get; set; } = string.Empty;
        [JsonIgnore]
        public virtual ICollection<LivroModel> Livros { get; set; } = new List<LivroModel>();

        public AutorModel() { }

        public AutorModel(string nome, string sobrenome)
        {
            Nome = nome;
            Sobrenome = sobrenome;
        }
        public AutorModel(CriarAutorDto autorDto)
        {
            Nome = autorDto.Nome;
            Sobrenome = autorDto.Sobrenome;
        }
    }
}
