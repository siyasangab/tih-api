using System.ComponentModel.DataAnnotations;

namespace GitAssessment.Domain.Dto.Request
{
    public class SubmitSentenceDto
    {
        [Required]
        public string Value { get; set; }
    }
}
