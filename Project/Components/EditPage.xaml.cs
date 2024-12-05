
using Microsoft.Maui.Controls;
using Project.Components.EditBook;

namespace Project.Components.EditPage
{
    public partial class EditPage : ContentPage
    {
        EditBookViewModel vm;
        public EditPage(Book selectedBook)
        {
            InitializeComponent();
            BindingContext = vm = new EditBookViewModel(selectedBook);
        }

        private void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            var selectedStatus = (string)picker.SelectedItem;

            switch (selectedStatus)
            {
                case "Completed":
                    vm.Book.showPage = false;
                    vm.Book.page = null;
                    vm.Book.showRating = true;
                    break;
                case "Reading":
                    vm.Book.showPage = true;
                    vm.Book.showRating = false;
                    vm.Book.rating = null;
                    break;
                case "Not started":
                    vm.Book.showPage = false;
                    vm.Book.page = null;
                    vm.Book.showRating = false;
                    vm.Book.rating = null;
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

        private async void OnSave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(vm.Book.title) || string.IsNullOrWhiteSpace(vm.Book.author) || string.IsNullOrWhiteSpace(vm.Book.status))
            {
                await DisplayAlert("Validation Error", "Please fill in all fields (Title, Author, Status).", "OK");
                return;
            }

            await vm.OnSave();
            await Navigation.PopAsync();
        }

        private async void OnDelete(object sender, EventArgs e)
        {
            bool isConfirmed = await DisplayAlert("Confirm Delete", "Are you sure you want to delete this book?", "Yes", "No");

            if (isConfirmed)
            {
                await vm.onDelete();
                await Navigation.PopAsync();
            }
        }
    }
}