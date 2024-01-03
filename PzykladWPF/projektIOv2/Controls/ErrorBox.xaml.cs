using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Logika interakcji dla klasy ErrorBox.xaml
    /// </summary>
    public partial class ErrorBox : UserControl, INotifyPropertyChanged
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set
            {
                if (errorMessage != value)
                {
                    errorMessage = value;
                    OnPropertyChanged(nameof(ErrorMessage));
                }
            }
        }
        public event EventHandler ButtonClicked;
        public event PropertyChangedEventHandler? PropertyChanged;


        public ErrorBox()
        {
            InitializeComponent();
            DataContext = this;
        }
        private void CloseButtonClick(object sender, RoutedEventArgs e)
        {
            ButtonClicked?.Invoke(this, EventArgs.Empty);
            Visibility = Visibility.Hidden;
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
