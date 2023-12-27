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

namespace projektIOv2.Controls
{
    /// <summary>
    /// Logika interakcji dla klasy NotowanieControl.xaml
    /// </summary>
    public partial class NotowanieControl : UserControl
    {
        public NotowanieControl()
        {
            InitializeComponent();
        }
        public static readonly DependencyProperty MyDataProperty =
        DependencyProperty.Register("MyData", typeof(object), typeof(NotowanieControl));


    }
}
