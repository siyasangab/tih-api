using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitAssessment.Domain.Dto.Request
{
    public class SubmitSentenceDto
    {
        [Required]
        public string Value { get; set; }
    }
}
