using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechnicalRadiation.Models.Exceptions;
using TechnicalRadiation.Models.InputModels;
using TechnicalRadiation.WebApi.Authorization;
using TechnicalRadiation.Services.Interfaces;

namespace TechnicalRadiation.WebApi.Controllers {

  /// <summary>
  /// Used to manipulate and get information about categories
  /// </summary>
  [Route ("api/categories")]
  [HasAuthorizationHeader]
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
    /// Gets list of all categories
    /// </summary>
    /// <returns>all categories in system</returns>
    [HttpGet]
    [Route ("")]
    [Produces ("application/json")]
    [ProducesResponseType (200)]
    [AllowAnonymous]
    public IActionResult GetAllCategories ()
    {
      return Ok(_categoryService.GetAllCategories());
    }

    /// <summary>
    /// Gets a single category by it's id
    /// </summary>
    /// <param name="id">id of category to find</param>
    /// <returns>a single category if found</returns>
    [HttpGet]
    [Route ("{id}", Name = "GetCategoryById")]
    [Produces ("application/json")]
    [ProducesResponseType (200)]
    [ProducesResponseType (404)]
    [AllowAnonymous]
    public IActionResult GetCategoryById (int id)
    {
      return Ok(_categoryService.GetCategoryById(id));
    }

    /// <summary>
    /// Creates a new category for the system
    /// </summary>
    /// <param name="category">The category input model</param>
    ///<returns>A status code of 201 and a set Location header if model is correctly formatted, otherwise 412.</returns>
    [HttpPost]
    [Consumes ("application/json")]
    [ProducesResponseType (201)]
    [ProducesResponseType (412)]
    public IActionResult CreateCategory ([FromBody] CategoryInputModel category) {
      if (!ModelState.IsValid) { throw new InputFormatException("Category input model was not properly formatted."); }
      // TODO
      return Ok();  
    }

    /// <summary>
    /// Edits an existing category within the system
    /// </summary>
    /// <param name="id">Id which is associated with a category within the system</param>
    /// <param name="category">The category input model</param>
    /// <returns>A status code of 200 if input model is valid</returns>
    [HttpPut]
    [Route ("{id}")]
    [Consumes ("application/json")]
    [ProducesResponseType (200)]
    [ProducesResponseType (412)]
    public IActionResult EditCategory (int id, [FromBody] CategoryInputModel category) {
      if (!ModelState.IsValid) { throw new InputFormatException("Category input model was not properly formatted."); }
      // TODO
      return Ok(); 
    }

    /// <summary>
    /// Assigns category to news item
    /// </summary>
    /// <param name="categoryId">Id which is associated with a category within the system</param>
    /// <param name="newsItemId">Id which is associated with a news item within the system</param>
    /// <param name="category"></param>
    [HttpPut]
    [Route ("{categoryId}/newsItems/{newsItemId}")]
    [Consumes ("application/json")]
    [ProducesResponseType (201)]
    [ProducesResponseType (412)]
    public IActionResult LinkCategoryToNewsItem (int categoryId, int newsItemId, [FromBody] CategoryInputModel category) {
      if (!ModelState.IsValid) { throw new InputFormatException("Category input model was not properly formatted."); }
      // TODO 
      return Ok();
    }

    /// <summary>
    /// Deletes a category within the system
    /// </summary>
    /// <param name="id">Id which is associated with a category within the system</param>
    /// <returns>A status code of 204 no content.</returns>
    [HttpDelete]
    [Route ("{id}")]
    [ProducesResponseType (204)]
    public IActionResult DeleteCategory (int id) {
      // TODO
      return NoContent();
    }
  }
}