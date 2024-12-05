using System.Collections.Generic;
using System.Linq;
using API.Models;

namespace API.Services {
    class MySqlAPIRepo : IApiRepo
    {
        private readonly APIContext _context;

        public MySqlAPIRepo(APIContext context){
            _context = context;
            System.Console.WriteLine(_context);
        }
        public IEnumerable<Book> GetAllBooks()
        {
            Console.WriteLine("Fetching all books...");
            return _context.Book.ToList();
        }

        public Book GetBookById(int ID) {
            return _context.Book.FirstOrDefault(p => p.Id == ID);
        }

        public void AddBook(Book book){
            _context.Book.Add(book);
        }

        public void UpdateBook(Book book)
        {
        }

        public void DeleteBook(Book book){
            _context.Book.Remove(book);
        }

        public int SaveChanges(){
            return _context.SaveChanges();
        }
    }
}