using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Resources;
using System.Reflection;
using projektIOv2.Themes;
using projektIOv2.Pages;

namespace projektIOv2
{


    public partial class MainWindow : Window
    {
        private DragAndDrop dragAndDropWindow;
        ArtykulyView art;
        Home home1;
        Settings settings;
        public MainWindow()
        {
            InitializeComponent();
            dragAndDropWindow = new DragAndDrop(this);


        }

        private void BG_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Tg_Btn.IsChecked = false;
        }

        // Start: MenuLeft PopupButton //
        private void btnHome_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Tg_Btn.IsChecked == false)
            {
                Popup.PlacementTarget = btnHome;
                Popup.Placement = PlacementMode.Right;
                Popup.IsOpen = true;
                Header.PopupText.Text = "Notowania";
            }
        }

        private void btnHome_MouseLeave(object sender, MouseEventArgs e)
        {
            Popup.Visibility = Visibility.Collapsed;
            Popup.IsOpen = false;
        }

        private void btnDashboard_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Tg_Btn.IsChecked == false)
            {
                Popup.PlacementTarget = btnDashboard;
                Popup.Placement = PlacementMode.Right;
                Popup.IsOpen = true;
                Header.PopupText.Text = "Artykuly";
            }
        }

        private void btnDashboard_MouseLeave(object sender, MouseEventArgs e)
        {
            Popup.Visibility = Visibility.Collapsed;
            Popup.IsOpen = false;
        }




        private void btnSetting_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Tg_Btn.IsChecked == false)
            {
                Popup.PlacementTarget = btnSetting;
                Popup.Placement = PlacementMode.Right;
                Popup.IsOpen = true;
                Header.PopupText.Text = "Ustawienia";
            }
        }

        private void btnSetting_MouseLeave(object sender, MouseEventArgs e)
        {
            Popup.Visibility = Visibility.Collapsed;
            Popup.IsOpen = false;
        }
        // End: MenuLeft PopupButton //

        // Start: Button Close | Restore | Minimize 
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnRestore_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
                WindowState = WindowState.Maximized;
            else
                WindowState = WindowState.Normal;
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        // End: Button Close | Restore | Minimize

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            if (home1 == null) home1 = new Home();
            fContainer.Navigate(home1);
        }

        private void btnDashboard_Click(object sender, RoutedEventArgs e)
        {
            if (art == null) art = new ArtykulyView();
            fContainer.Navigate(art);
        }

        private new void PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //Trace.WriteLine("Main Window: PreviewMouseLeftButtonDown");
            this.OnMouseLeftButtonDown(sender, e);
        }

        private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //Trace.WriteLine("Main Window: OnMouseLeftButtonDown");
            dragAndDropWindow.OnMouseLeftButtonDown(sender, e);
        }

        private void OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //Trace.WriteLine("Main Window: OnMouseLeftButtonUp");
            dragAndDropWindow.OnMouseLeftButtonUp(sender, e);
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            //Trace.WriteLine("Main Window: OnMouseMove");
            dragAndDropWindow.OnMouseMove(sender, e);
        }

        private void btnSetting_Click(object sender, RoutedEventArgs e)
        {
            if (settings == null) settings = new Settings();
            fContainer.Navigate(settings);
        }

        private void home_Loaded(object sender, RoutedEventArgs e)
        {
            var contlorer = ThemesController.GetCurrentSettings();
            ThemesController.SetTheme(contlorer.ThemeType);
            ThemesController.SetFont(contlorer.FontType);
            home1 = new Home();
            fContainer.Navigate(home1);
        }
    }
}
