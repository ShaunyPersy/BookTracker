using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Components.EditBook
{
    internal class EditBookViewModel
    {
        public Book Book { get; set; }
        public EditBookViewModel(Book selectedBook) => Book = selectedBook;
    }
}
