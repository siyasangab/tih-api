using GitAssessment.Domain.Context;
using GitAssessment.Domain.Dto.Request;
using GitAssessment.Domain.Dto.Response;
using GitAssessment.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GitAssessment.Services.Domain.Sentences
{
    public class SentencesService : ISentencesService
    {
        private readonly AppDbContext appDbContext;

        public SentencesService(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<IEnumerable<SentenceDto>> GetAll()
        {
            return await appDbContext.Sentences.Select(x => new SentenceDto(x)).ToListAsync();
        }

        public async Task<SentenceDto> Submit(SubmitSentenceDto submitSentence)
        {
            var sentence = new Sentence()
            {
                Value = submitSentence.Value,
            };

            await appDbContext.Sentences.AddAsync(sentence);

            await appDbContext.SaveChangesAsync();

            return new SentenceDto(sentence);
        }
    }
}
