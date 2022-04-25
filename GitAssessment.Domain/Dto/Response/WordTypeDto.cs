using GitAssessment.Domain.Entities;

namespace GitAssement.Domain.Dto.Response
{
    public class WordTypeDto
    {
        public WordTypeDto(WordType wordType)
        {
            Id = wordType.Id;
            Name = wordType.Name;
        }
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
