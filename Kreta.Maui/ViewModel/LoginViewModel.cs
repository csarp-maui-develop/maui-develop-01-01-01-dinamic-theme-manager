using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Kreta.Maui.Pages;
using Kreta.Maui.Services;

namespace Kreta.Maui.ViewModel
{
    public partial class LoginViewModel : BaseViewModel
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

        [ObservableProperty]
        public string _userName=string.Empty;

        [ObservableProperty]
        public string _password=string.Empty;

        [RelayCommand]
        public async Task Login()
        {
            _authService.Login();
            await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
        }
    }
}
