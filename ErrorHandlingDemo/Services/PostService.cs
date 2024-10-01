using ErrorHandlingDemo.Model;
using System.ComponentModel.DataAnnotations;
using LanguageExt.Common;

namespace ErrorHandlingDemo.Services
{
    public class PostService(ILogger<PostService> logger)
    {
        private readonly ILogger<PostService> _logger = logger;
        public Post Create(Post post)
        {
            post.Id = Guid.NewGuid().ToString();
            _logger.LogInformation(post.Content);

            ValidatePostAndThrow(post);

            return post;
        }

        public Post Update(Post post) 
        {
            throw new NotImplementedException();
        }

        private void ValidatePostAndThrow(Post post)
        {
            var isValid = false;

            if (!isValid)
            {
                throw new ValidationException("Invalid post");
            }
        }

        private Post Validate(Post post) {
            var isValid = false;
            if (!isValid)
            {
                throw new ValidationException("Invalid post");
            }
            return post;
        }
    }

}
