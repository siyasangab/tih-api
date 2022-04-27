using GitAssessment.Domain.Dto.Request;
using GitAssessment.Domain.Dto.Response;

namespace GitAssessment.Services.Domain.Sentences
{
    public interface ISentencesService
    {
        Task<IEnumerable<SentenceDto>> GetAll();

        Task<SentenceDto> Submit(SubmitSentenceDto submitSentence);
    }
}
