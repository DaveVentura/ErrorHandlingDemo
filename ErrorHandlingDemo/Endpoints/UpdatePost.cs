using ErrorHandlingDemo.Contracts;
using ErrorHandlingDemo.Model;
using ErrorHandlingDemo.Services;
using ErrorHandlingDemo.Swagger.Groups;
using FastEndpoints;

namespace ErrorHandlingDemo.Endpoints
{
    public class UpdatePost : Endpoint<PostUpdateRequest, Post>
    {
        private readonly PostService postService;
        public UpdatePost(PostService postService)
        {
            this.postService = postService;
        }

        public override void Configure()
        {
            Patch("fast-posts/{id}");
            AllowAnonymous();
            //Group<PostGroup>();
        }

        public override Task<Post> HandleAsync(PostUpdateRequest postRequest, CancellationToken token)
        {
            Console.WriteLine(postRequest.Query);
            return Task.FromResult(postService.Update(new Post { Title = postRequest.Title, Content = postRequest.Content }));
        }
    }
}
