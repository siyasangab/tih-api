using GitAssessent.Domain.Dto.Response;
using GitAssessment.Domain.Context;
using GitAssessment.Services.Caching;
using Microsoft.EntityFrameworkCore;

namespace GitAssessment.Services.Domain.WordTypes
{
    public class WordTypeService : IWordTypesService
    {
        private readonly AppDbContext appDbContext;
        private readonly ICacheService cacheService;

        public WordTypeService(AppDbContext appDbContext, ICacheService cacheService)
        {
            this.appDbContext = appDbContext;
            this.cacheService = cacheService;
        }

        public async Task<IEnumerable<WordTypeDto>> GetAll()
        {
            var cacheKey = "getall_wordtypes";

            var cached = await cacheService.Get<List<WordTypeDto>>(cacheKey);

            if (cached?.Any() ?? false)
            {
                return cached;
            }

            var wordTypes = await appDbContext.WordTypes.Select(x => new WordTypeDto(x)).ToListAsync();

            await cacheService.Set<List<WordTypeDto>>(cacheKey, wordTypes);

            return wordTypes;
        }
    }
}
