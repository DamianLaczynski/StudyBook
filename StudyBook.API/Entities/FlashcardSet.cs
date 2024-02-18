using System.ComponentModel.DataAnnotations;

namespace StudyBook.API.Entities
{
    public class FlashcardSet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

        public List<Flashcard> Flashcards { get; set; } = new List<Flashcard>();
    }
}
