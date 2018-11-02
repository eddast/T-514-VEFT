using System;

namespace CleanThatCode.Community.Models.Dtos
{
    public class CommentDto
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
    }
}