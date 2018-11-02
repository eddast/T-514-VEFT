using System;

namespace CleanThatCode.Community.Models.Dtos
{
    public class PostDto
    {
        // Id of the post
        public int Id { get; set; }
        // The title of the post
        public string Title { get; set; }
        // The author which created the post
        public string Author { get; set; }
        // Actual post message
        public string Message { get; set; }
        // When the post was created
        public DateTime Created { get; set; }
        // Determines how many likes this post has received
        public int NumberOfLikes { get; set; }
    }
}