using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechnicalRadiation.Models.InputModels;

namespace TechnicalRadiation.WebApi.Controllers {
  [Route ("api/")]
  [ApiController]
  [Authorize]
  public class NewsItemController : ControllerBase {

    // GET api unauthenticated
    [Produces ("application/json")]
    [HttpGet]
    [Route ("")]
    [AllowAnonymous]
    public IActionResult GetAllNewsItems () {
      // TODO 
      return null;
    }

    // GET api/values/5
    [Produces ("application/json")]
    [HttpGet]
    [Route ("{id}")]
    [AllowAnonymous]
    public IActionResult GetNewsItemById (int id) {
      // TODO
      return null;
    }

    // POST api/values
    [HttpPost]
    public void CreateNewsItem ([FromBody] NewsItemInputModel model) {
      if (!ModelState.IsValid) { /* TODO */ }
      // TODO  
    }

    // PUT api/5
    [HttpPut ("{id}")]
    public void EditNewsItem (int id, [FromBody] NewsItemInputModel model) {
      if (!ModelState.IsValid) { /* TODO */ }
      // TODO 

    }

    // DELETE api/5
    [HttpDelete ("{id}")]
    public void DeleteNewsItem (int id) {
      // TODO
    }
  }
}