using MoldovanPaulaLab7.Models;

namespace MoldovanPaulaLab7;

public partial class WarehousePage : ContentPage
{
	public WarehousePage()
	{
		InitializeComponent();
	}

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var warehouse = (Warehouse)BindingContext;
        await App.Database.SaveWarehouseAsync(warehouse);
        await Navigation.PopAsync();
    }

    async void OnShowMapButtonClicked(object sender, EventArgs e)
    {
        var warehouse = (Warehouse)BindingContext;
        var address = warehouse.Adress;
        //var locations = await Geocoding.GetLocationsAsync(address);

        var options = new MapLaunchOptions
        {
            Name = "Depozitul de cafea" };

        //var warehouselocation = locations?.FirstOrDefault();
        var warehouselocation= new Location(46.7504397, 23.60114477); //pentru Windows Machine 

        await Map.OpenAsync(warehouselocation, options);
    }
}