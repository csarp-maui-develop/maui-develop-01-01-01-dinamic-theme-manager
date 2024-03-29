using CommunityToolkit.Mvvm.Messaging;
using Kreta.Maui.Themes;

namespace Kreta.Maui.Pages;

public partial class ProfilPage : ContentPage
{
	public ProfilPage()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		string newTheme = await DisplayActionSheet("V�lasszon t�m�t", "Cancel", null, ThemeManager.GetHungarianThemeName());
		if (!string.IsNullOrEmpty(newTheme) && newTheme!="Cancel" )
			WeakReferenceMessenger.Default.Send(newTheme);
    }
}