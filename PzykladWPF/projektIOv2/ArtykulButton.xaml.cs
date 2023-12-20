using projektIOv2.Pages;
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

namespace projektIOv2
{
    /// <summary>
    /// Logika interakcji dla klasy ArtykulButton.xaml
    /// </summary>
    public partial class ArtykulButton : UserControl
    {
        public event EventHandler<RoutedEventArgs> Click;
        public ArtykulButton()
        {
            InitializeComponent();
        }
        public static readonly DependencyProperty MyDataProperty =
        DependencyProperty.Register("MyData", typeof(object), typeof(ArtykulButton));

    public object MyData
    {
        get { return GetValue(MyDataProperty); }
        set { SetValue(MyDataProperty, value); }
    }
        protected virtual void OnClick(RoutedEventArgs e)
        {
            Click?.Invoke(this, e);
        }

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OnClick(new RoutedEventArgs());
        }
    }
}
