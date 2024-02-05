using Kreta.Maui.Themes;

namespace Kreta.Maui
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            ThemeManager.Initialize();
            base.OnStart();
        }
    }
}
