using System;

namespace CleanThatCode.Community.Models.Entities
{
    public class Comment
    {
        // Id of the comment
        public int Id { get; set; }
        // Id of the post which is associated with this comment
        public int PostId { get; set; }
        // The author of the comment
        public string Author { get; set; }
        // The actual comment message
        public string Message { get; set; }
        // Creation date of the comment
        public DateTime Created { get; set; }

        // Navigation property which links this comment to a specific post
        public virtual Post Post { get; set; }
    }
}