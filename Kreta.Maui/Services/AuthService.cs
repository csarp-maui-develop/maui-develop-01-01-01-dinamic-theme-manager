namespace Kreta.Maui.Services
{
    public class AuthService : IAuthService
    {
        private const string AuthenticationStateKey = "AuthenticationState";
        public async Task<bool> IsAuthenticatedAsync()
        {
            await Task.Delay(200);
            return Preferences.Default.Get<bool>(AuthenticationStateKey, false);
        }

        public void Login()
        {
            Preferences.Default.Set<bool>(AuthenticationStateKey, true);
        }

        public void Logout()
        {
            Preferences.Default.Remove(AuthenticationStateKey);
        }
            
    }
}
