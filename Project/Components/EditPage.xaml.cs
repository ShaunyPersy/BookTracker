
using Microsoft.Maui.Controls;
using Project.Components.EditBook;

namespace Project.Components.EditPage
{
    public partial class EditPage : ContentPage
    {
        EditBookViewModel vm;
        public Command SaveBttn {  get; } 
        public EditPage(Book selectedBook)
        {
            InitializeComponent();
            BindingContext = vm = new EditBookViewModel(selectedBook);

            SaveBttn = new Command(EditBook);
        }
        private void EditBook()
        {

        }

        private void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            var selectedStatus = (string)picker.SelectedItem;

            switch (selectedStatus)
            {
                case "Completed":
                    vm.Book.ShowPage = false;
                    vm.Book.ShowRating = true;
                    break;
                case "Reading":
                    vm.Book.ShowPage = true;
                    vm.Book.ShowRating = false;
                    break;
                case "Not started":
                    vm.Book.ShowPage = false;
                    vm.Book.ShowRating = false;
                    break;
            }
        }

        private async void OnCancelButtonClicked(object sender, EventArgs e)
        {
            bool isConfirmed = await DisplayAlert("Confirm Cancel", "All unsaved changes will be lost. Proceed?", "Yes", "No");

            if (isConfirmed)
            {
                await Navigation.PopAsync();
            }
        }

        private async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            bool isConfirmed = await DisplayAlert("Confirm Delete", "Are you sure you want to delete this book?", "Yes", "No");

            if (isConfirmed)
            {
                //DeleteBook();
            }
        }
    }
}