using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitAssessment.Domain.Entities
{
    public class Word: BaseEntity
    {
        public string Title { get; set; }
        public long WordTypeId { get; set; }
        public virtual WordType WordType { get; set; }
    }
}
