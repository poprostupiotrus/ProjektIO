using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace projektIOv2.Controls
{
    /// <summary>
    /// Logika interakcji dla klasy CheckNox
    /// </summary>
    public partial class CheckNox : UserControl
    {
        /// <summary>
        /// Zdarzenie wywoływane po kliknięciu kontrolki.
        /// </summary>
        public event EventHandler<RoutedEventArgs> Click;

        /// <summary>
        /// Zdarzenie wywoływane po zaznaczeniu kontrolki.
        /// </summary>
        public event EventHandler<RoutedEventArgs> Checked;

        /// <summary>
        /// Zdarzenie wywoływane po odznaczeniu kontrolki.
        /// </summary>
        public event EventHandler<RoutedEventArgs> Unchecked;
        CheckBox checkBox;

        /// <summary>
        /// Inicjalizuje nową instancję kontrolki CheckNox.
        /// </summary>
        public CheckNox()
        {
            InitializeComponent();
            checkBox = (CheckBox)FindName("checkBox");

        }

        /// <summary>
        /// Pobiera lub ustawia geometrię ikony.
        /// </summary>
        public PathGeometry Icon
        {
            get { return (PathGeometry)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        /// <summary>
        /// Właściwość zależności reprezentująca geometrię ikony.
        /// </summary>
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(PathGeometry), typeof(CheckNox));

        /// <summary>
        /// Pobiera lub ustawia promień zaokrąglenia narożników kontrolki.
        /// </summary>
        public int BorderRadius
        {
            get { return (int)GetValue(BorderRadiusProperty); }
            set { SetValue(BorderRadiusProperty, value); }
        }

        /// <summary>
        /// Właściwość zależności reprezentująca promień zaokrąglenia narożników kontrolki.
        /// </summary>
        public static readonly DependencyProperty BorderRadiusProperty =
            DependencyProperty.Register("BorderRadius", typeof(int), typeof(CheckNox));

        /// <summary>
        /// Pobiera lub ustawia szerokość ikony.
        /// </summary>
        public int IconWidth
        {
            get { return (int)GetValue(IconWidthProperty); }
            set { SetValue(IconWidthProperty, value); }
        }

        /// <summary>
        ///  Właściwość zależności reprezentująca szerokość ikony.
        /// </summary>
        public static readonly DependencyProperty IconWidthProperty =
            DependencyProperty.Register("IconWidth", typeof(int), typeof(CheckNox));


        /// <summary>
        /// Pobiera lub ustawia pędzel wskaźnika.
        /// </summary>
        public SolidColorBrush IndicatorBrush
        {
            get { return (SolidColorBrush)GetValue(IndicatorBrushProperty); }
            set { SetValue(IndicatorBrushProperty, value); }
        }

        /// <summary>
        /// Właściwość zależności reprezentująca pędzel wskaźnika.
        /// </summary>
        public static readonly DependencyProperty IndicatorBrushProperty =
            DependencyProperty.Register("IndicatorBrush", typeof(SolidColorBrush), typeof(CheckNox));


        /// <summary>
        /// Pobiera lub ustawia promień zaokrąglenia wskaźnika.
        /// </summary>
        public int IndicatorIndicatorCornerRadius
        {
            get { return (int)GetValue(IndicatorIndicatorCornerRadiusProperty); }
            set { SetValue(IndicatorIndicatorCornerRadiusProperty, value); }
        }

        /// <summary>
        /// Właściwość zależności reprezentująca promień zaokrąglenia wskaźnika.
        /// </summary>
        public static readonly DependencyProperty IndicatorIndicatorCornerRadiusProperty =
            DependencyProperty.Register("IndicatorIndicatorCornerRadius", typeof(int), typeof(CheckNox));


        /// <summary>
        /// Pobiera lub ustawia tekst kontrolki.
        /// </summary>
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        /// <summary>
        /// Właściwość zależności reprezentująca tekst kontrolki.
        /// </summary>
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(CheckNox));


        /// <summary>
        /// Pobiera lub ustawia margines kontrolki.
        /// </summary>
        public new Thickness Padding
        {
            get { return (Thickness)GetValue(PaddingProperty); }
            set { SetValue(PaddingProperty, value); }
        }

        /// <summary>
        /// Właściwość zależności reprezentująca margines kontrolki.
        /// </summary>
        public static new readonly DependencyProperty PaddingProperty =
            DependencyProperty.Register("Padding", typeof(Thickness), typeof(CheckNox));


        /// <summary>
        /// Pobiera lub ustawia wartość wskazującą, czy kontrolka jest zaznaczona.
        /// </summary>
        public bool IsSelected
        {
            get { return (bool)GetValue(IsSelectedProperty); }
            set
            {
                SetValue(IsSelectedProperty, value);
            }
        }

        /// <summary>
        /// Właściwość zależności reprezentująca wartość wskazującą, czy kontrolka jest zaznaczona.
        /// </summary>
        public static readonly DependencyProperty IsSelectedProperty =
            DependencyProperty.Register("IsSelected", typeof(bool), typeof(CheckNox));

        /// <summary>
        /// Metoda wywoływana po zaznaczeniu CheckBox'a.
        /// </summary>
        /// <param name="e">Argumenty zdarzenia.</param>
        protected virtual void OnChecked(RoutedEventArgs e)
        {
            Checked?.Invoke(this, e);
        }

        /// <summary>
        /// Metoda wywoływana po odznaczeniu CheckBox'a.
        /// </summary>
        /// <param name="e">Argumenty zdarzenia.</param>
        protected virtual void OnUnchecked(RoutedEventArgs e)
        {
            Unchecked?.Invoke(this, e);
        }

        /// <summary>
        /// Obsługuje zdarzenie Checked CheckBox'a.
        /// </summary>
        /// <param name="sender">Źródło zdarzenia.</param>
        /// <param name="e">Argumenty zdarzenia.</param>
        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
        {
            OnChecked(new RoutedEventArgs());
        }

        /// <summary>
        /// Obsługuje zdarzenie Unchecked CheckBox'a.
        /// </summary>
        /// <param name="sender">Źródło zdarzenia.</param>
        /// <param name="e">Argumenty zdarzenia.</param>
        private void CheckBox_Unchecked_1(object sender, RoutedEventArgs e)
        {
            OnUnchecked(new RoutedEventArgs());
        }
    }
}
