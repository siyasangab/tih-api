using GitAssessment.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GitAssessment.Domain.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Word> Words { get; set; }

        public DbSet<WordType> WordTypes { get; set; }

        public DbSet<Sentence> Sentences { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var wordTypes = new List<WordType>()
            {
                new WordType() { Id = 1, Name = "Noun" },
                new WordType() { Id = 2, Name = "Verb" },
                new WordType() { Id = 3, Name = "Adjective" },
                new WordType() { Id = 4, Name ="Adverb" },
                new WordType() { Id = 5, Name ="Pronoun" },
                new WordType() { Id = 6, Name ="Preposition" },
                new WordType() { Id = 7, Name ="Conjunction" },
                new WordType() { Id = 8, Name ="Determiner" },
                new WordType() { Id = 9, Name="Exclamation" }
            };

            modelBuilder.Entity<WordType>().HasData(wordTypes);

            var words = new List<Word>();

            using (var reader = new StreamReader(Path.Join("SeedData", "Nouns.txt")))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    words.Add(new Word()
                    {
                        Id = words.Count + 1,
                        Title = line,
                        WordTypeId = 1
                    });
                }
            }
            using (var reader = new StreamReader(Path.Join("SeedData", "Verbs.txt")))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    words.Add(new Word()
                    {
                        Id = words.Count + 1,
                        Title = line,
                        WordTypeId = 2
                    });
                }
            }

            using (var reader = new StreamReader(Path.Join("SeedData", "Adjectives.txt")))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    words.Add(new Word()
                    {
                        Id = words.Count + 1,
                        Title = line,
                        WordTypeId = 3
                    });
                }
            }

            using (var reader = new StreamReader(Path.Join("SeedData", "Adverbs.txt")))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    words.Add(new Word()
                    {
                        Id = words.Count + 1,
                        Title = line,
                        WordTypeId = 4
                    });
                }
            }

            using (var reader = new StreamReader(Path.Join("SeedData", "Pronouns.txt")))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    words.Add(new Word()
                    {
                        Id = words.Count + 1,
                        Title = line,
                        WordTypeId = 5
                    });
                }
            }

            using (var reader = new StreamReader(Path.Join("SeedData", "Prepositions.txt")))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    words.Add(new Word()
                    {
                        Id = words.Count + 1,
                        Title = line,
                        WordTypeId = 6
                    });
                }
            }

            using (var reader = new StreamReader(Path.Join("SeedData", "Conjunctions.txt")))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    words.Add(new Word()
                    {
                        Id = words.Count + 1,
                        Title = line,
                        WordTypeId = 7
                    });
                }
            }

            using (var reader = new StreamReader(Path.Join("SeedData", "Determiners.txt")))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    words.Add(new Word()
                    {
                        Id = words.Count + 1,
                        Title = line,
                        WordTypeId = 8
                    });
                }
            }

            using (var reader = new StreamReader(Path.Join("SeedData", "Exclamations.txt")))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    words.Add(new Word()
                    {
                        Id = words.Count + 1,
                        Title = line,
                        WordTypeId = 9
                    });
                }
            }

            modelBuilder.Entity<Word>().HasData(words);

            base.OnModelCreating(modelBuilder);
        }
    }
}
