using DemoODataVideo.GraphQL.Types;
using GraphQL;
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




            Field<AutoresType>(
                  "modificarAutor",
                  arguments: new QueryArguments(
                      new QueryArgument<NonNullGraphType<AutoresInputType>> { Name = "autores" },
                      new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id" }
                      ),
                  resolve: context =>
                  {
                      var autor = context.GetArgument<Autores>("autores");
                      var id = context.GetArgument<int>("id");

                      var autordb = _context.Autores.Find(id);
                      if (autordb == null)
                      {
                          context.Errors.Add(new ExecutionError("Ups!!, el id no existe!! :("));
                          return null;
                      }

                      autordb.Nombre = autor.Nombre;
                      autordb.Nacionalidad = autor.Nacionalidad;
                      _context.SaveChanges();

                      return autordb;

                  });


        }





    }
}
