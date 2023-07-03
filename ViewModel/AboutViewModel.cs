using CommunityToolkit.Mvvm.Input;
using GoogleMaps.Model;
using System.Collections.ObjectModel;

namespace GoogleMaps.ViewModel
{
    public partial class AboutViewModel : BaseViewModel
    {
        public ObservableCollection<FreepikIcon> Icons { get; } = new()
        {
            new FreepikIcon
            {
                Text = "Icon by Freepik",
                Name = "home.png",
                Url = "https://www.freepik.com/search?format=search&last_filter=query&last_value=home&query=home&type=icon"
            },
            new FreepikIcon
            {
                Text = "Icon by Smashicons",
                Name = "map.png",
                Url = "https://www.freepik.com/search?format=search&last_filter=query&last_value=map&query=map&type=icon"
            },
            new FreepikIcon
            {
                Text = "Icon by Freepik",
                Name = "info.png",
                Url = "https://www.freepik.com/search?format=search&last_filter=query&last_value=about&query=about&type=icon"
            },
        };

        [RelayCommand]
        async Task OpenUrlAsync(string url)
        {
            await Launcher.OpenAsync(url);
        }

    }
}
