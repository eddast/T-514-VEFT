using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechnicalRadiation.Models.Exceptions;
using TechnicalRadiation.Models.InputModels;
using TechnicalRadiation.Services.Interfaces;
using TechnicalRadiation.WebApi.Authorization;


namespace TechnicalRadiation.WebApi.Controllers {

  /// <summary>
  /// Used to manipulate and get information about news items
  /// </summary>
  [Route ("api")]
  [HasAuthorizationHeader]
  [Authorize]
  public class NewsItemController : Controller
  {
    /// <summary>
    /// service used to fetch data
    /// </summary>
    private readonly INewsItemService _newsItemService;

    /// <summary>
    /// Set the news item service to use
    /// </summary>
    /// <param name="newsItemService">news item service</param>
    public NewsItemController(INewsItemService newsItemService)
    {
        _newsItemService = newsItemService;
    }
    
    /// <summary>
    /// Gets all news items
    /// </summary>
    /// <returns>A list of news items</returns>
    [HttpGet]
    [Route ("")]
    [Produces ("application/json")]
    [ProducesResponseType (200)]
    [AllowAnonymous]
    public IActionResult GetAllNewsItems ()
    {
      return Ok(_newsItemService.GetAllNewsItems());
    }

    /// <summary>
    /// Gets news item by id
    /// </summary>
    /// <param name="id">Id which is associated with a news item within the system</param>
    /// <returns>A single news item if found</returns>
    [HttpGet]
    [Route ("{id}", Name = "GetNewsItemById")]
    [Produces ("application/json")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [AllowAnonymous]
    public IActionResult GetNewsItemById (int id)
    {
      return Ok(_newsItemService.GetNewsItemById(id));
    }

    /// <summary>
    /// Creates a new news item within the system
    /// </summary>
    /// <param name="newsItem">The news item input model</param>
    /// <returns>A status code of 201 and a set Location header if model is correctly formatted, otherwise 412.</returns>
    [HttpPost]
    [Route("")]
    [Consumes ("application/json")]
    [ProducesResponseType (201)]
    [ProducesResponseType (412)]
    public IActionResult CreateNewsItem ([FromBody] NewsItemInputModel newsItem = null)
    {
      Console.WriteLine(!ModelState.IsValid);
      if (!ModelState.IsValid) { throw new InputFormatException("News item was not properly formatted."); }
      // TODO  
      return Ok();
    }

    /// <summary>
    /// Updates a news item within the system
    /// </summary>
    /// <param name="id">Id which is associated with a news item within the system</param>
    /// <param name="newsItem">The news item input model</param>
    /// <returns>A status code of 200 and a set Location header.</returns>
    [HttpPut ("{id}")]
    [ProducesResponseType(201)]
    [ProducesResponseType(412)]
    public IActionResult EditNewsItem (int id, [FromBody] NewsItemInputModel newsItem)
    {
      if (!ModelState.IsValid) { throw new InputFormatException("News item was not properly formatted."); }
      // TODO 
      return Ok();

    }

    /// <summary>
    /// Deletes a news item from the system
    /// </summary>
    /// <param name="id">Id which is associated with a news item within the system</param>
    /// <returns>A status code of 204 no content.</returns>
    [HttpDelete ("{id}")]
    [ProducesResponseType (204)]
    public IActionResult DeleteNewsItem (int id)
    {
      // TODO
      return NoContent();
    }
  }
}