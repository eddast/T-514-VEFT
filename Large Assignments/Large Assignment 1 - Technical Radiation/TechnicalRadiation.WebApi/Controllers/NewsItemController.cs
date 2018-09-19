using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechnicalRadiation.Models.InputModels;

namespace TechnicalRadiation.WebApi.Controllers {
  [Route ("api")]
  [ApiController]
  [Authorize]
  public class NewsItemController : ControllerBase {

    // GET api
    [Produces ("application/json")]
    [HttpGet]
    [Route ("")]
    [AllowAnonymous]
    public IActionResult GetAllNewsItems () {
      // TODO 
      return null;
    }

    // GET api/5
    [Produces ("application/json")]
    [HttpGet]
    [Route ("{newsItemId}")]
    [AllowAnonymous]
    public IActionResult GetNewsItemById (int newsItemId) {
      // TODO
      return null;
    }

    // POST api
    [HttpPost]
    public void CreateNewsItem ([FromBody] NewsItemInputModel model) {
      if (!ModelState.IsValid) { /* TODO */ }
      // TODO  
    }

    // PUT api/5
    [HttpPut ("{newsItemId}")]
    public void EditNewsItem (int newsItemId, [FromBody] NewsItemInputModel model) {
      if (!ModelState.IsValid) { /* TODO */ }
      // TODO 

    }

    // DELETE api/5
    [HttpDelete ("{newsItemId}")]
    public void DeleteNewsItem (int newsItemId) {
      // TODO
    }
  }
}