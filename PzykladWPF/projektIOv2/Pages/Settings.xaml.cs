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
    /// Logika interakcji dla klasy Settings.xaml
    /// </summary>
    public partial class Settings : Page
    {
        public Settings()
        {
            InitializeComponent();

        }

        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            ThemesController.SetTheme(ThemesController.ThemeTypes.Dark);

        }

        private void ComboBoxItem_Selected_1(object sender, RoutedEventArgs e)
        {
            ThemesController.SetTheme(ThemesController.ThemeTypes.Light);

        }

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

        private void small_Selected(object sender, RoutedEventArgs e)
        {
            ThemesController.SetFont(ThemesController.FontTypes.Small);
        }

        private void normal_Selected(object sender, RoutedEventArgs e)
        {
            ThemesController.SetFont(ThemesController.FontTypes.Normal);
        }

        private void large_Selected(object sender, RoutedEventArgs e)
        {
            ThemesController.SetFont(ThemesController.FontTypes.Large);
        }

        

        private void high_Selected(object sender, RoutedEventArgs e)
        {
            ThemesController.SetTheme(ThemesController.ThemeTypes.High);
        }
    }
}
