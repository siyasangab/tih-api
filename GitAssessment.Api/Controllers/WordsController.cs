using GitAssessment.Services.Domain.Words;
using Microsoft.AspNetCore.Mvc;

namespace GitAssement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordsController : ControllerBase
    {
        private readonly IWordsService wordsService;

        public WordsController(IWordsService wordsService)
        {
            this.wordsService = wordsService;
        }

        [HttpGet]
        [Route("by-type")]
        [ResponseCache(Duration = 300, VaryByQueryKeys = new[] { "wordTypeId" })]
        public async Task<IActionResult> GetByType([FromQuery] long wordTypeId)
        {
            var words = await wordsService.GetByWordType(wordTypeId);

            return Ok(words);
        }
    }
}
