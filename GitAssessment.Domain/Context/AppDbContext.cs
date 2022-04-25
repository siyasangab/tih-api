using GitAssessment.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GitAssessment.Domain.Context
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Word> Words { get; set; }

        public DbSet<WordType> WordTypes { get; set; }

        public DbSet<Sentence> Sentences { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) { }
    }
}
