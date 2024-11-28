using Microsoft.AspNetCore.Mvc;
using ReadingtonTech.Models.Interfaces;
using ReadingtonTech.Services.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace ReadingtonTech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProbabilityController : Controller
    {
        private readonly IProbabilityService _probabilityService;

        public ProbabilityController(IProbabilityService probabilityService)
        {
            this._probabilityService = probabilityService;
        }

        // POST: api//Combine
        [HttpPost("Combine")]
        [ProducesResponseType(typeof(decimal), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<ActionResult> Combine(decimal? a, decimal? b)
        {
            IProbabilityOutput output = await _probabilityService.Combined(a, b);

            if (!output.isValid)
            {
                return BadRequest(output.errorReason);
            }

            return Ok(output.result);
        }

        // POST: api//Either
        [HttpPost("Either")]
        [ProducesResponseType(typeof(decimal), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<ActionResult> Either(decimal? a, decimal? b)
        {
            IProbabilityOutput output = await _probabilityService.Either(a, b);

            if (!output.isValid)
            {
                return BadRequest(output.errorReason);
            }

            return Ok(output.result);
        }
    }
}
