using GitAssessent.Domain.Dto.Response;
using GitAssessment.Domain.Context;
using Microsoft.EntityFrameworkCore;

namespace GitAssessment.Services.Domain.WordTypes
{
    public class WordTypeService : IWordTypesService
    {
        private readonly AppDbContext appDbContext;

        public WordTypeService(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<IEnumerable<WordTypeDto>> GetAll()
        {
            var wordTypes = await appDbContext.WordTypes.ToListAsync();

            return wordTypes.Select(x => new WordTypeDto(x));
        }
    }
}
