using System.Windows;
using System.Windows.Controls;

namespace projektIOv2.Controls
{
    /// <summary>
    /// Kontrolka reprezentująca element listy wyświetlający notowanie i spółkę.
    /// </summary>
    public partial class NotowanieControl : UserControl
    {
        /// <summary>
        /// Inicjalizuje nową instancję klasy NotowanieControl.
        /// </summary>
        public NotowanieControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Właściwość zależności reprezentująca dane dla kontrolki.
        /// </summary>
        public static readonly DependencyProperty MyDataProperty =
        DependencyProperty.Register("MyData", typeof(object), typeof(NotowanieControl));


    }
   
}
