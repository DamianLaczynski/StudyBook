namespace StudyBook.API.Models
{
    public class TestRequest
    {
        public string Name { get; set; }
        public string? Description { get; set; }

        public List<QuestionRequest> Questions { get; set; } = new List<QuestionRequest>();
    }
}
