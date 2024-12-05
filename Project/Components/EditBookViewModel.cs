using Project.Components.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Components.EditBook
{
    internal class EditBookViewModel
    {
        private readonly ApiDataStore apiDataStore;
        public Book Book { get; set; }
        public EditBookViewModel(Book selectedBook)
        {
            Book = selectedBook;
            apiDataStore = new ApiDataStore();
        }

        public async Task OnSave()
        {
            await apiDataStore.UpdateBookAsync(Book);
        }

        public async Task onDelete()
        {
            await apiDataStore.RemoveBookAsync(Book.id);
        }
    }
}
