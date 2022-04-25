using Microsoft.AspNetCore.Mvc;

namespace GitAssement.Api.Controllers
{
    [Route("api/word-types")]
    [ApiController]
    public class WordTypesController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> List()
        {
            return Ok();
        }
    }
}
