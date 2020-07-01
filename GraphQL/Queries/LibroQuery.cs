using DemoODataVideo.GraphQL.Types;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DemoODataVideo.GraphQL.Queries
{
    public class LibroQuery : ObjectGraphType
    {
        private readonly BibliotecaContext _context;

        public LibroQuery(BibliotecaContext context)
        {
            this._context = context;

            Field<ListGraphType<LibrosTypes>>(
               "libros",
               arguments: new QueryArguments(new List<QueryArgument>
               {
                   new QueryArgument<IdGraphType>
                   {
                       Name="id"
                   }

               }),
               resolve: context =>
               {
                   var LibroId = context.GetArgument<int?>("id");
                   if (LibroId.HasValue)
                   {
                       var res = _context.Libros.Where(l => l.Id == LibroId).ToListAsync();
                       return res;
                   }

                   return _context.Libros.ToListAsync();

               }

        );

        }
    }
}