using FastEndpoints;

namespace ErrorHandlingDemo.Swagger.Groups
{
    public class PostGroup : Group
    {
        public PostGroup() 
        {
            Configure(
            "posts",
            ep =>
            {
                ep.Description(
                    x =>
                    {
                        x.Produces(400)
                        .WithTags("posts");
                        x.Produces(200)
                        .WithTags("posts");
                    });

            }
            );
        }
    }
}
