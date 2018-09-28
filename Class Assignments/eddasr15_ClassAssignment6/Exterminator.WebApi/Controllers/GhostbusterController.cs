using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exterminator.Models.Exceptions;
using Exterminator.Models.InputModels;
using Exterminator.Services.Interfaces;
using Exterminator.WebApi.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Exterminator.WebApi.Controllers
{
    [Route("api/ghostbusters")]
    public class GhostbusterController : Controller
    {
        private readonly IGhostbusterService _ghostbusterService;

        public GhostbusterController(IGhostbusterService ghostbusterService)
        {
            _ghostbusterService = ghostbusterService;
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetAllGhostbusters(string expertize = "") => Ok(_ghostbusterService.GetAllGhostbusters(expertize));

        [HttpGet]
        [Route("{id:int}", Name = "GetGhostbusterById")]
        public IActionResult GetGhostbusterById(int id) => Ok(_ghostbusterService.GetGhostbusterById(id));

        [HttpPost]
        [Route("")]
        public IActionResult CreateGhostbuster([FromBody] GhostbusterInputModel ghostbuster)
        {
            if (!ModelState.IsValid) { throw new ModelFormatException(ModelState.RetrieveErrorString()); }
            var newId = _ghostbusterService.CreateGhostbuster(ghostbuster);
            return CreatedAtRoute("GetGhostbusterById", new { id = newId }, null);
        }
    }
}
