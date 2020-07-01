using GraphQL.Types;

namespace DemoODataVideo.GraphQL.Types
{
    public class AutoresType : ObjectGraphType<Autores>
    {
        public AutoresType()
        {
            Field(x => x.Id);
            Field(x => x.Nombre).Description("Nombre del autor");
            Field(x => x.Nacionalidad);

        }
    }
}
