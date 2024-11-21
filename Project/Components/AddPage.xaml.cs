using Project.Components.AddBook;

namespace Project.Components.AddPage;

public partial class AddPage : ContentPage
{
    AddBookViewModel vm;
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
}