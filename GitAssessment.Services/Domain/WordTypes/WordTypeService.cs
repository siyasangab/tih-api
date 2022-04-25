
using GitAssessment.Domain.Context;
using Microsoft.EntityFrameworkCore;

namespace GitAssement.Services.Domain.WordTypes
{
    public class WordTypeService : IWordTypesService
    {
        private readonly AppDbContext appDbContext;

        public WordTypeService(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
    }
}
