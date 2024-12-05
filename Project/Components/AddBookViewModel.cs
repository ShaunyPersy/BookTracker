using Project.Components.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Project.Components.AddBook
{
    internal class AddBookViewModel
    {
        private readonly ApiDataStore apiDataStore;
        public Book Book { get; set; }

        public AddBookViewModel() {
            apiDataStore = new ApiDataStore();
            Book = new Book();
        }
        public async Task<bool> AddBookAsync()
        {
            var response = await apiDataStore.AddBookAsync(Book);
            return response;
        }
    }
}
