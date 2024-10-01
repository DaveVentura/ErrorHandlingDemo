using ErrorHandlingDemo.Contracts;
using ErrorHandlingDemo.Model;
using ErrorHandlingDemo.Services;
using ErrorHandlingDemo.Swagger.Groups;
using FastEndpoints;

namespace ErrorHandlingDemo.Endpoints
{
    public class CreatePost : Endpoint<PostCreateRequest, Post>
    {
        private readonly PostService postService;
        public CreatePost(PostService postService)
        {
            this.postService = postService;
            //Group<PostGroup>();
        }

        public override void Configure()
        {
            Post("fast-posts");
            AllowAnonymous();
        }

        public override Task<Post> HandleAsync(PostCreateRequest postRequest, CancellationToken token)
        {
            return Task.FromResult(postService.Create(new Post { Title = postRequest.Title, Content = postRequest.Content }));
        }
    }
}