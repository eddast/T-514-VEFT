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
  [Route ("api/newsitems")]
  [ApiController]
  [HasAuthorizationHeader]
  public class NewsItemController : Controller
  {
    private readonly INewsItemService _newsItemService;
    public NewsItemController(INewsItemService newsItemService)
    {
        _newsItemService = newsItemService;
    }

    /// <summary>
    /// Gets all news items
    /// </summary>
    /// <returns>A list of news items</returns>
    [Produces ("application/json")]
    [ProducesResponseType(200)]
    [HttpGet]
    [Route ("")]
    public IActionResult GetAllNewsItems ()
    {
      return Ok(_newsItemService.GetAllNewsItems());
    }

    /// <summary>
    /// Gets news item by id
    /// </summary>
    /// <param name="id">Id which is associated with a news item within the system</param>
    /// <returns>A single news item if found</returns>
    [Produces("application/json")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [HttpGet]
    [Route ("{id}", Name = "GetNewsItemById")]
    public IActionResult GetNewsItemById (int id)
    {
      var newsItem = _newsItemService.GetNewsItemById(id);
      return Ok(newsItem);
    }

    /// <summary>
    /// Creates a new news item within the system
    /// </summary>
    /// <param name="model">The news item input model</param>
    /// <returns>A status code of 201 and a set Location header.</returns>
    [ProducesResponseType(201)]
    [ProducesResponseType(412)]
    [HttpPost]
    [Route("")]
    [AllowAnonymous]
    public IActionResult CreateNewsItem ([FromBody] NewsItemInputModel model)
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
    /// <param name="model">The news item input model</param>
    /// <returns>A status code of 200 and a set Location header.</returns>
    [ProducesResponseType(201)]
    [ProducesResponseType(412)]
    [HttpPut ("{id}")]
    public IActionResult EditNewsItem (int id, [FromBody] NewsItemInputModel model)
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
    [ProducesResponseType(204)]
    [HttpDelete ("{id}")]
    public IActionResult DeleteNewsItem (int newsItemId)
    {
      // TODO
      return NoContent();
    }
  }
}