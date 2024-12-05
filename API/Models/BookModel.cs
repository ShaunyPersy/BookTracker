using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models {
    [Table("books")]
    public class Book{
        public int Id {get; set;}
        public string Title { get; set; }
        public string Author { get; set; }
        public string Status { get; set; }
        public int? Rating { get; set; }
        public int? Page { get; set; }
    }
}