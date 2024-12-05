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
        var slist = (ShopList)BindingContext;
        slist.Date = DateTime.UtcNow;
        await App.Database.SaveShopListAsync(slist);
        await Navigation.PopAsync();
    }

    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (ShopList)BindingContext;
        await App.Database.DeleteShopListAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnChooseButtonClicked(object sender, EventArgs e)
    {

        await Navigation.PushAsync(new ProductPage((ShopList) 
            this.BindingContext)
        {
            BindingContext = new Product()
        });
    }

    async void OnDeleteItemButtonClicked(object sender, EventArgs e)
    {
        var selectedProduct = listView.SelectedItem as Product;

        if (selectedProduct != null)
        {
            await App.Database.DeleteProductAsync(selectedProduct);

            var shopList = (ShopList)this.BindingContext;
            listView.ItemsSource = await App.Database.GetListProductsAsync(shopList.ID);
        }
        else
        {
            await DisplayAlert("Eroare", "Selecta?i un produs pentru a-l ?terge.", "OK");
        }
    }


    protected override async void OnAppearing()
    {
        base.OnAppearing();

        var shopl = (ShopList)BindingContext;

        listView.ItemsSource = await App.Database.GetListProductsAsync(shopl.ID);
    }
}