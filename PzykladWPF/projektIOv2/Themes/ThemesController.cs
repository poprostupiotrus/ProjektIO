using System;
using System.IO;
using Newtonsoft.Json;
using System.Windows;

namespace projektIOv2.Themes
{
    /// <summary>
    /// Klasa kontrolująca motywy i czcionki aplikacji.
    /// </summary>
    public static class ThemesController
    {
        /// <summary>
        /// Aktualnie wybrany motyw.
        /// </summary>
        public static ThemeTypes CurrentTheme { get; set; }

        /// <summary>
        /// Aktualnie wybrana czcionka.
        /// </summary>
        public static FontTypes CurrentFont { get; set; }

        /// <summary>
        /// Enumeracja reprezentująca dostępne motywy.
        /// </summary>
        public enum ThemeTypes
        {
            Light = 0, Dark = 1,High=2
        }

        /// <summary>
        /// Enumeracja reprezentująca dostępne czcionki.
        /// </summary>
        public enum FontTypes
        {
            Normal = 0, Small = 1,Large=2
        }

        /// <summary>
        /// Właściwość pozwalacjaca kontrolować aktualny motyw.
        /// </summary>
        public static ResourceDictionary ThemeDictionary
        {
            get { return Application.Current.Resources.MergedDictionaries[0]; }
            set { Application.Current.Resources.MergedDictionaries[0] = value; }
        }

        /// <summary>
        /// Właściwość pozwalacjaca kontrolować aktualną czcionke.
        /// </summary>
        public static ResourceDictionary FontDictionary
        {
            get { return Application.Current.Resources.MergedDictionaries[1]; }
            set { Application.Current.Resources.MergedDictionaries[1] = value; }
        }

        /// <summary>
        /// Metoda zmieniająca motyw aplikacji na podstawie podanej ścieżki URI.
        /// </summary>
        /// <param name="uri">uri motywu</param>
        private static void ChangeTheme(Uri uri)
        {
            ThemeDictionary = new ResourceDictionary() { Source = uri };
        }

        /// <summary>
        /// Metoda zmieniająca czcionkę aplikacji na podstawie podanej ścieżki URI.
        /// </summary>
        /// <param name="uri">uri czcionki</param>
        private static void ChangeFont(Uri uri)
        {
            FontDictionary = new ResourceDictionary() { Source = uri };
        }

        /// <summary>
        /// Ustawia motyw aplikacji na podstawie podanego typu motywu.
        /// </summary>
        /// <param name="theme">Typ motywu.</param>
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

        /// <summary>
        /// Ustawia czcionkę aplikacji na podstawie podanego typu czcionki.
        /// </summary>
        /// <param name="font">Typ czcionki.</param>
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

        /// <summary>
        /// Zapisuje bieżące ustawienia motywu i czcionki do pliku JSON.
        /// </summary>
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

        /// <summary>
        /// Pobiera bieżące ustawienia motywu i czcionki z pliku JSON.
        /// </summary>
        /// <returns>
        /// Zwraca obiekt zawierający ustawienia motywu i czcionki.
        /// Jeśli plik "Settings.json" nie istnieje lub wystąpił błąd podczas wczytywania ustawień, zwraca domyślne ustawienia.
        /// </returns>
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

        /// <summary>
        /// Pobiera bieżący typ motywu z ustawień.
        /// </summary>
        /// <returns>wraca typ motywu.</returns>
        public static ThemeTypes GetTheme()
        {
            return GetCurrentSettings().ThemeType;
        }

        /// <summary>
        /// Pobiera bieżący typ czcionki z ustawień.
        /// </summary>
        /// <returns>Zwraca typ czcionki.</returns>
        public static FontTypes GetFont()
        {
            return GetCurrentSettings().FontType;
        }

        /// <summary>
        /// Klasa reprezentująca ustawienia motywu i czcionki.
        /// </summary>
        public class Settings
    {
            /// <summary>
            /// Typ motywu.
            /// </summary>
            public ThemesController.ThemeTypes ThemeType { get; set; }

            /// <summary>
            /// Typ czcionki.
            /// </summary>
            public ThemesController.FontTypes FontType { get; set; }
    }
    }

    
}
