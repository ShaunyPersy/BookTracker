using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Components.AddBook
{
    internal class AddBookViewModel
    {
        public Book Book { get; set; }

        public AddBookViewModel() {
            Book = new Book();
        }   
    }
}
