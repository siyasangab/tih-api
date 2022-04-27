namespace GitAssessment.Domain.Entities
{
    public class Word : BaseEntity
    {
        public string Title { get; set; }
        public long WordTypeId { get; set; }
        public virtual WordType WordType { get; set; }
    }
}
