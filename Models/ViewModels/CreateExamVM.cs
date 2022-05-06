using Microsoft.AspNetCore.Mvc.Rendering;

namespace examCreator.Models.ViewModels
{
    public class CreateExamVM
    {
        public List<NewsContent>? NewsContentList { get; set; }
        public Exam? Exam { get; set; }
        public Question? Q1 { get; set; }
        public Question? Q2 { get; set; }
        public Question? Q3 { get; set; }
        public Question? Q4 { get; set; }
    }
}
