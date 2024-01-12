using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace projektIOv2.Controls
{

    /// <summary>
    /// Kontrolka reprezentująca niestandardową pozycję menu.
    /// </summary>
    public partial class MenuItem : UserControl
    {
        /// <summary>
        /// Konstruktor inicjalizuje nową instancję klasy MenuItem.
        /// </summary>
        public MenuItem()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Pobiera lub ustawia geometrię ikony.
        /// </summary>
        public PathGeometry Icon
        {
            get { return (PathGeometry)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Icon.  This enables animation, styling, binding, etc...
        /// <summary>
        /// Właściwość zależności reprezentująca geometrię ikony.
        /// </summary>
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(PathGeometry), typeof(MenuItem));


        /// <summary>
        /// Pobiera lub ustawia szerokość ikony.
        /// </summary>
        public int IconWidth
        {
            get { return (int)GetValue(IconWidthProperty); }
            set { SetValue(IconWidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IconWidth.  This enables animation, styling, binding, etc...
        /// <summary>
        /// Właściwość zależności reprezentująca szerokość ikony.
        /// </summary>
        public static readonly DependencyProperty IconWidthProperty =
            DependencyProperty.Register("IconWidth", typeof(int), typeof(MenuItem));


        /// <summary>
        /// Pobiera lub ustawia pędzel wskaźnika.
        /// </summary>
        public SolidColorBrush IndicatorBrush
        {
            get { return (SolidColorBrush)GetValue(IndicatorBrushProperty); }
            set { SetValue(IndicatorBrushProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IndicatorBrush.  This enables animation, styling, binding, etc...
        /// <summary>
        /// Właściwość zależności reprezentująca pędzel wskaźnika.
        /// </summary>
        public static readonly DependencyProperty IndicatorBrushProperty =
            DependencyProperty.Register("IndicatorBrush", typeof(SolidColorBrush), typeof(MenuItem));


        /// <summary>
        /// Pobiera lub ustawia promień zaokrąglenia wskaźnika.
        /// </summary>
        public int IndicatorIndicatorCornerRadius
        {
            get { return (int)GetValue(IndicatorIndicatorCornerRadiusProperty); }
            set { SetValue(IndicatorIndicatorCornerRadiusProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IndicatorIndicatorCornerRadius.  This enables animation, styling, binding, etc...
        /// <summary>
        /// Właściwość zależności reprezentująca promień zaokrąglenia wskaźnika.
        /// </summary>
        public static readonly DependencyProperty IndicatorIndicatorCornerRadiusProperty =
            DependencyProperty.Register("IndicatorIndicatorCornerRadius", typeof(int), typeof(MenuItem));


        /// <summary>
        /// Pobiera lub ustawia tekst pozycji menu.
        /// </summary>
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        /// <summary>
        /// Właściwość zależności reprezentująca tekst pozycji menu.
        /// </summary>
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(MenuItem));


        /// <summary>
        /// Pobiera lub ustawia margines pozycji menu.
        /// </summary>
        public new Thickness Padding
        {
            get { return (Thickness)GetValue(PaddingProperty); }
            set { SetValue(PaddingProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Padding.  This enables animation, styling, binding, etc...
        /// <summary>
        /// Właściwość zależności reprezentująca margines pozycji menu.
        /// </summary>
        public static new readonly DependencyProperty PaddingProperty =
            DependencyProperty.Register("Padding", typeof(Thickness), typeof(MenuItem));


        /// <summary>
        /// Pobiera lub ustawia wartość wskazującą, czy pozycja menu jest zaznaczona.
        /// </summary>
        public bool IsSelected
        {
            get { return (bool)GetValue(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsSelected.  This enables animation, styling, binding, etc...
        /// <summary>
        /// Właściwość zależności reprezentująca wartość wskazującą, czy pozycja menu jest zaznaczona.
        /// </summary>
        public static readonly DependencyProperty IsSelectedProperty =
            DependencyProperty.Register("IsSelected", typeof(bool), typeof(MenuItem));


        /// <summary>
        /// Pobiera lub ustawia nazwę grupy, do której należy pozycja menu.
        /// </summary>
        public string GroupName
        {
            get { return (string)GetValue(GroupNameProperty); }
            set { SetValue(GroupNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for GroupName.  This enables animation, styling, binding, etc...
        /// <summary>
        /// Właściwość zależności reprezentująca nazwę grupy, do której należy pozycja menu.
        /// </summary>
        public static readonly DependencyProperty GroupNameProperty =
            DependencyProperty.Register("GroupName", typeof(string), typeof(MenuItem));
    }
}
