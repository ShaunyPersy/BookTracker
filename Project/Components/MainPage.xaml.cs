using Project.Components;
using Project.Components.AddPage;
using Project.Components.EditPage;

namespace Project
{
    public partial class MainPage : ContentPage
    {
        BooksViewModel vm;
        public MainPage()
        {
            InitializeComponent();
            BindingContext = vm = new BooksViewModel();
        }

        private async void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null && e.Item is Book selectedBook)
            {
                await Navigation.PushAsync(new EditPage(selectedBook));
            }
        }

        private async void OnAddBookClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddPage());
        }
    }

}
