using GoogleMaps.Control;
using GoogleMaps.ViewModel;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;


namespace GoogleMaps.View;

public partial class MapPage : ContentPage
{
    private Location _location;

	public MapPage(MapViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;

        MoveToUserLocation();
    }

    

    private async void MoveToUserLocation()
    {
        var location = await Geolocation.GetLastKnownLocationAsync();

        location ??= await Geolocation.Default.GetLocationAsync(new GeolocationRequest
        {
            DesiredAccuracy = GeolocationAccuracy.Best,
            Timeout = TimeSpan.FromSeconds(30)
        });

        _location = location;

        var mapSpan = new MapSpan(location, 0.01, 0.01);

        map.MoveToRegion(mapSpan);
    }

    private void OnButtonClicked(object sender, EventArgs e)
    {
        var pin = new CustomPin
        {
            Label = "Me",
            Location = _location,
            Type = PinType.Place,
            ImageSource = ImageSource.FromUri(new Uri("https://www.gamesatlas.com/images/football/teams/ukraine/dynamo-kyiv.png"))
        };
        
        if(map.Pins.Count > 0 )
        {
            var existingPin = map.Pins.Where(p => p.Location == _location).First();
        
            if (existingPin is null)
                map.Pins.Add(pin);
        }
        else
        {
            map.Pins.Add(pin);
        }
    }
}