namespace StudyBook.API.Models
{
    public class SubjectResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        public List<FlashcardSetResponse> FlashcardSets { get; set; } = new List<FlashcardSetResponse>();

        public List<TestResponse> Tests { get; set; } = new List<TestResponse>();
    }
}
