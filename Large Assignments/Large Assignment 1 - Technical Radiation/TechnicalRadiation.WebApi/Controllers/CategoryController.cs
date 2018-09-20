using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechnicalRadiation.Models.InputModels;
using TechnicalRadiation.Services.Interfaces;

namespace TechnicalRadiation.WebApi.Controllers {

  /// <summary>
  /// Used to manipulate and get information about categories
  /// </summary>
  [Route ("api/categories")]
  [ApiController]
  [Authorize]
  public class CategoryController : Controller {

    /// <summary>
    /// service used to fetch data
    /// </summary>
    private readonly ICategoryService _categoryService;

    /// <summary>
    /// Set the category service to use
    /// </summary>
    /// <param name="categoryService">category service</param>
    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    

    /// <summary>
    /// Gets all categories in system
    /// </summary>
    /// <returns>all categories in system</returns>
    [Produces ("application/json")]
    [ProducesResponseType(200)]
    [HttpGet]
    [Route ("")]
    [AllowAnonymous]
    public IActionResult GetAllCategories () {
      // TODO 
      return Ok();
    }

    /// <summary>
    /// Gets category by id
    /// </summary>
    /// <param name="id">id of category to find</param>
    /// <returns>a single category if found</returns>
    [Produces ("application/json")]
    [ProducesResponseType(201)]
    [ProducesResponseType(412)]
    [HttpGet]
    [Route ("{id}")]
    [AllowAnonymous]
    public IActionResult GetCategoryById (int id) {
      // TODO
      return Ok();
    }

    /// <summary>
    /// Creates a category within the system
    /// </summary>
    /// <param name="category">The category input model</param>
    ///<returns>A status code of 201 and a set Location header if model is correctly formatted, otherwise 412.</returns>
    [HttpPost]
    public IActionResult CreateCategory ([FromBody] CategoryInputModel category) {
      if (!ModelState.IsValid) { /* TODO */ }
      // TODO
      return Ok();  
    }

    /// <summary>
    /// Edits a category item within the system
    /// </summary>
    /// <param name="id">Id which is associated with a category within the system</param>
    /// <param name="category">The category input model</param>
    /// <returns></returns>
    [HttpPut ("{id}")]
    [ProducesResponseType(201)]
    [ProducesResponseType(412)]
    public IActionResult EditCategory (int id, [FromBody] CategoryInputModel category) {
      if (!ModelState.IsValid) { /* TODO */ }
      // TODO
      return Ok(); 
    }

    /// <summary>
    /// Assigns category to news item
    /// </summary>
    /// <param name="categoryId">Id which is associated with a category within the system</param>
    /// <param name="newsItemId">Id which is associated with a news item within the system</param>
    /// <param name="model"></param>
    [ProducesResponseType(201)]
    [ProducesResponseType(412)]
    [HttpPut ("{categoryId}/newsItems/{newsItemId}")]
    public IActionResult LinkCategoryToNewsItem (int categoryId, int newsItemId, [FromBody] CategoryInputModel model) {
      if (!ModelState.IsValid) { /* TODO */ }
      // TODO 
      return Ok();
    }

    /// <summary>
    /// Deletes a category within the system
    /// </summary>
    /// <param name="id">Id which is associated with a category within the system</param>
    /// <returns>A status code of 204 no content.</returns>
    [HttpDelete ("{id}")]
    [ProducesResponseType(204)]
    public IActionResult DeleteCategory (int id) {
      // TODO
      return NoContent();
    }
  }
}