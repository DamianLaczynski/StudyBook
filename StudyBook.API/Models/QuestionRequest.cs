namespace StudyBook.API.Models
{
    public class QuestionRequest
    {
        public int? Id { get; set; }
        public string Content { get; set; }
        public List<AnswerRequest> Answers { get; set; } = new List<AnswerRequest>();
    }
}