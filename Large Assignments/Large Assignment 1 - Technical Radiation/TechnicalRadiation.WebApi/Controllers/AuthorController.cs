using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechnicalRadiation.Models.DTO;
using TechnicalRadiation.Models.Exceptions;
using TechnicalRadiation.Models.InputModels;
using TechnicalRadiation.Services.Interfaces;
using TechnicalRadiation.WebApi.Authorization;

namespace TechnicalRadiation.WebApi.Controllers {

  /// <summary>
  /// Used to manipulate and get information about authors in system
  /// </summary>
  [Route ("api/authors")]
  // [HasAuthorizationHeader]  
  public class AuthorController : Controller {

    /// <summary>
    /// service used to fetch data
    /// </summary>
    private readonly IAuthorService _authorService;

    /// <summary>
    /// Set the news item service to use
    /// </summary>
    /// <param name="authorService">author service</param>
    public AuthorController(IAuthorService authorService)
    {
        _authorService = authorService;
    }

    /// <summary>
    /// Gets list of all authors
    /// </summary>
    /// <returns>a list of all authors</returns>
    [HttpGet]
    [Route ("")]
    [Produces ("application/json")]
    [ProducesResponseType (200, Type = typeof(IEnumerable<AuthorDto>))]
    [AllowAnonymous]
    public IActionResult GetAllAuthors ()
    {
      return Ok(_authorService.GetAllAuthors());
    }

    /// <summary>
    /// Gets an author by his or her id
    /// </summary>
    /// <param name="authorId">Id which is associated with author within the system</param>
    /// <returns>A single author if found, 404 otherwise</returns>
    [HttpGet]
    [Route ("{authorId}", Name = "GetAuthorById")]
    [Produces ("application/json")]
    [ProducesResponseType (200, Type = typeof(AuthorDetailDto))]
    [ProducesResponseType (404)]
    [AllowAnonymous]
    public IActionResult GetAuthorById (int authorId)
    {
      return Ok(_authorService.GetAuthorById(authorId));
    }

    /// <summary>
    /// Gets an author by his or her id
    /// </summary>
    /// <param name="authorId">Id which is associated with author within the system</param>
    /// <returns>A single author if found, 404 otherwise</returns>
    [HttpGet]
    [Route ("{authorId}/newsItems")]
    [Produces ("application/json")]
    [ProducesResponseType (200, Type = typeof(List<NewsItemDto>))]
    [ProducesResponseType (404)]
    [AllowAnonymous]
    public IActionResult GetNewsItemsByAuthor (int authorId)
    {
      return Ok(_authorService.GetNewsItemsByAuthor(authorId));
    }

    /// <summary>
    /// Creates new author for the system
    /// </summary>
    /// <param name="author">The author input model</param>
    /// <returns>A status code of 201 created and a set Location header if model is correctly formatted, otherwise 412.</returns>
    /// <response code="201">Created</response>
    /// <response code="412">Precondition failed</response>
    [HttpPost]
    [Consumes ("application/json")]
    [ProducesResponseType (201)]
    [ProducesResponseType (412)]
    public IActionResult CreateAuthor ([FromBody] AuthorInputModel author)
    {
      if (!ModelState.IsValid) { throw new InputFormatException("Author input model was not properly formatted."); }
      // TODO  
      return Ok();
    }

    /// <summary>
    /// Updates existing author within the system
    /// </summary>
    /// <param name="id">Id which is associated with an author within the system</param>
    /// <param name="author">The author input model</param>
    /// <returns>A status code of 204 no content if input model is valid, 412 otherwise</returns>
    /// <response code="204">No Content</response>
    /// <response code="412">Precondition failed</response>
    [HttpPut ("{id}")]
    [Consumes ("application/json")]
    [ProducesResponseType (204)]
    [ProducesResponseType (412)]
    public IActionResult EditAuthor (int id, [FromBody] AuthorInputModel author)
    {
      if (!ModelState.IsValid) { throw new InputFormatException("Author input model was not properly formatted."); }
      // TODO 
      return NoContent();
    }

    /// <summary>
    /// Links author to a news item with a specified category as well
    /// </summary>
    /// <param name="authorId">Id which is associated with an author within the system</param>
    /// <param name="newsItem">Id which is associated with a news item within the system</param>
    /// <returns>Status code of 204 no content</returns>
    /// <response code="204">No Content</response>
    [HttpPut ("{authorId}/newsItems/{newsItemId}")]
    [ProducesResponseType (204)]
    public IActionResult LinkAuthorToNewsItem (int authorId, int newsItem)
    {
      // TODO 
      return NoContent();
    }

    /// <summary>
    /// Deletes existing author from the system
    /// </summary>
    /// <param name="authorId">Id which is associated with an author within the system</param>
    /// <returns>A status code of 204 no content.</returns>
    /// <response code="204">No Content</response>
    [HttpDelete ("{authorId}")]
    [ProducesResponseType (204)]
    public IActionResult DeleteAuthor (int authorId)
    {
      // TODO
      return NoContent();
    }
  }
}