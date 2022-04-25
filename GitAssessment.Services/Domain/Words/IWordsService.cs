using GitAssement.Domain.Dto.Response;

namespace GitAssessment.Services.Domain.Words
{
    public interface IWordsService
    {
        Task<IEnumerable<WordDto>> GetByWordType(long wordTypeId);
    }
}
