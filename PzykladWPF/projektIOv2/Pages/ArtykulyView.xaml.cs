using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Media.Effects;
using projektIOv2.Controls;
namespace projektIOv2.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy ArtykulyView
    /// </summary>
    public partial class ArtykulyView : Page
    {
        /// <summary>
        /// Przechowuje obiekt nawigacji aplikacji
        /// </summary>
        NavigationService ns;
        /// <summary>
        /// Przechowuje liste artykułów
        /// </summary>
        ListaArtykulow l1;
        /// <summary>
        /// Delegat do obsługi błędu
        /// </summary>
        /// <param name="name">Przechowuje tresc bledu</param>
        public delegate void CustomDelegate(string name);
        /// <summary>
        /// Zdarzenie wywołujące załadowanie artykułu
        /// </summary>
        public event EventHandler ClickPassHandler;
        /// <summary>
        /// Zdarzenie wywołujące obsługe błędu
        /// </summary>
        public event CustomDelegate ErrorBoxShow;
        /// <summary>
        /// Konstruktor inicjalizujący komponenty oraz wszystkie pola składowe klasy
        /// </summary>
        public ArtykulyView()
        {
            InitializeComponent();
            try
            {
                l1 = new ListaArtykulow();
            }
            catch (Exception)
            {
                MessageBox.Show("APLIKACJA NIE BĘDZIE DZIAŁAĆ Z POWODU BRAKU PLIKU Z ARTYKUŁAMI.");

            }
            //MyListbox.ItemsSource = l1.listaArtykulow;
        }
        /// <summary>
        /// Ta metoda wyszukuje najbliższy artykuł w czasie
        /// </summary>
        /// <param name="czas">Przechowuje czas</param>
        /// <returns>Obiekt klasy artykul, poprzez podanie referencji do obiektu</returns>
        public Artykul ZwrocNajblzszyArtykul(DateTime czas)
        {
            return l1.WyszukajArtykul(czas);
        }
        /// <summary>
        /// Ta metoda wyświetla artykuł na stronie po kliknięciu przycisku z tytułem artykułu
        /// </summary>
        /// <param name="sender">Przechowuje obiekt na którym jest wywołane zdarzenie</param>
        /// <param name="e">Przechowuje argumenty zdarzenia</param>
        private void ArtykulButton_Click(object sender, RoutedEventArgs e)
        {
            /*ns = NavigationService.GetNavigationService(this);
            Artykul art = (sender as ArtykulButton).MyData as Artykul;
            if (art == null) return;
            ArtykulView av = new ArtykulView();
            av.DataContext = art;*/
            ClickPassHandler?.Invoke(sender, e);
        }
        /// <summary>
        /// Metoda wyświetla wszystkie artykuly który zostałe opublikowane w danym dniu
        /// </summary>
        /// <param name="sender">Przechowuje obiekt na którym jest wywołane zdarzenie</param>
        /// <param name="e">Przechowuje argumenty zdarzenia</param>
        private async void czas_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (l1 == null) return;

            DateTime dt1 = (DateTime)czas.SelectedDate;
            try
            {
                var b = await l1.Update(dt1);
                /*if (b.Count == 0)
                {
                    errorBox.ErrorMessage = "NIE UDAŁO SIĘ ZAŁADOWAĆ ŻADNYCH ARTYKUŁÓW";
                    OdpowiedzNaError();
                }*/
                MyListbox.ItemsSource = b;
            }
            catch (Exception ex)
            {
                ErrorBoxShow?.Invoke(ex.Message);
            }
            /*if (DateTime.Now < dt1)
            {
                errorBox.ErrorMessage = "NIE MOŻESZ WYBRAC DATY Z PRZYSZŁOŚCI";
                OdpowiedzNaError();
                return;
            }*/
            // Możesz dodać kod, który zostanie wykonany po zakończeniu zadania.
        }
        /// <summary>
        /// Metoda wyświetla wszystkie artykuly który zostałe opublikowane w dniu 07.11.2023, po załadowaniu strony
        /// </summary>
        /// <param name="sender">Przechowuje obiekt na którym jest wywołane zdarzenie</param>
        /// <param name="e">Przechowuje argumenty zdarzenia</param>
        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (l1 == null) return;

            DateTime dt1 = (DateTime)czas.SelectedDate;

            try
            {
                var b = await l1.Update(dt1);
                MyListbox.ItemsSource = b;
            }
            catch (Exception ex)
            {
                ErrorBoxShow?.Invoke(ex.Message);
            }
        }
        /*
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "Wyszukaj...")
            {
                textBox.Text = string.Empty;
            }
        }
        */
    }
}
