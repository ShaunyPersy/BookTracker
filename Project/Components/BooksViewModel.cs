using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Project.Components.Db;

namespace Project.Components
{
    internal class BooksViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Book> _books;
        public ObservableCollection<Book> Books
        {
            get => _books;
            set
            {
                _books = value;
                OnPropertyChanged();
            }
        }

        private readonly ApiDataStore apiDataStore;

        public BooksViewModel()
        {
            apiDataStore = new ApiDataStore();
            Books = new ObservableCollection<Book>();
        }

        public async Task LoadBooksAsync()
        {
            try
            {
                var _books = await apiDataStore.GetBooksAsync();
                if (_books != null)
                {
                    Books.Clear();
                    foreach (var book in _books)
                    {
                        Books.Add(book);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error loading books: {ex.Message}");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
