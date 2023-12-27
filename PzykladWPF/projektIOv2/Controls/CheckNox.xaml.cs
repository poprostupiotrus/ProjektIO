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
    /// Logika interakcji dla klasy CheckNox.xaml
    /// </summary>
    public partial class CheckNox : UserControl
    {
        public event EventHandler<RoutedEventArgs> Click;
        public event EventHandler<RoutedEventArgs> Checked;
        public event EventHandler<RoutedEventArgs> Unchecked;
        CheckBox checkBox;
        public CheckNox()
        {
            InitializeComponent();
            checkBox = (CheckBox)FindName("checkBox");

        }

        public PathGeometry Icon
        {
            get { return (PathGeometry)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }


        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(PathGeometry), typeof(CheckNox));

        public int BorderRadius
        {
            get { return (int)GetValue(BorderRadiusProperty); }
            set { SetValue(BorderRadiusProperty, value); }
        }


        public static readonly DependencyProperty BorderRadiusProperty =
            DependencyProperty.Register("BorderRadius", typeof(int), typeof(CheckNox));


        public int IconWidth
        {
            get { return (int)GetValue(IconWidthProperty); }
            set { SetValue(IconWidthProperty, value); }
        }

        public static readonly DependencyProperty IconWidthProperty =
            DependencyProperty.Register("IconWidth", typeof(int), typeof(CheckNox));



        public SolidColorBrush IndicatorBrush
        {
            get { return (SolidColorBrush)GetValue(IndicatorBrushProperty); }
            set { SetValue(IndicatorBrushProperty, value); }
        }


        public static readonly DependencyProperty IndicatorBrushProperty =
            DependencyProperty.Register("IndicatorBrush", typeof(SolidColorBrush), typeof(CheckNox));



        public int IndicatorIndicatorCornerRadius
        {
            get { return (int)GetValue(IndicatorIndicatorCornerRadiusProperty); }
            set { SetValue(IndicatorIndicatorCornerRadiusProperty, value); }
        }


        public static readonly DependencyProperty IndicatorIndicatorCornerRadiusProperty =
            DependencyProperty.Register("IndicatorIndicatorCornerRadius", typeof(int), typeof(CheckNox));



        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }


        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(CheckNox));



        public new Thickness Padding
        {
            get { return (Thickness)GetValue(PaddingProperty); }
            set { SetValue(PaddingProperty, value); }
        }


        public static new readonly DependencyProperty PaddingProperty =
            DependencyProperty.Register("Padding", typeof(Thickness), typeof(CheckNox));



        public bool IsSelected
        {
            get { return (bool)GetValue(IsSelectedProperty); }
            set
            {
                SetValue(IsSelectedProperty, value);
            }
        }


        public static readonly DependencyProperty IsSelectedProperty =
            DependencyProperty.Register("IsSelected", typeof(bool), typeof(CheckNox));


        protected virtual void OnChecked(RoutedEventArgs e)
        {
            Checked?.Invoke(this, e);
        }

        protected virtual void OnUnchecked(RoutedEventArgs e)
        {
            Unchecked?.Invoke(this, e);
        }

        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
        {
            OnChecked(new RoutedEventArgs());
        }

        private void CheckBox_Unchecked_1(object sender, RoutedEventArgs e)
        {
            OnUnchecked(new RoutedEventArgs());
        }
    }
}
