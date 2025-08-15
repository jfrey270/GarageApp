using GarageApp.Core.Models;
using GarageApp.Core.Services;
using System;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace GarageApp.UI.Views
{
    public partial class AddVehiclePage : ContentPage
    {
        private readonly IVehicleService _vehicleService;

        public AddVehiclePage()
        {
            InitializeComponent();
            _vehicleService = App.Current?.Handler?.MauiContext?.Services.GetService(typeof(IVehicleService)) as IVehicleService;
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            var vehicle = new Vehicle
            {
                Name = NameEntry.Text,
                Make = MakeEntry.Text,
                Model = ModelEntry.Text,
                Year = int.TryParse(YearEntry.Text, out var year) ? year : 0,
                Color = ColorEntry.Text,
                Engine = EngineEntry.Text,
                VIN = VinEntry.Text,
                Miles = int.TryParse(MilesEntry.Text, out var miles) ? miles : null,
                PhotoPath = PhotoPathEntry.Text,
                TireSize = TireSizeEntry.Text
            };

            await _vehicleService.AddVehicleAsync(vehicle);
            await DisplayAlert("Success", "Vehicle added!", "OK");
            await Navigation.PopAsync();
        }
    }
}
