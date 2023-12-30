using LiveCharts;
using LiveCharts.Configurations;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Diagnostics;
using System.Globalization;
using LiveCharts.Events;
using CommunityToolkit.Mvvm.Input;
using static System.Net.Mime.MediaTypeNames;
using projektIOv2.wykres;
using System.Threading;

namespace projektIOv2
{
    public class ViewModel
    {
        public Func<double, string> Formatter { get; set; }
        public SeriesCollection Series;
        public RelayCommand<PreviewRangeChangedEventArgs> XRangeChangedCommand
        {
            get;
            private set;
        }
        LineSeries l1;
        public ViewModel()
        {

            var dayConfig = Mappers.Xy<NDatePoint>()
          .X(dateModel => dateModel.NDate.Ticks)
          .Y(dateModel => dateModel.Value);

            Series = new SeriesCollection(dayConfig);


            Formatter = value => NDate.toString((long)value);



        }

        public DateTime TimeStampMin { get => timeStampMin; set { if (value != null) { timeStampMin = value; } } }
        public DateTime TimeStampMax { get => timeStampMax; set { if (value != null) { timeStampMax = value; } } }
        private DateTime timeStampMax = new DateTime(2023, 11, 13, 23, 59, 59);
        private DateTime timeStampMin = new DateTime(2023, 11, 10);




        public void AddSeries(String txt)
        {
            if (IfExistMakeVisible(txt)) return;
            DaneSpolek spolek = new DaneSpolek();
            Spolka sp1 = spolek.ZnajdzSpolkePoNazwie(txt);
            ChartValues<NDatePoint> wals = new ChartValues<NDatePoint>();
            var mindate = new DateTime(TimeStampMin.Year, TimeStampMin.Month, TimeStampMin.Day);
            var maxdate = new DateTime(TimeStampMax.Year, TimeStampMax.Month, TimeStampMax.Day, 23, 59, 59);
            if (sp1 != null)
            {
                foreach (var item in sp1.Notowania)
                {
                    if(item.Key.Hour<17)
                    wals.Add(new NDatePoint(item.Key, Math.Round(item.Value, 2)));

                }
                LineSeries s1 = new LineSeries();
                s1.Values = wals;
                s1.Title = txt;
                s1.PointGeometry = null;
                s1.Fill = Brushes.Transparent;
                s1.LineSmoothness = 0;
                Series.Add(s1);
            }
        }
        public async Task<ChartValues<NDatePoint>> getSeriesAsync(string txt)
        {
            return await Task.Run(() =>
            {
                DaneSpolek spolek = new DaneSpolek();
                Spolka sp1 = spolek.ZnajdzSpolkePoNazwie(txt);
                ChartValues<NDatePoint> wals = new ChartValues<NDatePoint>();

                foreach (var item in sp1.Notowania)
                {
                    wals.Add(new NDatePoint(item.Key, Math.Round(item.Value, 2)));
                }

                return wals;
            });
        }
        public void addafterasync(ChartValues<NDatePoint> wals, String txt)
        {
            LineSeries s1 = new LineSeries();
            s1.Values = wals;
            s1.Title = txt;
            s1.PointGeometry = null;
            s1.Fill = Brushes.Transparent;
            s1.LineSmoothness = 0;
            Series.Add(s1);
        }
        public bool IfExistMakeVisible(String txt)
        {
            foreach (var item in Series)
            {
                if ((item as LineSeries).Name.Equals(txt))
                {
                    (item as LineSeries).Visibility = Visibility.Visible;
                    return true;
                }
            }
            return false;
        }
        public void removeSeries(String txt)
        {
            foreach (var item in Series)
            {
                if ((item as LineSeries).Title.Equals(txt)) (item as LineSeries).Visibility = Visibility.Hidden;
            }

        }


    }

}