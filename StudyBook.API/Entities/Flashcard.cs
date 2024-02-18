namespace StudyBook.API.Entities
{
    public class Flashcard
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public int FlashcardSetId { get; set; }
        public FlashcardSet FlashcardSet { get; set; }
    }
}
