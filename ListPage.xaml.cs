using MoldovanPaulaLab7.Models;

namespace MoldovanPaulaLab7;

public partial class ListPage : ContentPage
{
	public ListPage()
	{
		InitializeComponent();
	}

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var clist = (CoffeeList)BindingContext;
        clist.Date = DateTime.UtcNow;
        await App.Database.SaveCoffeeListAsync(clist);
        await Navigation.PopAsync();
    }

    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var clist = (CoffeeList)BindingContext;
        await App.Database.DeleteCoffeeListAsync(clist);
        await Navigation.PopAsync();
    }

    async void OnChooseButtonClicked(object sender, EventArgs e)
    {

        await Navigation.PushAsync(new CoffeePage((CoffeeList)
            this.BindingContext)
        {
            BindingContext = new Coffee()
        });

    }

    async void OnDeleteItemButtonClicked(object sender, EventArgs e)
    {
        var selectedCoffee = listView.SelectedItem as Coffee;

        if (selectedCoffee != null)
        {
            await App.Database.DeleteCoffeeAsync(selectedCoffee);

            var coffeeList = (CoffeeList)this.BindingContext;
            listView.ItemsSource = await App.Database.GetListCoffeesAsync(coffeeList.ID);
        }
        else
        {
            await DisplayAlert("Eroare", "Selectati un produs pentru a-l sterge.", "OK");
        }
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        var coffeel = (CoffeeList)BindingContext;

        listView.ItemsSource = await App.Database.GetListCoffeesAsync(coffeel.ID);
    }
}