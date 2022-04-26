using GitAssessment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
