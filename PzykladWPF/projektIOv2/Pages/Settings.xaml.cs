﻿using projektIOv2.Themes;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace projektIOv2.Pages
{
    /// <summary>
    /// Klasa reprezentująca stronę ustawień.
    /// </summary>
    public partial class Settings : Page
    {
        /// <summary>
        /// Inicjalizuje nową instancję klasy <see cref="Settings"/>.
        /// </summary>
        public Settings()
        {
            InitializeComponent();

        }

        /// <summary>
        /// Obsługuje zdarzenie wybranej opcji w ComboBox dla motywu Dark.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            ThemesController.SetTheme(ThemesController.ThemeTypes.Dark);

        }

        /// <summary>
        /// Obsługuje zdarzenie wybranej opcji w ComboBox dla motywu Light.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxItem_Selected_1(object sender, RoutedEventArgs e)
        {
            ThemesController.SetTheme(ThemesController.ThemeTypes.Light);

        }

        /// <summary>
        /// Obsługuje zdarzenie załadowania strony.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var b = ThemesController.GetTheme().ToString();
            foreach (var item in cb1.Items)
            {
                if ((item as ComboBoxItem).Content.ToString().Equals(b))
                {
                    (item as ComboBoxItem).IsSelected = true;
                }
            }

            var c = ThemesController.GetFont().ToString();
            foreach (var item in sfnt.Items)
            {
                if ((item as ComboBoxItem).Content.ToString().Equals(c))
                {
                    (item as ComboBoxItem).IsSelected = true;
                }
            }
        }

        /// <summary>
        /// Obsługuje zdarzenie wybranej opcji w ComboBox dla rozmiaru czcionki Small.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void small_Selected(object sender, RoutedEventArgs e)
        {
            ThemesController.SetFont(ThemesController.FontTypes.Small);
        }

        /// <summary>
        /// Obsługuje zdarzenie wybranej opcji w ComboBox dla rozmiaru czcionki Normal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void normal_Selected(object sender, RoutedEventArgs e)
        {
            ThemesController.SetFont(ThemesController.FontTypes.Normal);
        }

        /// <summary>
        /// Obsługuje zdarzenie wybranej opcji w ComboBox dla rozmiaru czcionki Large.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void large_Selected(object sender, RoutedEventArgs e)
        {
            ThemesController.SetFont(ThemesController.FontTypes.Large);
        }


        /// <summary>
        /// Obsługuje zdarzenie wybranej opcji w ComboBox dla motywu High.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void high_Selected(object sender, RoutedEventArgs e)
        {
            ThemesController.SetTheme(ThemesController.ThemeTypes.High);
        }
    }
}
