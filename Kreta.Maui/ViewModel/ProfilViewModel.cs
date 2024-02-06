using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Kreta.Maui.Pages;
using Kreta.Maui.Services;
using Kreta.Maui.Themes;

namespace Kreta.Maui.ViewModel
{
    public partial class ProfilViewModel : BaseViewModel
    {
        private readonly IAuthService _authService;

        [ObservableProperty]
        public string _themeHungarianName= $"Téma: {ThemeManager.ThemeHungiranName}";

        public ProfilViewModel()
        {
            _authService = new AuthService();
            RegisterToMessageCenter();
        }

        public ProfilViewModel(IAuthService authService)
        {
            _authService = authService;
            RegisterToMessageCenter();
        }

        [RelayCommand]
        public async Task Logout()
        {
            _authService.Logout();
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }


        private void OnThemeChanged(string themeHungarianName)
        {
            ThemeHungarianName = $"Téma: {themeHungarianName}";
            string themeName=ThemeManager.GetThemeName(themeHungarianName);
            ThemeManager.SetTheme(themeName);
        }

        private void RegisterToMessageCenter()
        {
            WeakReferenceMessenger.Default.Register<string>(this, (r, m) =>
            {
                OnThemeChanged(m);
            });
        }
    }
}
