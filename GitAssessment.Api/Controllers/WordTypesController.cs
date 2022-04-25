using GitAssessment.Services.Domain.WordTypes;
using Microsoft.AspNetCore.Mvc;

namespace GitAssement.Api.Controllers
{
    [Route("api/word-types")]
    [ApiController]
    public class WordTypesController : ControllerBase
    {
        private readonly IWordTypesService wordTypesService;

        public WordTypesController(IWordTypesService wordTypesService)
        {
            this.wordTypesService = wordTypesService;
        }

        [HttpGet]
        [ResponseCache(Duration = 300)]
        public async Task<IActionResult> List()
        {
            var wordTypes = await wordTypesService.GetAll();

            return Ok(wordTypes);
        }
    }
}
