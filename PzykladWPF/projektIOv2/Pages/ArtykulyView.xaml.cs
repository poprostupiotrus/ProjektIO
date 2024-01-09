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
    /// Logika interakcji dla klasy Dashboard.xaml
    /// </summary>
    public partial class ArtykulyView : Page
    {
        NavigationService ns;
        ListaArtykulow l1;
        public delegate void CustomDelegate(string name);
        public event EventHandler ClickPassHandler;
        public event CustomDelegate ErrorBoxShow;
        public ArtykulyView()
        {
            InitializeComponent();
            try
            {
                l1 = new ListaArtykulow();
            }
            catch (Exception)
            {
                MessageBox.Show("APLIKACJA NIE BĘDZIE DZIAŁAĆ Z POWODU BRAKU PLIKU Z ARTYKÓŁAMI.");

            }
            //MyListbox.ItemsSource = l1.listaArtykulow;
        }

        public Artykul ZwrocNajblzszyArtykul(DateTime czas)
        {
            return l1.WyszukajArtykul(czas);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        private void ArtykulButton_Click(object sender, RoutedEventArgs e)
        {
            /*ns = NavigationService.GetNavigationService(this);
            Artykul art = (sender as ArtykulButton).MyData as Artykul;
            if (art == null) return;
            ArtykulView av = new ArtykulView();
            av.DataContext = art;*/
            ClickPassHandler?.Invoke(sender, e);
        }
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
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "Wyszukaj...")
            {
                textBox.Text = string.Empty;
            }
        }
    }
}
