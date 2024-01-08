using System;
using System.Windows;
using System.Windows.Controls;
using projektIOv2.Controls;
using System.Text.RegularExpressions;
using System.Globalization;

namespace projektIOv2.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy Home.xaml
    /// </summary>    
    public partial class Home : Page
    {
        public ViewModel viewModel;
        /// <summary>
        /// Konstruktor inicjalizujący strone Home i obiekt ViewModel
        /// </summary>
        public Home()
        {
            InitializeComponent();
            
            viewModel = new ViewModel(stockChart);
            DataContext = viewModel;
        }
        /// <summary>
        /// Wydarzenie wciśniecia przycisku
        /// </summary>
        /// <param name="sender">Przycisk, który jest wciśnięty</param>
        /// <param name="e">Argumenty wydarzenia</param>
        private void CheckNox_Checked(object sender, RoutedEventArgs e)
        {
            if (viewModel == null) return;
            var text = (sender as CheckNox)?.Text;
            var brush = (sender as CheckNox).IndicatorBrush;

            if (text != null)
            {
                viewModel.AddSeriesToChart(text, brush);
            }
        }
        /// <summary>
        /// Wydarzenie odciśnięcia przycisku
        /// </summary>
        /// <param name="sender">Przycisk, który został odciśnięty</param>
        /// <param name="e">Argumenty wydarzenia</param>
        private void CheckNox_Unchecked(object sender, RoutedEventArgs e)
        {
            if (viewModel == null) return;
            var t1 = (sender as CheckNox).Text;
            viewModel.removeSeries(t1);
        }
        private int test = 0; //Z jakiegoś powodu ten event jest uruchamiany 3 za każdym razem jak zmieniasz date
        //Więc ta zmienna upewnia się że będzie wykonany tylko 1 raz
        /// <summary>
        /// Wydarzenie zmiany daty początkowej
        /// </summary>
        /// <param name="sender">Data początkowa</param>
        /// <param name="e">Argumenty wydarzenia</param>
        private void StartDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            //Upewnia się że nie można wybrać wcześniejszej daty niż pierwsza
            if (DateTime.Compare(viewModel.TimeStampMin, DateTime.ParseExact(viewModel.wszystkieDaty[0], "dd.MM.yyyy HH.mm", CultureInfo.InvariantCulture))<0)
            {
                viewModel.TimeStampMinHour = DateTime.ParseExact(viewModel.wszystkieDaty[0], "dd.MM.yyyy HH.mm", CultureInfo.InvariantCulture);
                StartDate.SelectedDate = viewModel.TimeStampMin;
                StartHour.Text = viewModel.TimeStampMinHour.ToString("HH:mm");
            }
            //Upernia się że wybrana dana min nie jest większa od max
            if(DateTime.Compare(viewModel.TimeStampMinHour,viewModel.TimeStampMaxHour.AddMinutes(-30))>=0)
            {
                viewModel.TimeStampMinHour = viewModel.TimeStampMaxHour.AddMinutes(-30);
                StartDate.SelectedDate = viewModel.TimeStampMin;
                StartHour.Text = viewModel.TimeStampMinHour.ToString("HH:mm");
            }
            if (test == 0)
            {
                stockChart.AxisX[0].MinValue = viewModel.FindIndexFromBeginning(viewModel.TimeStampMin);
                viewModel.UpdateChart();
            }
            test++;
            if (test == 3)
                test = 0;
        }
        int test3 = 0;
        /// <summary>
        /// Wydarzenie zmiany daty końcowej
        /// </summary>
        /// <param name="sender">Data końcowa</param>
        /// <param name="e">Argumenty wydarzenia</param>
        private void EndDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            //Upewnia się że nie można wybrać późniejszej daty niż ostatnia
            if(DateTime.Compare(viewModel.TimeStampMax, DateTime.ParseExact(viewModel.wszystkieDaty[viewModel.wszystkieDaty.Count-1], "dd.MM.yyyy HH.mm", CultureInfo.InvariantCulture)) > 0)
            {
                viewModel.TimeStampMaxHour = DateTime.ParseExact(viewModel.wszystkieDaty[viewModel.wszystkieDaty.Count-1], "dd.MM.yyyy HH.mm", CultureInfo.InvariantCulture);
                EndDate.SelectedDate = viewModel.TimeStampMax;
                EndHour.Text = viewModel.TimeStampMaxHour.ToString("HH:mm");
            }
            //Upernia się że wybrana dana max nie jest mniejsza od min
            if (DateTime.Compare(viewModel.TimeStampMaxHour,viewModel.TimeStampMinHour.AddMinutes(30))<=0)
            {
                viewModel.TimeStampMaxHour = viewModel.TimeStampMinHour.AddMinutes(30);
                EndDate.SelectedDate = viewModel.TimeStampMax;
                EndHour.Text = viewModel.TimeStampMaxHour.ToString("HH:mm");
            }
            if(test3==0)
            {
                stockChart.AxisX[0].MaxValue = viewModel.FindIndexFromEnd(viewModel.TimeStampMax);
                viewModel.UpdateChart();
            }
            test3++;
            if (test3 == 3)
                test3 = 0;
        }
        private int test2 = 0;//tutaj wydarzenie jest aktywowane 2 razy
        /// <summary>
        /// Wydarzenie zmiany godziny
        /// </summary>
        /// <param name="sender">TextBox, który został zmieniony</param>
        /// <param name="e">Argumenty wydarzenia</param>
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textbox = sender as TextBox;
            string pattern = @"^\d{1,2}:\d{2}$";
            
            if(Regex.IsMatch(textbox.Text.Trim(), pattern) )
            {
                DateTime dt;
                DateTime.TryParseExact(textbox.Text.Trim(), "HH:mm", null, System.Globalization.DateTimeStyles.None, out dt);
                if (textbox.Name=="nH")
                {
                    viewModel.TimeStampMinHour = new DateTime(viewModel.TimeStampMin.Year,viewModel.TimeStampMin.Month,viewModel.TimeStampMin.Day,dt.Hour,dt.Minute,0);
                    if ((viewModel.TimeStampMax != viewModel.TimeStampMin))
                    {
                        if(test2==0)
                        {
                            stockChart.AxisX[0].MinValue = viewModel.FindIndexFromBeginning(viewModel.TimeStampMin);
                            viewModel.UpdateChart();
                        }
                        test2++;
                        if (test2 == 2)
                            test2 = 0;
                    }

                }
                if (textbox.Name == "xH")
                {
                    viewModel.TimeStampMaxHour = new DateTime(viewModel.TimeStampMax.Year, viewModel.TimeStampMax.Month, viewModel.TimeStampMax.Day, dt.Hour, dt.Minute, 0);
                    if ((viewModel.TimeStampMax != viewModel.TimeStampMin))
                        stockChart.AxisX[0].MaxValue = viewModel.FindIndexFromEnd(viewModel.TimeStampMax);
                }
            }
        }
        /// <summary>
        /// Wydarzenie które aktywuję się jak wczyta się cała strona
        /// </summary>
        /// <param name="sender">obiekt Home</param>
        /// <param name="e">Argumenty wydarzenia</param>
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Button_alior.IsSelected = true;
        }
    }
}
