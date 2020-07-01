using DemoODataVideo.GraphQL.Types;
using GraphQL.Types;

namespace DemoODataVideo.GraphQL.Queries
{
    public class Mutacion : ObjectGraphType
    {
        private readonly BibliotecaContext _context;

        public Mutacion(BibliotecaContext context)
        {
            _context = context;

            Field<AutoresType>(
                "crearAutor",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<AutoresInputType>> { Name = "autores" }),
                resolve: context =>
                {
                    var autor = context.GetArgument<Autores>("autores");
                    _context.Autores.Add(autor);
                    _context.SaveChanges();
                    return autor;

                });


        }

    }
}
