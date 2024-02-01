using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Kreta.Maui.Pages;
using Kreta.Maui.Services;

namespace Kreta.Maui.ViewModel
{
    public partial class ProfilViewModel : ObservableObject
    {
        private readonly IAuthService _authService;

        public ProfilViewModel()
        {
            _authService = new AuthService();
        }

        public ProfilViewModel(IAuthService authService)
        {
            _authService = authService;
        }

        [RelayCommand]
        public async Task Logout()
        {
            _authService.Logout();
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
    }
}
