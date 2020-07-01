using GraphQL.Types;

namespace DemoODataVideo.GraphQL.Types
{
    public class AutoresInputType : InputObjectGraphType
    {
        public AutoresInputType()
        {
            Name = "AutoresInput";
            Field<NonNullGraphType<StringGraphType>>("Nombre").Description = "Nombre del Autor";
            Field<NonNullGraphType<StringGraphType>>("Nacionalidad").Description = "Nacionalidad del Autor";
        }

    }
}
