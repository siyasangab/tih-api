using GitAssessment.Domain.Dto.Request;
using GitAssessment.Services.Domain.Sentences;
using Microsoft.AspNetCore.Mvc;

namespace GitAssessment.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SentencesController : ControllerBase
    {
        private readonly ISentencesService sentencesService;

        public SentencesController(ISentencesService sentencesService)
        {
            this.sentencesService = sentencesService;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var sentences = await sentencesService.GetAll();

            return Ok(sentences);
        }

        [HttpPost]
        public async Task<IActionResult> Submit([FromBody] SubmitSentenceDto submitSentence)
        {
            var dto = await sentencesService.Submit(submitSentence);

            return Ok(dto);
        }
    }
}
