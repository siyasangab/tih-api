using GitAssement.Domain.Dto.Response;
using GitAssessment.Domain.Context;
using Microsoft.EntityFrameworkCore;

namespace GitAssessment.Services.Domain.Words
{
    public class WordsService : IWordsService
    {
        private readonly AppDbContext appDbContext;

        public WordsService(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<IEnumerable<WordDto>> GetByWordType(long wordTypeId)
        {   
            var words = await appDbContext.Words          
                .Where(x => x.WordTypeId == wordTypeId)
                .OrderBy(x => x.Title)
                .Select(x => new WordDto(x))
                .ToListAsync();

            return words;
        }
    }
}
