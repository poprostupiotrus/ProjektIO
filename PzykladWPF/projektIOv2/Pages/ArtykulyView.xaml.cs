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

namespace projektIOv2.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy Dashboard.xaml
    /// </summary>
    public partial class ArtykulyView : Page
    {
        NavigationService ns;
        ListaArtykulow l1;
        public ArtykulyView()
        {
            InitializeComponent();
            l1 = new ListaArtykulow(MyListbox);
            //MyListbox.ItemsSource = l1.listaArtykulow;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {


        }

        private void ArtykulButton_Click(object sender, RoutedEventArgs e)
        {
            ns = NavigationService.GetNavigationService(this);
            Artykul art = (sender as ArtykulButton).MyData as Artykul;
            if (art == null) return;
            ArtykulView av = new ArtykulView();
            av.DataContext = art;
            ns.Navigate(av);

        }

        private async void czas_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (l1 == null) return;

            DateTime dt1 = (DateTime)czas.SelectedDate;

            var b = await l1.Update(dt1);
            MyListbox.ItemsSource = b;
            // Możesz dodać kod, który zostanie wykonany po zakończeniu zadania.

        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (l1 == null) return;

            DateTime dt1 = (DateTime)czas.SelectedDate;

            var b = await l1.Update(dt1);
            MyListbox.ItemsSource = b;
        }
    }
}
