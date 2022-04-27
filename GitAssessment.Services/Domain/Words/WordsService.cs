using GitAssement.Domain.Dto.Response;
using GitAssessment.Domain.Context;
using GitAssessment.Services.Caching;
using Microsoft.EntityFrameworkCore;

namespace GitAssessment.Services.Domain.Words
{
    public class WordsService : IWordsService
    {
        private readonly AppDbContext appDbContext;
        private readonly ICacheService cacheService;

        public WordsService(AppDbContext appDbContext, ICacheService cacheService)
        {
            this.appDbContext = appDbContext;
            this.cacheService = cacheService;
        }

        public async Task<IEnumerable<WordDto>> GetByWordType(long wordTypeId)
        {
            var cackeKey = $"words_by_wordtype:{wordTypeId}";

            var cached = await cacheService.Get<List<WordDto>>(cackeKey);

            if (cached?.Any() ?? false)
            {
                return cached;
            }

            var words = await appDbContext.Words
                .Where(x => x.WordTypeId == wordTypeId)
                .OrderBy(x => x.Title)
                .Select(x => new WordDto(x))
                .ToListAsync();

            await cacheService.Set<List<WordDto>>(cackeKey, words);

            return words;
        }
    }
}
