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
    /// Logika interakcji dla klasy Dashboard.xaml
    /// </summary>
    public partial class ArtykulyView : Page
    {
        NavigationService ns;
        public ArtykulyView()
        {
            InitializeComponent();
            ListaArtykulow l1 = new ListaArtykulow();
            MyListbox.ItemsSource = l1.listaArtykulow;
            

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
    }
}
