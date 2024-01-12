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
    /// Logika interakcji dla klasy ErrorBox
    /// </summary>
    public partial class ErrorBox : UserControl, INotifyPropertyChanged
    {
        /// <summary>
        /// Przechowuje treść błędu
        /// </summary>
        private string errorMessage;
        /// <summary>
        /// Pobiera lub ustawia treść błędu.
        /// </summary>
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
        /// <summary>
        /// Konstruktor inicjalizujący wszystkie pola składowe klasy oraz komponenty
        /// </summary>

        public ErrorBox()
        {
            InitializeComponent();
            DataContext = this;
        }
        /// <summary>
        /// Metoda, która jest wywoływana po kliknięciu przycisku "ZAMKNIJ". Wywołuje zdarzenie ButtonClicked i ukrywa customową kontrolke ErrorBox
        /// </summary>
        /// <param name="sender">Obiekt na którym jest wywołane zdarzenie</param>
        /// <param name="e">Argumenty zdarzenia</param>
        private void CloseButtonClick(object sender, RoutedEventArgs e)
        {
            ButtonClicked?.Invoke(this, EventArgs.Empty);
            Visibility = Visibility.Hidden;
        }
        /// <summary>
        /// Metoda wywoływana przy zmianie wartości errorMessage, wywołuje zdarzenie PropertyChanged
        /// </summary>
        /// <param name="propertyName">Przechowuje nazwe własciwości</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
