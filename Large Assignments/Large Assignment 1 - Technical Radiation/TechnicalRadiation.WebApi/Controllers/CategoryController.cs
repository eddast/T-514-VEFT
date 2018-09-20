using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechnicalRadiation.Models.InputModels;
using TechnicalRadiation.WebApi.Authorization;

namespace TechnicalRadiation.WebApi.Controllers {
  [Route ("api/categories")]
  [ApiController]
  [HasAuthorizationHeader]
  public class CategoryController : ControllerBase {

    // GET api
    [Produces ("application/json")]
    [HttpGet]
    [Route ("")]
    [AllowAnonymous]
    public IActionResult GetAllCategories () {
      // TODO 
      return null;
    }

    // GET api/categories/5
    [Produces ("application/json")]
    [HttpGet]
    [Route ("{categoryId}")]
    [AllowAnonymous]
    public IActionResult GetCategoryById (int categoryId) {
      // TODO
      return null;
    }

    // POST api/categories
    [HttpPost]
    public void CreateCategory ([FromBody] CategoryInputModel model) {
      if (!ModelState.IsValid) { /* TODO */ }
      // TODO  
    }

    // PUT api/categories/5
    [HttpPut ("{categoryId}")]
    public void EditCategory (int categoryId, [FromBody] CategoryInputModel model) {
      if (!ModelState.IsValid) { /* TODO */ }
      // TODO 
    }

    // PUT api/categories/5
    [HttpPut ("{categoryId}/newsItems/{newsItemId}")]
    public void LinkCategoryToNewsItem (int categoryId, int newsItemId, [FromBody] CategoryInputModel model) {
      if (!ModelState.IsValid) { /* TODO */ }
      // TODO 
    }

    // DELETE api/categories/5
    [HttpDelete ("{categoryId}")]
    public void DeleteCategory (int categoryId) {
      // TODO
    }
  }
}