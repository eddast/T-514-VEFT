using System;
using System.Collections.Generic;

namespace CleanThatCode.Community.Models.Entities
{
    public class Post
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

        // Navigation property which provides a list of comments associated with the post
        public virtual IEnumerable<Comment> Comments { get; set; }
    }
}