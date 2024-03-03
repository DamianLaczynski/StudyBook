namespace StudyBook.API.Models
{
    public class AnswerRequest
    {
        public int? Id { get; set; }
        public string Content { get; set; }
        public bool IsCorrect { get; set; }
    }
}