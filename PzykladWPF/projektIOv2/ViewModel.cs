using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using LiveCharts.Events;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;
using System.Collections.Generic;
using LiveCharts.Defaults;
using System.Globalization;
using System.Linq;

namespace projektIOv2
{
    public class ViewModel : INotifyPropertyChanged
    {
        private DaneSpolek daneSpolek;
        public List<string> wszystkieDaty;
        private CartesianChart chart;
        public bool czyWykresProcentowy = false;
        private List<(Spolka, SolidColorBrush)> listaWykresow;
        public int MinIndex;
        public int MaxIndex;
        public RelayCommand<PreviewRangeChangedEventArgs> XRangeChangedCommand
        {
            get;
            private set;
        }
        public ViewModel(CartesianChart cartesianChart)
        {
            chart = cartesianChart;
            listaWykresow = new List<(Spolka, SolidColorBrush)>();
            daneSpolek = new DaneSpolek();

            wszystkieDaty = new List<string>();
            foreach (Spolka spolka in daneSpolek.ListaSpolek)
            {
                foreach (KeyValuePair<DateTime, double> pair in spolka.Notowania)
                {
                    wszystkieDaty.Add(pair.Key.ToString("dd.MM.yyyy HH.mm"));
                }
            }
            wszystkieDaty = wszystkieDaty.Distinct().ToList();
            wszystkieDaty.Sort();
            chart.AxisX.Clear();
            chart.AxisX.Add(new Axis
            {
                Title = "Data",
                Labels = wszystkieDaty
            });
            TimeStampMinHour = DateTime.ParseExact(wszystkieDaty[0], "dd.MM.yyyy HH.mm", CultureInfo.InvariantCulture);
            TimeStampMaxHour = DateTime.ParseExact(wszystkieDaty[wszystkieDaty.Count-1], "dd.MM.yyyy HH.mm", CultureInfo.InvariantCulture);

            MinIndex = 0;
            MaxIndex = wszystkieDaty.Count - 1;

            chart.AxisY.Add(new Axis
            {
                Title = "Wartość akcji [zł]"
            });
        }
        public DateTime TimeStampMin { get => timeStampMin; set {                   
                    timeStampMin = new DateTime(value.Year,value.Month,value.Day,timeStampMin.Hour,timeStampMin.Minute,0); OnPropertyChanged(nameof(TimeStampMin)); } } 
        public DateTime TimeStampMax { get => timeStampMax; set { 
                timeStampMax = new DateTime(value.Year, value.Month, value.Day, timeStampMax.Hour, timeStampMax.Minute, 0); OnPropertyChanged(nameof(TimeStampMax)); } }
        public DateTime TimeStampMinHour { set {timeStampMin = new DateTime(value.Year, value.Month, value.Day, value.Hour, value.Minute, 0); OnPropertyChanged(nameof(TimeStampMin)); } }
        public DateTime TimeStampMaxHour { set {timeStampMax = new DateTime(value.Year, value.Month, value.Day, value.Hour, value.Minute, 0); OnPropertyChanged(nameof(TimeStampMax)); } }
        private DateTime timeStampMax;
        private DateTime timeStampMin;
        public void AddSeriesToChart(string nazwa, SolidColorBrush brush)
        {
            Spolka spolka = daneSpolek.ZnajdzSpolkePoNazwie(nazwa);
            listaWykresow.Add((spolka,brush));
            if(listaWykresow.Count>1)
            {
                czyWykresProcentowy = true;
                chart.AxisY.Clear();
                chart.AxisY.Add(new Axis
                {
                    Title = "Zmiana kursu akcji względem pierwszej wybranej daty [%]"
                });
            }
            generateChart();
        }
        public async void generateChart()
        {
            chart.Series.Clear();
            foreach((Spolka, SolidColorBrush) pair in listaWykresow)
            {
                ChartValues<ObservablePoint> points = await getChartValuesAsync(pair.Item1.Notowania);
                await Application.Current.Dispatcher.InvokeAsync(() => { addAfterAsync(points, pair.Item1.Nazwa, pair.Item2); });
            }
        }
        public async Task<ChartValues<ObservablePoint>> getChartValuesAsync(Dictionary<DateTime,double> Notowania)
        {
            return await Task.Run(() =>
            {
                ChartValues<ObservablePoint> listapunktow = new ChartValues<ObservablePoint>();
                DateTime pierwszaData = DateTime.ParseExact(wszystkieDaty[MinIndex], "dd.MM.yyyy HH.mm", CultureInfo.InvariantCulture);
                double dzielnik;
                if (czyWykresProcentowy)
                {
                    dzielnik = 0.01 * Notowania[pierwszaData];
                }
                else
                {
                    dzielnik = 1;
                }
                //Dla każdej daty sprawdź czy dla niej jest notowanie
                for (int i = 0; i < wszystkieDaty.Count-1; i++)
                {
                    DateTime data = DateTime.ParseExact(wszystkieDaty[i], "dd.MM.yyyy HH.mm", CultureInfo.InvariantCulture);
                    if (Notowania.ContainsKey(data) && Notowania[data] != 0)
                    {
                        listapunktow.Add(new ObservablePoint(i, Math.Round(Notowania[data] / dzielnik, 2)));
                    }
                }
                return listapunktow;
            });
        }
        public void addAfterAsync(ChartValues<ObservablePoint> values, string nazwa, SolidColorBrush brush)
        {
            LineSeries series = new LineSeries();
            series.Values = values;
            series.Title = nazwa;
            series.PointGeometry = null;
            series.Fill = Brushes.Transparent;
            series.Stroke = brush;
            series.LineSmoothness = 0;
            chart.Series.Add(series);
        }
        public void removeSeries(string nazwa)
        {
            (Spolka, SolidColorBrush) Spolka = default;
            foreach ((Spolka,SolidColorBrush) pair in listaWykresow)
            {
                if(pair.Item1.Nazwa==nazwa)
                {
                    Spolka = pair;
                }
            }
            if(Spolka != default)
            listaWykresow.Remove(Spolka);
            if(listaWykresow.Count<2)
            {
                czyWykresProcentowy = false;
                chart.AxisY.Clear();
                chart.AxisY.Add(new Axis
                {
                    Title = "Wartość akcji [zł]"
                });
            }
            generateChart();
        }
        public event PropertyChangedEventHandler? PropertyChanged;

        public virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public int FindIndexFromBeginning(DateTime givenDate)
        {
            MinIndex = 0;
            DateTime date;
            for (int i=0;i<wszystkieDaty.Count;i++)
            {
                date = DateTime.ParseExact(wszystkieDaty[MinIndex], "dd.MM.yyyy HH.mm", CultureInfo.InvariantCulture);
                if(DateTime.Compare(givenDate,date)>0)
                {
                    MinIndex++;
                }
                else
                {
                    break;
                }
            }
            return MinIndex;
        }
        public int FindIndexFromEnd(DateTime givenDate)
        {
            MaxIndex = wszystkieDaty.Count-1;
            for (int i = wszystkieDaty.Count-1;i>0;i--)
            {
                DateTime date = DateTime.ParseExact(wszystkieDaty[MaxIndex], "dd.MM.yyyy HH.mm", CultureInfo.InvariantCulture);
                if (DateTime.Compare(givenDate, date) < 0)
                {
                    MaxIndex--;
                }
                else
                {
                    break;
                }
            }
            return MaxIndex;
        }
    }
}