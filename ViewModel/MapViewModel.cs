using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GoogleMaps.Control;
using Microsoft.Maui.Controls.Maps;
using System.Collections.ObjectModel;

namespace GoogleMaps.ViewModel
{
    public partial class MapViewModel : BaseViewModel
    {

        public ObservableCollection<CustomPin> CustomPins { get; } = new();

        
        [RelayCommand]
        async Task CreatePinAsync(string url)
        {
            var location = await Geolocation.GetLastKnownLocationAsync();

            location ??= await Geolocation.Default.GetLocationAsync(new GeolocationRequest
            {
                DesiredAccuracy = GeolocationAccuracy.Best,
                Timeout = TimeSpan.FromSeconds(30)
            });

            var pin = new CustomPin
            {
                Label = "Me",
                Location = location,
                Type = PinType.Place,
                ImageSource = ImageSource.FromUri(new Uri("https://www.gamesatlas.com/images/football/teams/ukraine/dynamo-kyiv.png"))
            };

            CustomPins.Add(pin);
        }

    }

}
