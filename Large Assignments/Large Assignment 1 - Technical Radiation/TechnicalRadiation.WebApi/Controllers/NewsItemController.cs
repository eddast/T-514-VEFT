using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechnicalRadiation.Common;
using TechnicalRadiation.Models.DTO;
using TechnicalRadiation.Models.Exceptions;
using TechnicalRadiation.Models.InputModels;
using TechnicalRadiation.Services.Interfaces;
using TechnicalRadiation.WebApi.Authorization;


namespace TechnicalRadiation.WebApi.Controllers {

  /// <summary>
  /// Used to manipulate and get information about news items
  /// </summary>
  [Route (Routes.BASE)]
  [Authorize(Policy = "HasSharedKey")]
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
    /// Gets a page of a list all news items
    /// </summary>
    /// <param name="pageNumber">Which page to request, defaults to 1</param>
    /// <param name="pageSize">How many news items to request per page, defaults to 25</param>
    /// <returns>Status code 200 and a list of news items</returns>
    [HttpGet]
    [Route (Routes.NEWS_ITEM)]
    [Produces ("application/json")]
    [ProducesResponseType (200, Type = typeof(Envelope<NewsItemDto>))]
    [AllowAnonymous]
    public IActionResult GetAllNewsItems([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 25)
    {
      return Ok(_newsItemService.GetAllNewsItems(pageNumber, pageSize));
    }

    /// <summary>
    /// Gets news item by id
    /// </summary>
    /// <param name="id">Id which is associated with a news item within the system</param>
    /// <returns>A single news item if found</returns>
    [HttpGet]
    [Route ("{id:int}", Name = "GetNewsItemById")]
    [Produces ("application/json")]
    [ProducesResponseType(200, Type = typeof(NewsItemDetailDto))]
    [ProducesResponseType(404)]
    [AllowAnonymous]
    public IActionResult GetNewsItemById(int id)
    {
      return Ok(_newsItemService.GetNewsItemById(id));
    }

    /// <summary>
    /// Creates a new news item within the system
    /// </summary>
    /// <param name="newsItem">The news item input model</param>
    /// <returns>A status code of 201 created and a set Location header if model is correctly formatted, otherwise 412.</returns>
    /// <response code="201">Created</response>
    /// <response code="412">Precondition failed</response>
    [HttpPost]
    [Route (Routes.NEWS_ITEM)]
    [Consumes ("application/json")]
    [ProducesResponseType (201)]
    [ProducesResponseType (412)]
    public IActionResult CreateNewsItem([FromBody] NewsItemInputModel newsItem)
    {
      if (!ModelState.IsValid) { throw new InputFormatException("News item was not properly formatted."); }
      // TODO!!!
      return Ok();
      // ATH Á AÐ RETURNA LOCATION HEADER, s.s. return CreatedAtRoute("GetNewsItemById", new { id }, null);
    }

    /// <summary>
    /// Updates a news item within the system
    /// </summary>
    /// <param name="newsItemId">Id which is associated with a news item within the system</param>
    /// <param name="newsItem">The news item input model</param>
    /// <returns>A status code of 204 no content.</returns>
    /// <response code="204">No Content</response>
    /// <response code="412">Precondition failed</response>
    [HttpPut ("{newsItemId:int}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(412)]
    public IActionResult EditNewsItem(int newsItemId, [FromBody] NewsItemInputModel newsItem)
    {
      if (!ModelState.IsValid) { throw new InputFormatException("News item was not properly formatted."); }
      // TODO!!!
      return NoContent();
    }

    /// <summary>
    /// Deletes a news item from the system
    /// </summary>
    /// <param name="id">Id which is associated with a news item within the system</param>
    /// <returns>A status code of 204 no content.</returns>
    /// <response code="204">No Content</response>
    /// <response code="412">Precondition failed</response>
    [HttpDelete ("{id:int}")]
    [ProducesResponseType (204)]
    public IActionResult DeleteNewsItem(int id)
    {
      // TODO!!!
      return NoContent();
    }
  }
}