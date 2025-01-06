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
}