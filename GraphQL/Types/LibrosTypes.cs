using GraphQL.Types;

namespace DemoODataVideo.GraphQL.Types
{
    public class LibrosTypes : ObjectGraphType<Libros>
    {
        public LibrosTypes()
        {
            BibliotecaContext ctx = new BibliotecaContext();
            Name = "Libro";
            Field(x => x.Id);
            Field(x => x.Nombre);
            Field(x => x.Genero);
            Field(x => x.Anio);
            Field<AutoresType>("Autor",
                arguments: new QueryArguments(
                     new QueryArgument<IntGraphType> { Name = "Id" }),
                resolve: context =>
                         ctx.Autores.Find(context.Source.IdAutor),
                         description: "Datos del autor");
        }
    }
}
