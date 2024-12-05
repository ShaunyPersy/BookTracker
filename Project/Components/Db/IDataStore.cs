using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Components.Db
{
    public interface IDataStore
    {
        List<Book> Books { get; set; }
        Task<List<Book>> GetBooksAsync();
        Task<bool> AddBookAsync(Book newBook);
        Task<bool> UpdateBookAsync(Book book);
        Task<bool> RemoveBookAsync(int ID);
    }
}
