using projektIOv2.Controls;
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
    /// Logika interakcji dla klasy ArtykulView.xaml
    /// </summary>
    public partial class ArtykulView : Page
    {
        public ArtykulView()
        {
            InitializeComponent();

            (bardmenu.Items[0] as System.Windows.Controls.MenuItem).Click += Bard_Click;

        }


        private void Artykul_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {


        }

        private void gpt_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("gpt");
            var a1 = (DataContext as Artykul).gpt;
            String outt = "";
            foreach (var item in a1)
            {
                outt += item.Key + " " + item.Value + "\n";
            }
            Clipboard.SetText(outt);
        }

        private void bard_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("art");
            var a1 = (DataContext as Artykul);
            String outt = a1.Naglowek + "\n" + a1.Data + "\n" + a1.Tresc;
            Clipboard.SetText(outt);
        }
        private void Bard_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("bard");
            var a1 = (DataContext as Artykul).bard;
            String outt = "";
            foreach (var item in a1)
            {
                outt += item.Key + " " + item.Value + "\n";
            }
            Clipboard.SetText(outt);
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {


        }
    }
}
