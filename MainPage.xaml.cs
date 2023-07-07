
#if ANDROID

using BottomSheetView = Google.Android.Material.BottomSheet.BottomSheetDialog;

#endif

namespace GoogleMaps
{
    public partial class MainPage : ContentPage
    {
        BottomSheetView? bottomSheet;
        public int Count { get; set; }

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;

        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            Count++;
            OnPropertyChanged(nameof(Count));
        }

        private void ShowBottomSheet(object sender, EventArgs e)
        {
            bottomSheet = this.ShowBottomSheet(GetBottomSheetView(), true);
        }

        private Microsoft.Maui.Controls.View GetBottomSheetView()
        {
            var view = (Microsoft.Maui.Controls.View)BottomSheetTemplate.CreateContent();
            view.BindingContext = BindingContext;
            return view;
        }

        private void ShowBottomSheetWithLongContent(object sender, EventArgs e)
        {
            bottomSheet = this.ShowBottomSheet(GetBottomSheetViewWithLongContent(), false);
        }

        private Microsoft.Maui.Controls.View GetBottomSheetViewWithLongContent()
        {
            var view = (Microsoft.Maui.Controls.View)BottomSheetTemplateWithLongContent.CreateContent();
            view.BindingContext = BindingContext;
            view.MaximumHeightRequest = 300;
            return view;
        }

        private void OnCloseClicked(object? sender, EventArgs e)
        {
            bottomSheet?.CloseBottomSheet();
        }


        //  private async void ClickMeBtn_Clicked(object sender, EventArgs e)
        //  {
        //await simpleBottomSheet.OpenBottomSheet();
        //  }

    }
}




