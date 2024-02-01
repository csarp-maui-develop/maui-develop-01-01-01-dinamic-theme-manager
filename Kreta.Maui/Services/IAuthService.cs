namespace Kreta.Maui.Services
{
    public interface IAuthService
    {
        public Task<bool> IsAuthenticatedAsync();
        public void Login();
        public void Logout();
    }
}
