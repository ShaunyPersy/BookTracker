using System.Diagnostics;
using System.Text;
using System.Text.Json;

namespace Project.Components.Db
{
    class ApiDataStore
    {
        private readonly HttpClient httpClient;
        public List<Book> books { get; set; }

        public ApiDataStore() {
            books = new List<Book>();
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:8000/");
        }

        public async Task<List<Book>> GetBooksAsync()
        {
            var response = await httpClient.GetAsync("api/books");
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                Debug.WriteLine($"Response JSON: {jsonString}"); 
                var books = JsonSerializer.Deserialize<List<Book>>(jsonString);

                return books;
            }
            else
            {
                Debug.WriteLine("Request failed.");
            }

            return null;
        }

        public async Task RefreshBooksAsync()
        {
            books.Clear();
            var refreshedBooks = await GetBooksAsync();
            if (refreshedBooks != null)
            {
                books.AddRange(refreshedBooks);
            }
        }

        public async Task<bool> AddBookAsync(Book newBook)
        {
            var jsonContent = JsonSerializer.Serialize(newBook);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("api/books", content);

            if (response.IsSuccessStatusCode)
            {
                Debug.WriteLine("Book added successfully.");
                return true;
            }
            else
            {
                Debug.WriteLine("Failed to add book.");
                return false;
            }
        }

        public async Task<bool> UpdateBookAsync(Book book)
        {
            var jsonContent = JsonSerializer.Serialize(book);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await httpClient.PutAsync($"api/books/{book.id}", content);

            if (response.IsSuccessStatusCode)
            {
                Debug.WriteLine($"Book with ID {book.id} updated successfully.");
                return true;
            }
            else
            {
                Debug.WriteLine($"Failed to update book with ID {book.id}. Status Code: {response.StatusCode}");
                return false;
            }
        }
        public async Task<bool> RemoveBookAsync(int ID)
        {
            var response = await httpClient.DeleteAsync($"api/books/{ID}");

            if (response.IsSuccessStatusCode)
            {
                Debug.WriteLine($"Book with ID {ID} removed successfully.");
                return true;
            }
            else
            {
                Debug.WriteLine($"Failed to remove book with ID {ID}. Status Code: {response.StatusCode}");
                return false;
            }
        }
    }
}
