using GitAssessment.Domain.Entities;

namespace GitAssessment.Domain.Dto.Response
{
    public class SentenceDto
    {
        public SentenceDto(Sentence sentence)
        {
            this.Value = sentence.Value;
        }
        public string Value { get; set; }
    }
}
