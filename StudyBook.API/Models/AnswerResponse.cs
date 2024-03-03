namespace StudyBook.API.Models
{
    public class AnswerResponse
    {
        public int? Id { get; set; }
        public string Content { get; set; }
        public bool IsCorrect { get; set; }
    }
}