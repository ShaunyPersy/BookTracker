using Microsoft.AspNetCore.Components.Web;

namespace API.DTOs {
    public class BookReadDto {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Status { get; set; }
        public int? Rating { get; set; }
        public int? Page { get; set; }
    }
}