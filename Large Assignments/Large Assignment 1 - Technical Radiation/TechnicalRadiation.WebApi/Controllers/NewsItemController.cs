using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechnicalRadiation.Models.Exceptions;
using TechnicalRadiation.Models.InputModels;

namespace TechnicalRadiation.WebApi.Controllers {

  /// <summary>
  /// Used to manipulate and get information about news items
  /// </summary>
  [Route ("api/newsitems")]
  [ApiController]
  [Authorize]
  public class NewsItemController : ControllerBase {

    /// <summary>
    /// Gets all news items
    /// </summary>
    /// <returns>A list of news items</returns>
    [Produces ("application/json")]
    [ProducesResponseType(200)]
    [HttpGet]
    [Route ("")]
    [AllowAnonymous]
    public IActionResult GetAllNewsItems () {
      // TODO 
      return null;
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
    [AllowAnonymous]
    public IActionResult GetNewsItemById (int newsItemId) {
      // TODO
      return null;
    }

    /// <summary>
    /// Creates a new news item within the system
    /// </summary>
    /// <param name="model">The news item input model</param>
    /// <returns>A status code of 201 and a set Location header.</returns>
    [ProducesResponseType(201)]
    [ProducesResponseType(412)]
    [HttpPost]
    public void CreateNewsItem ([FromBody] NewsItemInputModel model) {
      if (!ModelState.IsValid) { throw new InputFormatException("News item was not properly formatted."); }
      // TODO  
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
    public void EditNewsItem (int newsItemId, [FromBody] NewsItemInputModel model) {
      if (!ModelState.IsValid) { throw new InputFormatException("News item was not properly formatted."); }
      // TODO 

    }

    /// <summary>
    /// Deletes a news item from the system
    /// </summary>
    /// <param name="id">Id which is associated with a news item within the system</param>
    /// <returns>A status code of 204 no content.</returns>
    [ProducesResponseType(204)]
    [HttpDelete ("{id}")]
    public void DeleteNewsItem (int newsItemId) {
      // TODO
    }
  }
}