namespace API.Models {
    public class Book{
        public int Id {get; set;}
        public string Title { get; set; }
        public string Author { get; set; }
        public string Status { get; set; }
        public int? Rating { get; set; }
        public int? Page { get; set; }
    }
}