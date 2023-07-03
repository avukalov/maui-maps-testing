using GoogleMaps.View;

namespace GoogleMaps;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();

		BindingContext = this;
	}

    async void SimpleBottomSheetButton_Clicked(System.Object sender, System.EventArgs e) =>
        await simpleBottomSheet.OpenBottomSheet();
}

