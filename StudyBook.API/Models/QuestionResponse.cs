namespace StudyBook.API.Models
{
    public class QuestionResponse
    {
        public int? Id { get; set; }
        public string Content { get; set; }
        public List<AnswerResponse> Answers { get; set; } = new List<AnswerResponse>();
    }
}