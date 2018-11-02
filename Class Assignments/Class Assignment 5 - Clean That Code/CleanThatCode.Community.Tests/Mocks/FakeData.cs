using System;
using System.Collections.Generic;
using CleanThatCode.Community.Models.Entities;

namespace CleanThatCode.Community.Tests.Mocks
{
    public static class FakeData
    {
        public static IEnumerable<Post> Posts
        {
            get
            {
                return new List<Post>
                {
                    new Post
                    {
                        Id = 1,
                        Title = "Thundercats Unite!",
                        Author = "Lion-O",
                        Message = "My fellow cats, good job on the last mission were we took care of that old guy Mum-Ra. I will be waiting for you guys at the cave.",
                        Created = new DateTime(),
                        NumberOfLikes = 5
                    },
                    new Post
                    {
                        Id = 2,
                        Title = "Castle Grayskull is open for business",
                        Author = "He-Man",
                        Message = "Business hasn't been booming, so I've deciced to turn Castle Grayskull to a hotel and is currently open for business!",
                        Created = new DateTime(),
                        NumberOfLikes = 112
                    },
                    new Post
                    {
                        Id = 3,
                        Title = "Castle Grayskull has been closed for business.....",
                        Author = "He-Man",
                        Message = "Skeletor has ruined me.......",
                        Created = new DateTime(),
                        NumberOfLikes = 1
                    },
                    new Post
                    {
                        Id = 4,
                        Title = "Beetlejuice 2 is out",
                        Author = "Warner Bros.",
                        Message = "Beetlejuice 2 is now out! All original cast!",
                        Created = new DateTime(),
                        NumberOfLikes = 992
                    }
                };
            }
        }

        public static IEnumerable<Comment> Comments
        {
            get
            {
                return new List<Comment>
                {
                    new Comment
                    {
                        Id = 1,
                        PostId = 1,
                        Author = "Mum-Ra",
                        Message = "I will eventually get you Lion-O! Just you wait.... Just you wait!",
                        Created = new DateTime()
                    },
                    new Comment
                    {
                        Id = 2,
                        PostId = 1,
                        Author = "Lion-O",
                        Message = "Mum-Ra! You have been trying for years without success. I am not scared of you!",
                        Created = new DateTime()
                    }
                };
            }
        }
    }
}