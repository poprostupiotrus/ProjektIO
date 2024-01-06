using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using projektIOv2.Controls;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace projektIOv2.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy Home.xaml
    /// </summary>    
    public partial class Home : Page
    {
        ViewModel viewModel;
        public Home()
        {
            InitializeComponent();
            
            viewModel = new ViewModel(stockChart);
            DataContext = viewModel;
            viewModel.AddSeriesToChart("ALIOR", (SolidColorBrush)new BrushConverter().ConvertFrom("#07f045"));

        }
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
        private void CheckNox_Unchecked(object sender, RoutedEventArgs e)
        {
            if (viewModel == null) return;
            var t1 = (sender as CheckNox).Text;
            viewModel.removeSeries(t1);
        }
        private int test = 0; //Z jakiegoś powodu ten event jest uruchamiany 3 za każdym razem jak zmieniasz date
        //Więc ta zmienna upewnia się że będzie wykonany tylko 1 raz
        private void StartDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (viewModel.TimeStampMax != viewModel.TimeStampMin)
            {
                if (test == 0)
                {
                    if(viewModel.czyWykresProcentowy)
                    {
                        stockChart.AxisX[0].MinValue = viewModel.FindIndexFromBeginning(viewModel.TimeStampMin);
                        viewModel.generateChart();
                    }
                    else
                    {
                        stockChart.AxisX[0].MinValue = viewModel.FindIndexFromBeginning(viewModel.TimeStampMin);
                    }
                }
                test++;
                if (test == 3)
                    test = 0;
            }
        }
        private void EndDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (viewModel.TimeStampMax != viewModel.TimeStampMin)
                stockChart.AxisX[0].MaxValue = viewModel.FindIndexFromEnd(viewModel.TimeStampMax);
        }
        private int test2 = 0;//tutaj wydarzenie jest aktywowane 2 razy
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
                            viewModel.generateChart();
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

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //
        }
    }
}
