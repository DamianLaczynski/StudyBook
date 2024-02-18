﻿namespace StudyBook.API.Entities
{
    public class Test
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

        public List<Question> Questions { get; set; } = new List<Question>();
    }
}
