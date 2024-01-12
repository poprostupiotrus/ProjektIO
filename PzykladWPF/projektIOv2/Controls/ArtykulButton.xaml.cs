using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;


namespace projektIOv2
{
    /// <summary>
    /// Logika interakcji dla klasy ArtykulButton
    /// </summary>
    public partial class ArtykulButton : UserControl
    {
        /// <summary>
        /// Zdarzenie wywoływane po kliknięciu linku do artykułu.
        /// </summary>
        public event EventHandler<RoutedEventArgs> Click;

        /// <summary>
        /// Konstruktor inicjalizujący nową instancje klasy
        /// </summary>
        public ArtykulButton()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Właściwość zależności reprezentująca dane przycisku artykułu.
        /// </summary>
        public static readonly DependencyProperty MyDataProperty =
        DependencyProperty.Register("MyData", typeof(object), typeof(ArtykulButton));

        /// <summary>
        /// Pobiera lub ustawia dane przycisku artykułu.
        /// </summary>
        public object MyData
        {
            get { return GetValue(MyDataProperty); }
            set { SetValue(MyDataProperty, value); }
        }

        /// <summary>
        /// Metoda wywołująca zdarzenie Click.
        /// </summary>
        /// <param name="e">Argumenty zdarzenia.</param>
        protected virtual void OnClick(RoutedEventArgs e)
        {
            Click?.Invoke(this, e);
        }


        /// <summary>
        /// Obsługuje zdarzenie Click linku artykułu.
        /// </summary>
        /// <param name="sender">Przechowuje obiekt na którym jest wywoływane zdarzenie</param>
        /// <param name="e">Argumenty zdarzenia.</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OnClick(new RoutedEventArgs());
        }
    }

    /// <summary>
    /// Konwerter wartości do widoczności, który konwertuje null na Visibility.Collapsed.
    /// </summary>
    public class VisibilityConverter : IValueConverter
    {
        /// <summary>
        /// Konwertuje wartość na odpowiednią widoczność.
        /// </summary>
        /// <param name="value">Wartość do konwersji.</param>
        /// <param name="targetType">Typ docelowy.</param>
        /// <param name="parameter">Parametr konwersji.</param>
        /// <param name="culture">Informacje o kulturze.</param>
        /// <returns>Wartość Visibility reprezentująca widoczność.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return Visibility.Collapsed;
            return Visibility.Visible;
        }



        /// <summary>
        /// Konwertuje z powrotem widoczność na wartość (nieużywane).
        /// </summary>
        /// <param name="value">Wartość do konwersji.</param>
        /// <param name="targetType">Typ docelowy.</param>
        /// <param name="parameter">Parametr konwersji.</param>
        /// <param name="culture">Informacje o kulturze.</param>
        /// <returns>Wartość null.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }


    }
}
