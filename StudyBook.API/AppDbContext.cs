using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using StudyBook.API.Entities;
using StudyBookAPI.Entities;

public class AppDbContext : IdentityDbContext<User>
{
    protected readonly IConfiguration Configuration;

    public AppDbContext(IConfiguration configuration, DbContextOptions<AppDbContext> options) : base(options)
    {
        Configuration = configuration;
    }
    DbSet<Subject> Subjects { get; set; }
    DbSet<FlashcardSet> FlashcardSets { get; set; }
    DbSet<Flashcard> Flashcards { get; set; }
    DbSet<Test> Tests { get; set; }
    DbSet<Question> Questions { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Subject>(eb =>
        {
            eb.HasMany(s => s.FlashcardSets)
                .WithOne(fs => fs.Subject)
                .HasForeignKey(fs => fs.SubjectId)
                .OnDelete(DeleteBehavior.Cascade);

            eb.HasMany(s => s.Tests)
            .WithOne(t => t.Subject)
            .HasForeignKey(t => t.SubjectId)
            .OnDelete(DeleteBehavior.Cascade);
        });
        modelBuilder.Entity<FlashcardSet>(eb =>
        {
            eb.HasMany(fs => fs.Flashcards)
                .WithOne(f => f.FlashcardSet)
                .HasForeignKey(f => f.FlashcardSetId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Test>(eb =>
        {
            eb.HasMany(t => t.Questions)
                .WithOne(q => q.Test)
                .HasForeignKey(q => q.TestId)
                .OnDelete(DeleteBehavior.Cascade);
        });
        modelBuilder.Entity<Question>(eb =>
        { 
            eb.HasMany(q => q.Answers)
                .WithOne(a => a.Question)
                .HasForeignKey(a => a.QuestionId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(Configuration["ConnectionStrings:StudyBookApiDatabase"]);
    }
}