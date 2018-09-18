using System;
using System.Collections.Generic;
using CleanThatCode.Community.Models.Entities;
using CleanThatCode.Community.Repositories.Data;
using CleanThatCode.Community.Tests.Mocks;

/* MOCK db context */
namespace CleanThatCode.Community.Repositories.Data
{
    public class CleanThatCodeDBContextMock : ICleanThatCodeDbContext
    {
        public IEnumerable<Comment> Comments { get => FakeData.Comments; }

        public IEnumerable<Post> Posts { get => FakeData.Posts; }
    }
}