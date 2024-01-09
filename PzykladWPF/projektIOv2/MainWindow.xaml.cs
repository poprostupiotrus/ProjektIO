using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using projektIOv2.Themes;
using projektIOv2.Pages;
using LiveCharts;
using System;
using System.Globalization;

namespace projektIOv2
{

    /// <summary>
    /// Główne okno aplikacji.
    /// </summary>
    public partial class MainWindow : Window
    {
        private DragAndDrop dragAndDropWindow;
        ListaArtykulow listaArtykulow;
        ArtykulView artykulView;
        CombinedArtykulyView art;
        Home home1;
        Settings settings;

        /// <summary>
        /// Inicjalizuje nową instancję klasy <see cref="MainWindow"/>.
        /// </summary>
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
            if(home == null)
            {
                home1 = new Home();
            }
            fContainer.Navigate(home1);
        }

        private void OnDataClick(object sender, ChartPoint chartPoint)
        {
            try
            {
                DateTime date = DateTime.ParseExact(home1.viewModel.wszystkieDaty[(int)chartPoint.X], "dd.MM.yyyy HH.mm", CultureInfo.InvariantCulture);
                if (listaArtykulow == null)
                {
                    listaArtykulow = new ListaArtykulow();
                }
                Artykul artykul = listaArtykulow.WyszukajArtykulDlaWykresu(date);
                if (artykulView == null)
                {
                    artykulView = new ArtykulView();
                }
                artykulView.naw1.Visibility = Visibility.Visible;
                artykulView.DataContext = artykul;
                fContainer.Navigate(artykulView);
            }
            catch (Exception)
            {

                
            }
        }

        private void btnDashboard_Click(object sender, RoutedEventArgs e)
        {
            if (art == null) art = new CombinedArtykulyView();
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
            home1.stockChart.DataClick += OnDataClick;
            fContainer.Navigate(home1);
        }
    }
}
