using ThemesRosurce = Kreta.Maui.Resources.Themes;

namespace Kreta.Maui.Themes
{
    public class ThemeManager
    {
        private static readonly IDictionary<string, ResourceDictionary> _themesMap = new Dictionary<string, ResourceDictionary>
        {
            [nameof(ThemesRosurce.Default)] = new ThemesRosurce.Default(),
            [nameof(ThemesRosurce.Fire)] = new ThemesRosurce.Fire(),
            [nameof(ThemesRosurce.Natural)] = new ThemesRosurce.Natural(),
        };

        static ThemeManager()
        {
            if (Application.Current is not null)
            {
                Application.Current.RequestedThemeChanged += Current_RequestedThemeChanged;
            }
        }

        private static void Current_RequestedThemeChanged(object? sender, AppThemeChangedEventArgs e)
        {
            if (e.RequestedTheme==AppTheme.Dark)
            {
                SetTheme(nameof(ThemesRosurce.Dark));
            }
            else
            {
                SetTheme(nameof(ThemesRosurce.Default));
            }
        }

        public static string ThemeName { get; set; } = nameof(ThemesRosurce.Default);

        public static void SetTheme(string themeName)
        {
            if (themeName == ThemeName)
                return;
            try
            {
                var themeToBeApplied = _themesMap[themeName];
                if (Application.Current is not null)
                {
                    Application.Current.Resources.MergedDictionaries.Clear();
                    Application.Current.Resources.MergedDictionaries.Add(themeToBeApplied);
                    ThemeName = themeName;
                }
            }
            catch (Exception ex) { }
        }
    }
}
