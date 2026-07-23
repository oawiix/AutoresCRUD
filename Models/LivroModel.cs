
namespace AutoresCRUD.Models
{
    public class LivroModel
    {
        public int Id { get; set; }
        public  string Titulo {  get; set; } = string.Empty;
        public  required AutorModel Autor { get; set; }

        public LivroModel() { }

        public LivroModel(string titulo, AutorModel autor)
        {
            Titulo = titulo;
            Autor = autor;
        }
    }
}
