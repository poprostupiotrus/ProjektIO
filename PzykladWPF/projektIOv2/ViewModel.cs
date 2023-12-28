using LiveCharts;
using LiveCharts.Configurations;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System.Linq;
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
using System.Diagnostics;
using System.Globalization;
using LiveCharts.Events;
using CommunityToolkit.Mvvm.Input;
using static System.Net.Mime.MediaTypeNames;

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
           // XRangeChangedCommand = new RelayCommand<PreviewRangeChangedEventArgs>(e => XRangeChanged(e));
           
            DaneSpolek spolek = new DaneSpolek();
            Spolka sp1 = spolek.ZnajdzSpolkePoNazwie("ALIOR");
            ChartValues<DateTimePoint> wals = new ChartValues<DateTimePoint>();
            var mindate = new DateTime(TimeStampMin.Year, TimeStampMin.Month, TimeStampMin.Day);
            var maxdate = new DateTime(TimeStampMax.Year, TimeStampMax.Month, TimeStampMax.Day, 23, 59, 59);
            foreach (var item in sp1.Notowania)
            {
                //Trace.WriteLine(item.Key);
                if(item.Key>=mindate && item.Key<=maxdate)
                wals.Add(new DateTimePoint(item.Key, item.Value));
            }
            LineSeries s1 = new LineSeries();
            s1.Values = wals;
            s1.Title = sp1.Nazwa;
            s1.Fill = Brushes.Transparent;
            s1.PointGeometry = null;
            var dayConfig = Mappers.Xy<DateTimePoint>()
          .X(dateModel => dateModel.DateTime.Ticks / TimeSpan.FromMinutes(1).Ticks)
          .Y(dateModel => dateModel.Value);

            Series = new SeriesCollection(dayConfig)
        {s1};
            //s1.Values.Remove(XamlGeneratedNamespace );
            Formatter = value => new System.DateTime((long)(value * TimeSpan.FromMinutes(1).Ticks)).ToString("G");
            //TimeStampMin = new DateTime(2023, 11, 7, 0, 0, 0);
           // TimeStampMax = new DateTime(2023, 11, 12, 0, 0, 0);

            //stockChart.Series = Series;
            //fmt.LabelFormatter = Formatter;

        }

        public DateTime TimeStampMin { get => timeStampMin; set { if (value != null) timeStampMin = value; update(); } }
        public DateTime TimeStampMax { get => timeStampMax; set { if (value != null) timeStampMax = value; update(); } }
        private DateTime timeStampMax = new DateTime(2023, 11, 13, 23, 59, 59);
        private DateTime timeStampMin = new DateTime(2023, 11, 10);


        /* public void XRangeChanged(PreviewRangeChangedEventArgs e)
         {
             TimeStampMin = DateTime.FromBinary((long)e.PreviewMinValue);
             TimeStampMax = DateTime.FromBinary((long)e.PreviewMaxValue);
         }*/


        /*public DateTime GetMinDate()
        {
            IEnumerable<DateTime> allDates = Series
                .SelectMany(serie => ((LineSeries)serie).Values.Select(point => point.DateTime));

            return allDates.Min();
        }
        
        public DateTime GetMaxDate()
        {
            IEnumerable<DateTime> allDates = Series
                .SelectMany(serie => ((LineSeries)serie).Values.Select(point => point.DateTime));

            return allDates.Max();
        }*/

        public void AddSeries(String txt)
        {
            if (SeriesExists(txt)) return;
            DaneSpolek spolek = new DaneSpolek();
            Spolka sp1 = spolek.ZnajdzSpolkePoNazwie(txt);
            ChartValues<DateTimePoint> wals = new ChartValues<DateTimePoint>();
            var mindate = new DateTime(TimeStampMin.Year, TimeStampMin.Month, TimeStampMin.Day);
            var maxdate = new DateTime(TimeStampMax.Year, TimeStampMax.Month, TimeStampMax.Day, 23, 59, 59);
            if(sp1!=null)
            {
                foreach (var item in sp1.Notowania)
                {
                    //Trace.WriteLine(item.Key);
                    if (item.Key >= mindate && item.Key <= maxdate)
                        wals.Add(new DateTimePoint(item.Key, item.Value));

                }
                LineSeries s1 = new LineSeries();
                s1.Values = wals;
                s1.Title = txt;
                s1.PointGeometry = null;
                s1.Fill = Brushes.Transparent;
                Series.Add(s1);
            }
        }

        public bool SeriesExists(String txt)
        {
            foreach (var item in Series)
            {
                if ((item as LineSeries).Name.Equals(txt)) return true;
            }
            return false;
        }
        public void removeSeries(String txt)
        {
            foreach (var item in Series)
            {
                if ((item as LineSeries).Title.Equals(txt)) Series.Remove(item);
            }

        }

        public void update()
        {

            if (Series == null) return;
            

            foreach (var item in Series)
            {
                var name = (item as LineSeries).Title;
                    if (name == null || name == "") return;
                //MessageBox.Show(name);
                Series.Remove(item);
                AddSeries(name);
            }
        }
    }
    public class DateTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var t1 = ((DateTime)value);
            var t2 = new DateTime(1, 1, 1);
            long t3 = (t1 - t2).Hours;
            Trace.WriteLine($"{t1}");
            return t3;
        }



        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }


    }
}