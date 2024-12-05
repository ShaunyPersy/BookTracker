using Project.Components.AddBook;

namespace Project.Components.AddPage;

public partial class AddPage : ContentPage
{
    AddBookViewModel vm;
    public static List<int> RatingValues => new() { 1, 2, 3, 4, 5 };

    public AddPage()
	{
		InitializeComponent();
        BindingContext = vm = new AddBookViewModel();
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

        var success = await vm.AddBookAsync();

        if (success)
        {
            await Navigation.PopAsync();
        }
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
}