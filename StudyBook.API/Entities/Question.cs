namespace StudyBook.API.Entities
{
    public class Question
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public List<Answer> Answers { get; set; } = new List<Answer>();
        public int TestId { get; set; }
        public Test Test { get; set; }
    }
}
