using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Components
{
    internal class BooksViewModel
    {
        public ObservableCollection<Book> Books { get; set; }
        public BooksViewModel()
        {
            Books = new ObservableCollection<Book>
        {
            new Book { Title = "To Kill a Mockingbird", Author = "Harper Lee", Status = "Completed", Rating = 5, Page = null },
            new Book { Title = "1984", Author = "George Orwell", Status = "Reading", Rating = null, Page = 187 },
            new Book { Title = "Moby-Dick", Author = "Herman Melville", Status = "Not Started", Rating = null, Page = null },
            new Book { Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Status = "Completed", Rating = 4, Page = null },
            new Book { Title = "War and Peace", Author = "Leo Tolstoy", Status = "Reading", Rating = null, Page = 512 },
            new Book { Title = "Pride and Prejudice", Author = "Jane Austen", Status = "Completed", Rating = 5, Page = null }
        };
        }
    }
}
