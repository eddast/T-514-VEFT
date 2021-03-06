using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using TechnicalRadiation.Models.DTO;
using TechnicalRadiation.Models.Entities;
using TechnicalRadiation.Models.InputModels;
using TechnicalRadiation.Repositories.Data;
using TechnicalRadiation.Repositories.Data.Interfaces;
using TechnicalRadiation.Repositories.Interfaces;

namespace TechnicalRadiation.Repositories
{
    /// <summary>
    /// Gets author data from data provider
    /// </summary>
    public class AuthorRepository : IAuthorRepository
    {
        /// <summary>
        /// Data provider to use to get authors
        /// </summary>
        private readonly IAuthorDataProvider _dataProvider;

        /// <summary>
        /// Initiate data provider
        /// </summary>
        /// <param name="dataProvider">the author data provider to use</param>
        public AuthorRepository(IAuthorDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        /// <summary>
        /// Gets all authors from data provider
        /// </summary>
        /// <returns>List of all authors</returns>
        public IEnumerable<AuthorDto> GetAllAuthors() =>
            Mapper.Map<IEnumerable<AuthorDto>>(_dataProvider.GetAllAuthors());

        /// <summary>
        /// Gets a single author by their Id from data provider
        /// </summary>
        /// <param name="id">Id associated with author to get</param>
        /// <returns>A single author by id or throws not found error</returns>
        public AuthorDetailDto GetAuthorById(int id) =>
            Mapper.Map<AuthorDetailDto>(_dataProvider.GetAllAuthors().FirstOrDefault(a => a.Id == id));
        
        /// <summary>
        /// Creates new author and adds to data
        /// </summary>
        /// <param name="author">author to add to data</param>
        /// <returns>the id of the new author</returns>
        public int CreateAuthor(AuthorInputModel author)
        {
            // Get highest id in list and add one to ensure unique id
            var authors = _dataProvider.GetAllAuthors();
            var newAuthorId = authors.OrderByDescending(item => item.Id).First().Id + 1;
            var newAuthor = Mapper.Map<Author>(author);
            newAuthor.Id = newAuthorId;
            authors.Add(newAuthor);
            return newAuthorId;
        }

        /// <summary>
        /// Updates author by id
        /// </summary>
        /// <param name="category">new author values to set to old author</param>
        /// <param name="id">id of author to update</param>
        public void UpdateAuthorById(AuthorInputModel author, int id)
        {
            // Update properties for entity model
            var oldAuthor = _dataProvider.GetAllAuthors().FirstOrDefault(a => a.Id == id);
            oldAuthor.Name = author.Name;
            oldAuthor.ProfileImgSource = author.ProfileImgSource;
            oldAuthor.Bio = author.Bio;
            oldAuthor.ModifiedBy = "SystemAdmin";
            oldAuthor.ModifiedDate = DateTime.Now;
        }

        /// <summary>
        /// Deletes author from system
        /// </summary>
        /// <param name="id">the id of the author to delete from system</param>
        public void DeleteAuthorById(int id)
        {
            var authors = _dataProvider.GetAllAuthors();
            var toRemove = authors.FirstOrDefault(a => a.Id == id);
            authors.Remove(toRemove);
        }
    }
}