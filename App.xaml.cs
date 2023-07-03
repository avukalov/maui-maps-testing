using System.Runtime.CompilerServices;

namespace GoogleMaps;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
