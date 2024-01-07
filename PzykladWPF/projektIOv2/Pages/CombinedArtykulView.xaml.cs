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
    /// Logika interakcji dla klasy CombinedArtykulyView.xaml
    /// </summary>
    public partial class CombinedArtykulyView : Page
    {
        ArtykulyView artList;
        public CombinedArtykulyView()
        {
            InitializeComponent();
            InitArtList();
            artList.ClickPassHandler += Button_Click;
        }

        private void InitArtList()
        {
            Frame frameArtList = (Frame)FindName("articleList");
            artList = new ArtykulyView();
            frameArtList.Content = artList;
        }

        private void Button_Click(object? sender, EventArgs e)
        {
            ArtykulButton artykulButton = sender as ArtykulButton;
            if (artykulButton != null)
            {
                Artykul artykul = artykulButton.MyData as Artykul;
                ArtykulView artykulView = new ArtykulView();
                artykulView.DataContext = artykul;
                Frame frameArt = (Frame)FindName("articlePage");
                frameArt.Content = artykulView;
            }
        }

    }
}
