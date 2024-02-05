using ThemesRosurce = Kreta.Maui.Resources.Themes;

namespace Kreta.Maui.Themes
{
    public class ThemeManager
    {
        private const string ThemeKey = "theme";
        private const string PrevThemeKey = "prevtheme";

        private static readonly IDictionary<string, ResourceDictionary> _themesMap = new Dictionary<string, ResourceDictionary>
        {
            [nameof(ThemesRosurce.Default)] = new ThemesRosurce.Default(),
            [nameof(ThemesRosurce.Dark)] = new ThemesRosurce.Dark(),
            [nameof(ThemesRosurce.Fire)] = new ThemesRosurce.Fire(),
            [nameof(ThemesRosurce.Natural)] = new ThemesRosurce.Natural(),
        };

        private static readonly IDictionary<string, string> _themeHungarianName = new Dictionary<string, string>()
        {
            [nameof(ThemesRosurce.Default)] = "Alapértelmezett",
            [nameof(ThemesRosurce.Dark)] = "Sötét",
            [nameof(ThemesRosurce.Fire)] = "Tűz",
            [nameof(ThemesRosurce.Natural)] = "Természetes",
        };

        static ThemeManager()
        {
            if (Application.Current is not null)
            {
                Application.Current.RequestedThemeChanged += Current_RequestedThemeChanged;
            }
        }

        public static void Initialize()
        {
            string themeName = nameof(ThemesRosurce.Default);
            if (Application.Current is not null && Application.Current.UserAppTheme == AppTheme.Dark)
                themeName = nameof(ThemesRosurce.Dark);
            else
                themeName = Preferences.Default.Get<string>(ThemeKey, nameof(ThemesRosurce.Default));
            SetTheme(themeName);
        }

        public static string ThemeName { get; set; } = nameof(ThemesRosurce.Default);
        public static string ThemeHungiranName => _themeHungarianName.FirstOrDefault(themeName => themeName.Key == ThemeName).Key;

        public static string[] GetHungarianThemeName()
        {
            return _themeHungarianName.Values.ToArray();
        }

        public static string GetThemeName(string hungarianThemeName)
        {
            return _themeHungarianName.FirstOrDefault(themeName => themeName.Value == hungarianThemeName).Key;
        }

        private static void Current_RequestedThemeChanged(object? sender, AppThemeChangedEventArgs e)
        {
            if (e.RequestedTheme==AppTheme.Dark)
            {
                if (ThemeName!=nameof(ThemesRosurce.Dark))
                {
                    Preferences.Default.Set<string>(PrevThemeKey, ThemeName);
                }
                SetTheme(nameof(ThemesRosurce.Dark));
            }
            else
            {
                string prevThemeName=Preferences.Default.Get<string>(PrevThemeKey,nameof(ThemesRosurce.Dark));
                SetTheme(prevThemeName);
            }
        }

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
                    Preferences.Default.Set<string>(ThemeKey, themeName);
                }
            }
            catch (Exception ex) { }
        }
    }
}
