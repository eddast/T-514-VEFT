using System.Collections.Generic;
using AutoMapper;
using System.Linq;
using TechnicalRadiation.Models.DTO;
using TechnicalRadiation.Models.Entities;
using TechnicalRadiation.Models.Exceptions;
using TechnicalRadiation.Models.Extensions;
using TechnicalRadiation.Models.InputModels;
using TechnicalRadiation.Repositories.Interfaces;
using TechnicalRadiation.Services.Interfaces;

namespace TechnicalRadiation.Services.Implementations
{
    /// <summary>
    /// Gets author data from repository and conducts link relations for honoring HATEOAS
    /// </summary>
    public class AuthorService : IAuthorService
    {
        /// <summary>
        /// Author repositories
        /// </summary>
        private readonly IAuthorRepository _authorRepository;

        /// <summary>
        /// Author to news item relations repository
        /// </summary>
        private readonly IAuthorNewsItemRelationRepository _newsItemRelationRepository;

        /// <summary>
        /// Service, used to get news items for author
        /// </summary>
        private readonly INewsItemService _newsItemService;

        /// <summary>
        /// Initialize repository
        /// </summary>
        /// <param name="authorRepository">Which implementation of author repository to use</param>
        public AuthorService(IAuthorRepository authorRepository, IAuthorNewsItemRelationRepository newsItemRelationRepository, INewsItemService newsItemService)
        {
            _authorRepository = authorRepository;
            _newsItemRelationRepository = newsItemRelationRepository;
            _newsItemService = newsItemService;
        }

        /// <summary>
        /// Gets a list of all authors with appropriate link relations
        /// </summary>
        /// <returns>List of author dtos</returns>
        public IEnumerable<AuthorDto> GetAllAuthors()
        {
            var authors = _authorRepository.GetAllAuthors();
            foreach(var a in authors) a.AddReferences(a.Id, getNewsItems(a.Id));
            return authors;
        }
        
        /// <summary>
        /// Gets a single author by id with appropriate link relations, throws exception if author not found in system by id
        /// </summary>
        /// <param name="id">Id associated with some author in system</param>
        /// <returns>A single author detail dto</returns>
        public AuthorDetailDto GetAuthorById(int id) 
        {
            var author = _authorRepository.GetAuthorById(id);
            if (author == null) { throw new ResourceNotFoundException($"Author with id {id} was not found."); }
            author.AddReferences(author.Id, getNewsItems(author.Id));
            return author;
        }

        /// <summary>
        /// Gets a single author by id with appropriate link relations
        /// </summary>
        /// <param name="id">Id associated with some author in system</param>
        /// <returns>List of news items associated with author</returns>
        public IEnumerable<NewsItemDto> GetNewsItemsByAuthor(int id) 
        {
            // Fetch news items using the relational object we have then populate news item list
            IEnumerable<AuthorNewsItemRelation> relations = getNewsItems(id);
            ICollection<NewsItemDto> newsItemsByAuthor = new List<NewsItemDto>();
            foreach(var r in relations)
            {
                var newsItem = Mapper.Map<NewsItemDto>(_newsItemService.GetNewsItemById(r.NewsItemId));
                newsItemsByAuthor.Add(newsItem);
            }
            return newsItemsByAuthor;
        }

        /// <summary>
        /// Creates new author to system
        /// </summary>
        /// <param name="author">new author to add</param>
        /// <returns>the id of new author</returns>
        public int CreateAuthor(AuthorInputModel author) =>
            _authorRepository.CreateAuthor(author);

        /// <summary>
        /// Gets all relations of authors to news items by id
        /// </summary>
        /// <param name="Id">id of author to get news items for</param>
        /// <returns>all relations of authors to news items by id</returns>
        private IEnumerable<AuthorNewsItemRelation> getNewsItems(int Id) =>
            _newsItemRelationRepository.GetAllNewsItemsForAuthor(Id);

        /// <summary>
        /// Updates author by id
        /// </summary>
        /// <param name="author">new information on author to switch to</param>
        /// <param name="id">id of author to update</param>
        public void UpdateAuthorById(AuthorInputModel author, int id)
        {
            var oldAuthor = _authorRepository.GetAuthorById(id);
            if (oldAuthor == null) { throw new ResourceNotFoundException($"Author with id {id} was not found."); }
            _authorRepository.UpdateAuthorById(author, id);
        }

        /// <summary>
        /// Deletes author by id
        /// </summary>
        /// <param name="id">id of author to delete</param>
        public void DeleteAuthorById(int id)
        {
            // Check if author exists, if it does delete him or her from list
            var author = _authorRepository.GetAuthorById(id);
            if (author == null) { throw new ResourceNotFoundException($"Author with id {id} was not found."); }
            _authorRepository.DeleteAuthorById(id);

            // delete all relations from list associated with news item
            var newsItemRelations = _newsItemRelationRepository.GetAllNewsItemsForAuthor(id).ToList();
            foreach(var relation in newsItemRelations) _newsItemRelationRepository.DeleteRelation(relation);
        }

        /// <summary>
        /// Links a news item to author by their ids
        /// </summary>
        /// <param name="authorId">id of author to link to news item</param>
        /// <param name="newsItemId">id of news item to link to author</param>
        public void LinkNewsItemToAuthor(int authorId, int newsItemId)
        {
            // Check if author and news item exist by id
            GetAuthorById(authorId);
            _newsItemService.GetNewsItemById(newsItemId);

            // if no resource not found exception is thrown, add relation if it doesn't already exist
            var newRelation = new AuthorNewsItemRelation { AuthorId = authorId, NewsItemId = newsItemId };
            if(getNewsItems(authorId).Where(x => x.AuthorId == authorId && x.NewsItemId == newsItemId).Count() == 0){
                 _newsItemRelationRepository.AddRelation(newRelation);
            }
        }
    }
}