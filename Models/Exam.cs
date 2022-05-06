namespace examCreator.Models
{
    public class Exam
    {
        public Guid ExamId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
