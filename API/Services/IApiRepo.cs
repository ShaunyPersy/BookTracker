using API.Models;
using Microsoft.AspNetCore.Identity;

namespace API.Services {
    public interface IApiRepo{
        IEnumerable<Book> GetAllBooks();
        Book GetBookById(int ID);
        void AddBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(Book book);
        int SaveChanges();
    }
}