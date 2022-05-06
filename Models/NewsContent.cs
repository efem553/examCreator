using System.ComponentModel.DataAnnotations.Schema;

namespace examCreator.Models
{
    [NotMapped]
    public class NewsContent
    {
        public string? NewsUrl { get; set; }
        public string? Header { get; set; }

        public string? Content { get; set; }
    }
}
