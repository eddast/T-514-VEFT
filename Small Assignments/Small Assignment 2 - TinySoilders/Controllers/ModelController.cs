using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using template.Data;
using template.Extensions;
using template.Models;

/**
* API functionality of tiny soldiers API
* Gives read access to tiny soldiers models resources
*/
namespace TinySoilders.Controllers
{
    /**
     * Tiny Soldier API base route: http://localhost:5000/api/soldiers
     */
    [Route("api/soldiers")]
    public class ModelController : Controller
    {
        [HttpGet] 
        [Route("")]
        /**
         * Gets all soldier models from API at http://localhost:5000/api/soldiers [GET]
         *
         * Accepts paging-related configurations as query parameters (page size and page number)
         * (if not provided, page number is set to 1 and page size to 10)
         */
        public IActionResult GetAllModels([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            /* extract accept language if provided as header in request - defaults to en-US */
            String acceptLanguage = Request.Headers["Accept-Language"].ToString();
            acceptLanguage = acceptLanguage == "" ? "en-US" : acceptLanguage;

            /* get list of all soldier models from data context */
            List<ModelDTO> allModels = DataContext.Models.ToLightWeight(acceptLanguage);

            /* add links for all resources to link to details on themself for HATEOS */
            String route = HttpContext.Request.Host.ToString() + Request.Path;
            allModels.ForEach(model => model.Links.AddReference("self", route + "/" + model.Id));

            /* page data appropriately - extract soldiers only for page and page size requested */
            IEnumerable<ModelDTO> items = allModels.Skip((pageNumber-1)*pageSize).Take(pageSize);

            /* format response in envelope structure appropriately */
            Envelope<ModelDTO> actionResponse = new Envelope<ModelDTO>();
            actionResponse.Items = items;
            actionResponse.PageNumber = pageNumber;
            actionResponse.PageSize = pageSize;
            actionResponse.MaxPages = (int) Math.Ceiling(((double)allModels.Count) / ((double)pageSize));

            /* respond to user with data as envelope */
            return Ok(actionResponse);
        }

        [HttpGet] 
        [Route("{id:int}")]
        /**
         * Gets single soldier model from API by id at http://localhost:5000/api/soldiers/{id} [GET]
         * 
         * Accepts URL parameter id to get model by id
         */
        public IActionResult GetModelById(int id)
        {
            /* extract accept language if provided as header in request - defaults to en-US */
            String acceptLanguage = Request.Headers["Accept-Language"].ToString();
            acceptLanguage = acceptLanguage == "" ? "en-US" : acceptLanguage;

            /* get requested model by id from model list from data context */
            ModelDetailsDTO model = DataContext.Models.ToDetails(acceptLanguage).FirstOrDefault(soldier => soldier.Id == id);

            /* add links resource to themself for HATEOS */
            String route = HttpContext.Request.Host.ToString() + Request.Path;
            model.Links.AddReference("self", route);

            /* return either 404 (not found) if model with given id was not in data context or 200 (OK) with encountered model */
            if (model == null) return NotFound();
            return Ok(model);
        }
    }
}