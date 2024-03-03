namespace StudyBook.API.Models
{
    public class FlashcardSetRequest
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public List<FlashcardRequest> Flashcards { get; set; } = new List<FlashcardRequest>();
    }
}
