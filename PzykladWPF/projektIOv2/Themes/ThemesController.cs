using System;
using System.IO;
using Newtonsoft.Json;
using System.Windows;

namespace projektIOv2.Themes
{
    public static class ThemesController
    {
        public static ThemeTypes CurrentTheme { get; set; }
        public static FontTypes CurrentFont { get; set; }

        public enum ThemeTypes
        {
            Light = 0, Dark = 1,High=2
        }

        public enum FontTypes
        {
            Normal = 0, Small = 1,Large=2
        }

        public static ResourceDictionary ThemeDictionary
        {
            get { return Application.Current.Resources.MergedDictionaries[0]; }
            set { Application.Current.Resources.MergedDictionaries[0] = value; }
        }

        public static ResourceDictionary FontDictionary
        {
            get { return Application.Current.Resources.MergedDictionaries[1]; }
            set { Application.Current.Resources.MergedDictionaries[1] = value; }
        }

        private static void ChangeTheme(Uri uri)
        {
            ThemeDictionary = new ResourceDictionary() { Source = uri };
        }

        private static void ChangeFont(Uri uri)
        {
            FontDictionary = new ResourceDictionary() { Source = uri };
        }

        public static void SetTheme(ThemeTypes theme)
        {
            string themeName = null;
            CurrentTheme = theme;
            switch (theme)
            {
                case ThemeTypes.Dark: themeName = "DarkTheme"; break;
                case ThemeTypes.Light: themeName = "LightTheme"; break;
                case ThemeTypes.High: themeName = "HighTheme"; break;
            }

            try
            {
                if (!string.IsNullOrEmpty(themeName))
                {
                    ChangeTheme(new Uri($"Themes/{themeName}.xaml", UriKind.Relative));
                    SaveSettings();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd podczas zmiany motywu: {ex.Message}");
            }
        }

        public static void SetFont(FontTypes font)
        {
            string fontName = null;
            CurrentFont = font;
            switch (font)
            {
                case FontTypes.Normal: fontName = "FontNormal"; break;
                case FontTypes.Small: fontName = "FontSmall"; break;
                case FontTypes.Large: fontName = "FontLarge"; break;
            }

            try
            {
                if (!string.IsNullOrEmpty(fontName))
                {
                    ChangeFont(new Uri($"Themes/{fontName}.xaml", UriKind.Relative));
                    SaveSettings();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd podczas zmiany czcionki: {ex.Message}");
            }
        }

        public static void SaveSettings()
        {
            try
            {
                var settings = new Settings { ThemeType = CurrentTheme, FontType = CurrentFont };
                string json = JsonConvert.SerializeObject(settings, Formatting.Indented);
                File.WriteAllText("Settings.json", json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd podczas zapisywania ustawień: {ex.Message}");
            }
        }

        public static Settings GetCurrentSettings()
        {
            try
            {
                if (File.Exists("Settings.json"))
                {
                    string json = File.ReadAllText("Settings.json");
                    return JsonConvert.DeserializeObject<Settings>(json);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd podczas wczytywania ustawień: {ex.Message}");
            }

            return new Settings { ThemeType = ThemeTypes.Dark, FontType = FontTypes.Normal }; // Domyślne ustawienia
        }

        public static ThemeTypes GetTheme()
        {
            return GetCurrentSettings().ThemeType;
        }

        public static FontTypes GetFont()
        {
            return GetCurrentSettings().FontType;
        }


        public class Settings
    {
        public ThemesController.ThemeTypes ThemeType { get; set; }
        public ThemesController.FontTypes FontType { get; set; }
    }
    }

    
}
