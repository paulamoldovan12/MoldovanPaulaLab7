using MoldovanPaulaLab7.Models;

namespace MoldovanPaulaLab7;

public partial class CoffeePage : ContentPage
{
    CoffeeList cl;
    public CoffeePage(CoffeeList clist)
    {
        InitializeComponent();
        cl = clist;
    }

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var coffee = (Coffee)BindingContext;
        await App.Database.SaveCoffeeAsync(coffee);
        listView.ItemsSource = await App.Database.GetCoffeesAsync();
    }

    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var coffee = listView.SelectedItem as Coffee;
        await App.Database.DeleteCoffeeAsync(coffee);
        listView.ItemsSource = await App.Database.GetCoffeesAsync();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        listView.ItemsSource = await App.Database.GetCoffeesAsync();
    }

    async void OnAddButtonClicked(object sender, EventArgs e)
    {

        Coffee c;
        if (listView.SelectedItem != null)
        {
            c = listView.SelectedItem as Coffee;
            var lc = new ListCoffee()
            {
                CoffeeListID = cl.ID,
                CoffeeID = c.ID
            };
            await App.Database.SaveListCoffeeAsync(lc);
            c.ListCoffees = new List<ListCoffee> { lc };

            await Navigation.PopAsync();
        }

    }
}