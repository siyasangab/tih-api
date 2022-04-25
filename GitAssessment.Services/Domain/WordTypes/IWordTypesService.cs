using GitAssessent.Domain.Dto.Response;

namespace GitAssessment.Services.Domain.WordTypes
{
    public interface IWordTypesService
    {
        Task<IEnumerable<WordTypeDto>> GetAll();
    }
}
