using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Kreta.Maui.Pages;
using Kreta.Maui.Services;

namespace Kreta.Maui.ViewModel
{
    public partial class LoginViewModel : ObservableObject
    {
        private readonly IAuthService _authService;

        public LoginViewModel()
        {
            _authService = new AuthService();
        }

        public LoginViewModel(IAuthService authService)
        {
            _authService = authService;
        }

        [RelayCommand]
        public async Task Login()
        {
            _authService.Login();
            await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
        }
    }
}
