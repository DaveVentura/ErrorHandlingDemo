using FastEndpoints;

namespace ErrorHandlingDemo.Contracts
{
    public class PostUpdateRequest
    {
        
        public string Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        [QueryParam]
        public string Query { get; set; }

    }
}
