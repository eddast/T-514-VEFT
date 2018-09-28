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
using TechnicalRadiation.Models.DTO;
using TechnicalRadiation.Common;

namespace TechnicalRadiation.WebApi.Controllers {

  /// <summary>
  /// Used to manipulate and get information about categories
  /// </summary>
  [Route (Routes.BASE + Routes.CATEGORIES)]
  [Authorize(Policy = "HasSharedKey")]
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
    [ProducesResponseType (200, Type = typeof(IEnumerable<CategoryDto>))]
    [AllowAnonymous]
    public IActionResult GetAllCategories()
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
    [ProducesResponseType (200, Type = typeof(CategoryDetailDto))]
    [ProducesResponseType (404)]
    [AllowAnonymous]
    public IActionResult GetCategoryById(int id)
    {
      return Ok(_categoryService.GetCategoryById(id));
    }

    /// <summary>
    /// Creates a new category for the system
    /// </summary>
    /// <param name="category">The category input model</param>
    ///<returns>A status code of 201 and a set Location header if model is correctly formatted, otherwise 412.</returns>
    /// <response code="201">Created</response>
    /// <response code="412">Precondition failed</response>
    [HttpPost]
    [Consumes ("application/json")]
    [ProducesResponseType (201)]
    [ProducesResponseType (412)]
    public IActionResult CreateCategory([FromBody] CategoryInputModel category)
    {
      if (!ModelState.IsValid) { throw new InputFormatException("Category input model was not properly formatted."); }
      int id = _categoryService.CreateCategory(category);
      return CreatedAtRoute("GetCategoryById", new { id }, null);
    }

    /// <summary>
    /// Edits an existing category within the system
    /// </summary>
    /// <param name="id">Id which is associated with a category within the system</param>
    /// <param name="category">The category input model</param>
    /// <returns>A status code of 204 no content if input model is valid</returns>
    /// <response code="204">No Content</response>
    /// <response code="412">Precondition Failed</response>
    /// <response code="404">Not Found</response>
    [HttpPut]
    [Route ("{id}")]
    [Consumes ("application/json")]
    [ProducesResponseType (204)]
    [ProducesResponseType (412)]
    [ProducesResponseType (404)]
    public IActionResult EditCategory(int id, [FromBody] CategoryInputModel category)
    {
      if (!ModelState.IsValid) { throw new InputFormatException("Category input model was not properly formatted."); }
      _categoryService.UpdateCategoryById(category, id);
      return NoContent();
    }

    /// <summary>
    /// Deletes a category within the system
    /// </summary>
    /// <param name="id">Id which is associated with a category within the system</param>
    /// <returns>A status code of 204 no content.</returns>
    /// <response code="204">No Content</response>
    /// <response code="404">Not Found</response>
    [HttpDelete]
    [Route ("{id}")]
    [ProducesResponseType (204)]
    [ProducesResponseType (404)]
    public IActionResult DeleteCategory(int id)
    {
      _categoryService.DeleteCategoryById(id);
      return NoContent();
    }

    /// <summary>
    /// Assigns category to news item
    /// </summary>
    /// <param name="categoryId">Id which is associated with a category within the system</param>
    /// <param name="newsItemId">Id which is associated with a news item within the system</param>
    /// <returns>A status code of 204 no content if input model is valid</returns>
    /// <response code="204">No Content</response>
    /// <response code="204">Not Found</response>
    [HttpPatch]
    [Route ("{categoryId}/newsItems/{newsItemId}")]
    [Consumes ("application/json")]
    [ProducesResponseType (204)]
    [ProducesResponseType (404)]
    public IActionResult LinkCategoryToNewsItem(int categoryId, int newsItemId)
    {
      _categoryService.LinkNewsItemToCategory(categoryId, newsItemId);
      return NoContent();
    }
  }
}