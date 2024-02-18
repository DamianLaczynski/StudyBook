using System.ComponentModel.DataAnnotations;

namespace StudyBook.API.Entities
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public List<FlashcardSet> FlashcardSets { get; set; }
        public List<Test> Tests { get; set; } = new List<Test>();
    }
}
