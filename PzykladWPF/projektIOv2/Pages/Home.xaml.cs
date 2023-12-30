
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

using projektIOv2.Themes;
using projektIOv2.Controls;
using projektIOv2.wykres;
using System.Windows.Threading;

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
            viewModel = new ViewModel();

            this.DataContext = viewModel;
            stockChart.Series = viewModel.Series;

            viewModel.AddSeries("ALIOR");

        }




        private async void CheckNox_Checked(object sender, RoutedEventArgs e)
        {
            if (viewModel == null) return;
            var t1 = (sender as CheckNox)?.Text;
            //viewModel.AddSeries(t1);
            if (t1 != null)
            {
                ChartValues<NDatePoint> series = await viewModel.getSeriesAsync(t1);
                // stockChart.Dispatcher.BeginInvoke((Action)(() => { viewModel.AddSeries(t1); }));
                await Application.Current.Dispatcher.InvokeAsync(() => { viewModel.addafterasync(series, t1); });
            }
        }



        private void CheckNox_Unchecked(object sender, RoutedEventArgs e)
        {
            if (viewModel == null) return;
            var t1 = (sender as CheckNox).Text;
            viewModel.removeSeries(t1);
        }

        private void StartDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

            fmt.MinValue = new NDate(viewModel.TimeStampMin).Ticks;

        }

        private void EndDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

            fmt.MaxValue = new NDate(viewModel.TimeStampMax).Ticks;
        }
    }
}
