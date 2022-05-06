using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace examCreator.Models
{
    public class Question
    {
        [Key]
        public Guid QuestionId { get; set; }
        [Required]
        public string? QuestionText { get; set; }
        [Required]
        public string? Option1 { get; set; }
        [Required]
        public string? Option2 { get; set; }
        [Required]
        public string? Option3 { get; set; }
        [Required]
        public string? Option4 { get; set; }
        [Required]
        public string? TrueOption { get; set; }

        public Guid ExamId { get; set; }

        [ForeignKey("ExamId")]
        public Exam? Exam { get; set; }

    }
}
