using Microsoft.Maui.Controls.Compatibility.Platform.Android;

namespace BillSplitter;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
        MainPage = new MainPage();
	}
}
