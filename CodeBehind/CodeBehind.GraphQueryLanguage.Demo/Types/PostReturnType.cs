using GraphQL.Types;
using GraphQueryLanguage.Demo.Models;

namespace GraphQueryLanguage.Demo.Types
{
    public class PostReturnType : ObjectGraphType<PostReturn>
    {
        public PostReturnType()
        {
            Name = "PostReturn";
            Field(x => x.Id, type: typeof(IdGraphType)).Description("Id cliente");
            Field(x => x.Status);
        }
    }
}
