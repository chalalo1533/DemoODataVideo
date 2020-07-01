namespace DemoODataVideo
{
    public partial class Libros
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Genero { get; set; }
        public int Anio { get; set; }
        public int IdAutor { get; set; }

        public virtual Autores IdAutorNavigation { get; set; }
    }
}
