namespace StudyBook.API.Models
{
    public class FlashcardRequest
    {
        public int? Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}