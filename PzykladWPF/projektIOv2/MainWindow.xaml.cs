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
        /*
        private void BG_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Tg_Btn.IsChecked = false;
        }
        */
        // Start: MenuLeft PopupButton //
        /// <summary>
        /// Ta metoda wywołana po najechaniu na przycisk "btnHome" pokazuje okno z napisem "Notowania"
        /// </summary>
        /// <param name="sender">Przechowuje obiekt na którym jest wywołane zdarzenie</param>
        /// <param name="e">Przechowuje argumenty zdarzenia</param>
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
        /// <summary>
        /// Ta metoda wywołana po wyjściu kursora z przycisku "btnHome" ukrywa okno z napisem "Notowania"
        /// </summary>
        /// <param name="sender">Przechowuje obiekt na którym jest wywołane zdarzenie</param>
        /// <param name="e">Przechowuje argumenty zdarzenia</param>
        private void btnHome_MouseLeave(object sender, MouseEventArgs e)
        {
            Popup.Visibility = Visibility.Collapsed;
            Popup.IsOpen = false;
        }
        /// <summary>
        /// Ta metoda wywołana po najechaniu na przycisk "btnDashboard" pokazuje okno z napisem "Artykuly"
        /// </summary>
        /// <param name="sender">Przechowuje obiekt na którym jest wywołane zdarzenie</param>
        /// <param name="e">Przechowuje argumenty zdarzenia</param>
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
        /// <summary>
        /// Ta metoda wywołana po wyjściu kursora z przycisku "btnDashboard" ukrywa okno z napisem "Artykuly"
        /// </summary>
        /// <param name="sender">Przechowuje obiekt na którym jest wywołane zdarzenie</param>
        /// <param name="e">Przechowuje argumenty zdarzenia</param>
        private void btnDashboard_MouseLeave(object sender, MouseEventArgs e)
        {
            Popup.Visibility = Visibility.Collapsed;
            Popup.IsOpen = false;
        }
        /// <summary>
        /// Ta metoda wywołana po najechaniu na przycisk "btnSetting" pokazuje okno z napisem "Ustawienia"
        /// </summary>
        /// <param name="sender">Przechowuje obiekt na którym jest wywołane zdarzenie</param>
        /// <param name="e">Przechowuje argumenty zdarzenia</param>
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
        /// <summary>
        /// Ta metoda wywołana po wyjściu kursora z przycisku "btnSetting" ukrywa okno z napisem "Ustawienia"
        /// </summary>
        /// <param name="sender">Przechowuje obiekt na którym jest wywołane zdarzenie</param>
        /// <param name="e">Przechowuje argumenty zdarzenia</param>
        private void btnSetting_MouseLeave(object sender, MouseEventArgs e)
        {
            Popup.Visibility = Visibility.Collapsed;
            Popup.IsOpen = false;
        }
        // End: MenuLeft PopupButton //

        // Start: Button Close | Restore | Minimize 
        /// <summary>
        /// Ta metoda wywołana po naciśnięciu przycisku zamknięcia, zamyka całą aplikacje
        /// </summary>
        /// <param name="sender">Przechowuje obiekt na którym jest wywołane zdarzenie</param>
        /// <param name="e">Przechowuje argumenty zdarzenia</param>
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        /// <summary>
        /// Ta metoda wywołana po naciśnięciu przycisku "btnRestore", w przypadku gdy rozmiar jest normalny, maksymalizuje okno, a gdy rozmiar jest maksymalny przywraca do rozmiaru normalnego
        /// </summary>
        /// <param name="sender">Przechowuje obiekt na którym jest wywołane zdarzenie</param>
        /// <param name="e">Przechowuje argumenty zdarzenia</param>
        private void btnRestore_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
                WindowState = WindowState.Maximized;
            else
                WindowState = WindowState.Normal;
        }
        /// <summary>
        /// Ta metoda wywołana po naciśnięciu przycisku "btnMinimize" minimalizuje okno aplikacji
        /// </summary>
        /// <param name="sender">Przechowuje obiekt na którym jest wywołane zdarzenie</param>
        /// <param name="e">Przechowuje argumenty zdarzenia</param>
        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        // End: Button Close | Restore | Minimize
        /// <summary>
        /// Ta metoda wywołana po naciśnięciu przycisku btnHome, przenosi nas do strony z wykresem
        /// </summary>
        /// <param name="sender">Przechowuje obiekt na którym jest wywołane zdarzenie (obiekt klasy Button)</param>
        /// <param name="e">Przechowuje argumenty zdarzenia</param>
        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            if(home == null)
            {
                home1 = new Home();
            }
            fContainer.Navigate(home1);
        }
        /// <summary>
        /// Ta metoda wywołana po naciśnięciu punktu na wykresie, przenosi nas do strony z najblizszym artykulem w czasie
        /// </summary>
        /// <param name="sender">Przechowuje obiekt na którym jest wywołane zdarzenie</param>
        /// <param name="e">Przechowuje argumenty zdarzenia</param>
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
        /// <summary>
        /// Ta metoda wywołana po naciśnięciu przycisku btnHome, przenosi nas do strony z artykulami
        /// </summary>
        /// <param name="sender">Przechowuje obiekt na którym jest wywołane zdarzenie (obiekt klasy Button)</param>
        /// <param name="e">Przechowuje argumenty zdarzenia</param>
        private void btnDashboard_Click(object sender, RoutedEventArgs e)
        {
            if (art == null) art = new CombinedArtykulyView();
            fContainer.Navigate(art);
        }
        /*
        private new void PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //Trace.WriteLine("Main Window: PreviewMouseLeftButtonDown");
            this.OnMouseLeftButtonDown(sender, e);
        }
        */
        /// <summary>
        /// Metoda wywołana gdy lewy przycisk jest naciśnięty
        /// </summary>
        /// <param name="sender">Przechowuje obiekt na którym jest wywołane zdarzenie</param>
        /// <param name="e">Przechowuje argumenty zdarzenia</param>
        private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //Trace.WriteLine("Main Window: OnMouseLeftButtonDown");
            dragAndDropWindow.OnMouseLeftButtonDown(sender, e);
        }
        /// <summary>
        /// Metoda wywołana gdy użytkownik puści lewy przycisk myszy
        /// </summary>
        /// <param name="sender">Przechowuje obiekt na którym jest wywołane zdarzenie</param>
        /// <param name="e">Przechowuje argumenty zdarzenia</param>
        private void OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //Trace.WriteLine("Main Window: OnMouseLeftButtonUp");
            dragAndDropWindow.OnMouseLeftButtonUp(sender, e);
        }
        /// <summary>
        /// Metoda wywołana gdy użytkownik poruszy myszką
        /// </summary>
        /// <param name="sender">Przechowuje obiekt na którym jest wywołane zdarzenie</param>
        /// <param name="e">Przechowuje argumenty zdarzenia</param>
        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            //Trace.WriteLine("Main Window: OnMouseMove");
            dragAndDropWindow.OnMouseMove(sender, e);
        }
        /// <summary>
        /// Ta metoda wywołana po nacisnieciu btnSetting przenosi nas do strony z ustawieniami
        /// </summary>
        /// <param name="sender">Przechowuje obiekt na którym jest wywołane zdarzenie</param>
        /// <param name="e">Przechowuje argumenty zdarzenia</param>
        private void btnSetting_Click(object sender, RoutedEventArgs e)
        {
            if (settings == null) settings = new Settings();
            fContainer.Navigate(settings);
        }
        /// <summary>
        /// Ta metoda wyświetla strone z wykresem po załadowaniu głownej strony
        /// </summary>
        /// <param name="sender">Przechowuje obiekt na którym jest wywołane zdarzenie</param>
        /// <param name="e">Przechowuje argumenty zdarzenia</param>
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
