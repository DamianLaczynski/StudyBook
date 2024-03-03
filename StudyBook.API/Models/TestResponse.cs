namespace StudyBook.API.Models
{
    public class TestResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        public List<QuestionResponse> Questions { get; set; } = new List<QuestionResponse>();
    }
}
