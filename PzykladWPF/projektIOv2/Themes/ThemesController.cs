using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace projektIOv2.Themes
{
    using System;
    using System.IO;
    using Newtonsoft.Json;
    using System.Windows;

    namespace projektIOv2.Themes
    {
        public static class ThemesController
        {
            public static ThemeTypes CurrentTheme { get; set; }

            public enum ThemeTypes
            {
                Light = 0, Dark = 1
            }

            public static ResourceDictionary ThemeDictionary
            {
                get { return Application.Current.Resources.MergedDictionaries[0]; }
                set { Application.Current.Resources.MergedDictionaries[0] = value; }
            }

            private static void ChangeTheme(Uri uri)
            {
                ThemeDictionary = new ResourceDictionary() { Source = uri };
            }

            public static void SetTheme(ThemeTypes theme)
            {
                string themeName = null;
                CurrentTheme = theme;
                switch (theme)
                {
                    case ThemeTypes.Dark: themeName = "DarkTheme"; break;
                    case ThemeTypes.Light: themeName = "LightTheme"; break;
                }

                try
                {
                    if (!string.IsNullOrEmpty(themeName))
                    {
                        ChangeTheme(new Uri($"Themes/{themeName}.xaml", UriKind.Relative));
                        SaveThemeSettings(theme);
                    }


                    // Zapisz ustawienia po zmianie motywu

                }
                catch { }
            }

            public static void SaveThemeSettings(ThemeTypes theme = ThemeTypes.Dark)
            {
                try
                {
                    var settings = new ThemeSettings { ThemeType = theme };
                    string json = JsonConvert.SerializeObject(settings, Formatting.Indented);
                    File.WriteAllText("themeSettings.json", json);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Błąd podczas zapisywania ustawień motywu: {ex.Message}");
                }
            }

            public static ThemeSettings GetCurrentThemeSettings()
            {
                try
                {
                    if (File.Exists("themeSettings.json"))
                    {
                        string json = File.ReadAllText("themeSettings.json");
                        return JsonConvert.DeserializeObject<ThemeSettings>(json);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Błąd podczas wczytywania ustawień motywu: {ex.Message}");
                }

                return new ThemeSettings { ThemeType = ThemeTypes.Dark }; // Domyślne ustawienia
            }

            public static ThemeTypes GetTheme()
            {
                return GetCurrentThemeSettings().ThemeType;
            }
        }

        public class ThemeSettings
        {
            public ThemesController.ThemeTypes ThemeType { get; set; }
        }
    }

}
