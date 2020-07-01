using System.Collections.Generic;

namespace DemoODataVideo
{
    public partial class Autores
    {
        public Autores()
        {
            Libros = new HashSet<Libros>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Nacionalidad { get; set; }

        public virtual ICollection<Libros> Libros { get; set; }
    }
}
