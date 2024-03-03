namespace StudyBook.API.Models
{
    public class FlashcardSetResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        public List<FlashcardResponse> Flashcards { get; set; } = new List<FlashcardResponse>();
    }
}
