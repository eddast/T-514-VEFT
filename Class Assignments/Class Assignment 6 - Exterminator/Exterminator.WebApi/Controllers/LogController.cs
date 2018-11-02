using System.Collections.Generic;
using Exterminator.Models.Dtos;
using Exterminator.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Exterminator.WebApi.Controllers
{
    [Route("api/logs")]
    public class LogController : Controller
    {
        /// <summary>
        /// Log service to use to retrieve logs
        /// </summary>
        private readonly ILogService _logService;

        public LogController(ILogService logService)
        {
            _logService = logService;
        }

        /// <summary>
        /// Gets list of all logs
        /// </summary>
        /// <returns>a list of all logs</returns>
        [HttpGet]
        [Route ("")]
        [Produces ("application/json")]
        [ProducesResponseType (200, Type = typeof(IEnumerable<LogDto>))]
        public IActionResult GetAllLogs() =>
            Ok(_logService.GetAllLogs());
    }
}