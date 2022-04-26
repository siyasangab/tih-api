using GitAssessment.Domain.Dto.Request;
using GitAssessment.Domain.Dto.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitAssessment.Services.Domain.Sentences
{
    public interface ISentencesService
    {
        Task<IEnumerable<SentenceDto>> GetAll();

        Task<SentenceDto> Submit(SubmitSentenceDto submitSentence);
    }
}
