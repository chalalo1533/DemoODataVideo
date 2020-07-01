using DemoODataVideo.GraphQL.Queries;
using GraphQL;
using GraphQL.Types;

namespace DemoODataVideo.GraphQL.SchemaGraph
{
    public class BiblioSchema : Schema
    {
        public BiblioSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<LibroQuery>();
            Mutation = resolver.Resolve<Mutacion>();
        }
    }
}
