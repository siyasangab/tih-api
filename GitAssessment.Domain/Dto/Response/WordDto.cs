using GitAssessment.Domain.Entities;

namespace GitAssement.Domain.Dto.Response
{
    public class WordDto
    {
        public WordDto() { }
        public WordDto(Word word)
        {
            Id = word.Id;
            Title = word.Title;
        }

        public long Id { get; set; }
        public string Title { get; set; }
    }
}
