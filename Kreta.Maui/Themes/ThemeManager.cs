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
