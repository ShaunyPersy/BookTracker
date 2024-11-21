using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components.Web;

namespace API.DTOs {
    public class BookUpdateDto {
        [Required]  
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string Status { get; set; }
        
        public int? Rating { get; set; }
        public int? Page { get; set; }
    }
}