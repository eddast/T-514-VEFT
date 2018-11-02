using System;
using System.Collections.Generic;
using CleanThatCode.Community.Models.Entities;

namespace CleanThatCode.Community.Repositories.Data
{
    // A fake dbcontext
    public class CleanThatCodeDbContext : ICleanThatCodeDbContext
    {
        public IEnumerable<Comment> Comments {
            get 
            {
                return new List<Comment>
                {
                    new Comment
                    {
                        Id = 1,
                        PostId = 1,
                        Author = "Mum-Ra",
                        Message = "Muhahah! Lion-O, having troubles with for-loops.. what a n00b.",
                        Created = DateTime.Parse("08/12/2016 10:00:07")
                    },
                    new Comment
                    {
                        Id = 2,
                        PostId = 1,
                        Author = "Lion-O",
                        Message = "Mum-Ra! Stop trying to make me feel like a joke! I am not scared of you! I just wanted to know how for-loops work....",
                        Created = DateTime.Parse("08/14/2016 13:22:15")
                    },
                    new Comment
                    {
                        Id = 3,
                        PostId = 2,
                        Author = "Bowser",
                        Message = "Mario! Recurse this! public void CapturePeach() { CapturePeach(); }",
                        Created = DateTime.Parse("12/22/2017 22:21:08")
                    },
                    new Comment
                    {
                        Id = 4,
                        PostId = 2,
                        Author = "Luigi",
                        Message = "Bowser.. Mario is currently on vacation in Hawaii and won't be responding to this non-sense...",
                        Created = DateTime.Parse("12/22/2017 22:55:41")
                    },
                    new Comment
                    {
                        Id = 5,
                        PostId = 2,
                        Author = "Peach",
                        Message = "And i'm with him.. So Bowser.. Nice try..",
                        Created = DateTime.Parse("12/23/2017 12:36:09")
                    }
                };
            }
        }
        public IEnumerable<Post> Posts {
            get
            {
                return new List<Post>
                {
                    new Post
                    {
                        Id = 1,
                        Title = "Help with for-loops in C#",
                        Author = "Lion-O",
                        Message = "My fellow cats, I am having troubles with looping through a list in C# using for-loops. Could anyone point me in the right direction?",
                        Created = DateTime.Parse("08/11/2016 11:17:04"),
                        NumberOfLikes = 5
                    },
                    new Post
                    {
                        Id = 2,
                        Title = "Hawaii-Mario!",
                        Author = "Mario",
                        Message = "I'm currently @ Hawaii, having the time of my life! I started thinking about recursion and just can't quite wrap my head around it. Can anyone provide a simple explanation on recursion?",
                        Created = DateTime.Parse("12/22/2017 16:44:24"),
                        NumberOfLikes = 10
                    }
                };
            }
        }
    }
}