
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
            //viewModel.XAxes[0].MaxLimit = new DateTime(2021, 1, 6).Ticks;
            //abc.Series = viewModel.Series;
            //abc.XAxes=viewModel.XAxes;
            this.DataContext = viewModel;
            stockChart.Series = viewModel.Series;
            fmt.LabelFormatter = viewModel.Formatter;

        }


        private void CheckNox_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void CheckNox_Checked(object sender, RoutedEventArgs e)
        {
            if (viewModel == null) return;
            var t1 = (sender as CheckNox).Text;
            viewModel.AddSeries(t1);


        }

        private void CheckNox_Unchecked(object sender, RoutedEventArgs e)
        {
            if (viewModel == null) return;
            var t1 = (sender as CheckNox).Text;
            viewModel.removeSeries(t1);
        }

        private void StartDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            viewModel.update();
        }

        private void EndDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

           // viewModel.update();
        }
    }
}
