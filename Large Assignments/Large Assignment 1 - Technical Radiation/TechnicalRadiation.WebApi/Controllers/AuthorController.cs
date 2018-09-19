using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechnicalRadiation.Models.InputModels;

namespace TechnicalRadiation.WebApi.Controllers {
  [Route ("api/categories")]
  [ApiController]
  [Authorize]
  public class AuthorController : ControllerBase {

    // GET api
    [Produces ("application/json")]
    [HttpGet]
    [Route ("")]
    [AllowAnonymous]
    public IActionResult GetAllAuthors () {
      // TODO 
      return null;
    }

    // GET api/categories/5
    [Produces ("application/json")]
    [HttpGet]
    [Route ("{authorId}")]
    [AllowAnonymous]
    public IActionResult GetAuthorById (int authorId) {
      // TODO
      return null;
    }

    // POST api/categories
    [HttpPost]
    public void CreateAuthor ([FromBody] CategoryInputModel model) {
      if (!ModelState.IsValid) { /* TODO */ }
      // TODO  
    }

    // PUT api/categories/5
    [HttpPut ("{authorId}")]
    public void EditAuthor (int authorId, [FromBody] CategoryInputModel model) {
      if (!ModelState.IsValid) { /* TODO */ }
      // TODO 
    }

    // PUT api/categories/5
    [HttpPut ("{authorId}/newsItems/{newsItemId}")]
    public void LinkAuthorToNewsItem (int authorId, int newsItem, [FromBody] CategoryInputModel model) {
      if (!ModelState.IsValid) { /* TODO */ }
      // TODO 
    }

    // DELETE api/categories/5
    [HttpDelete ("{authorId}")]
    public void DeleteAuthor (int authorId) {
      // TODO
    }
  }
}