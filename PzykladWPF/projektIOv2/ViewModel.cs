using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Collections.Generic;
using LiveCharts.Defaults;
using System.Globalization;
using System.Linq;

namespace projektIOv2
{
    /// <summary>
    /// Logika Wykresu
    /// </summary>
    public class ViewModel
    {
        private DaneSpolek daneSpolek;
        public List<string> wszystkieDaty;
        private CartesianChart chart;
        public bool czyWykresProcentowy = false;
        private List<(Spolka, SolidColorBrush)> listaWykresow;
        public int MinIndex;
        public int MaxIndex;
        /// <summary>
        /// Konstruktor ViewModel, który inicjuje dane potrzebne do wyświetlenia wykresu
        /// </summary>
        /// <param name="cartesianChart">Wykres</param>
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
                    timeStampMin = new DateTime(value.Year,value.Month,value.Day,timeStampMin.Hour,timeStampMin.Minute,0); } } 
        public DateTime TimeStampMax { get => timeStampMax; set { 
                timeStampMax = new DateTime(value.Year, value.Month, value.Day, timeStampMax.Hour, timeStampMax.Minute, 0); } }
        public DateTime TimeStampMinHour { get => timeStampMin;
            set {timeStampMin = new DateTime(value.Year, value.Month, value.Day, value.Hour, value.Minute, 0); } }
        public DateTime TimeStampMaxHour { get => timeStampMax;
            set {timeStampMax = new DateTime(value.Year, value.Month, value.Day, value.Hour, value.Minute, 0); } }
        private DateTime timeStampMax;
        private DateTime timeStampMin;
        /// <summary>
        /// Dodaje społke do wykresu
        /// </summary>
        /// <param name="nazwa">Nazwa spółki</param>
        /// <param name="brush">Kolor linii na wykresie</param>
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
            UpdateChart();
        }
        /// <summary>
        /// Aktualizuje wykres
        /// </summary>
        public void UpdateChart()
        {
            chart.Series.Clear();
            foreach ((Spolka, SolidColorBrush) pair in listaWykresow)
            {
                GenerateChart(pair.Item1,pair.Item2);
            }
        }
        /// <summary>
        /// Metoda asynchroniczna, która generuje wykres
        /// </summary>
        /// <param name="spolka">Społka dla, której generuje wykres</param>
        /// <param name="brush">Kolor linii na wykresie</param>
        private async void GenerateChart(Spolka spolka, SolidColorBrush brush)
        {
            ChartValues<ObservablePoint> points = await getChartValuesAsync(spolka.Notowania);
            await Application.Current.Dispatcher.InvokeAsync(() => { addAfterAsync(points, spolka.Nazwa, brush); });
        }
        /// <summary>
        /// Metoda asynchroniczna, która generuje punkty na wykres konkretnej spółki
        /// </summary>
        /// <param name="Notowania">Notowania spółki dla której generuje punkty</param>
        /// <returns>Zwraca Task, który zawiera ChartValues zrobiony z ObservablePoint</returns>
        private async Task<ChartValues<ObservablePoint>> getChartValuesAsync(Dictionary<DateTime,double> Notowania)
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
        /// <summary>
        /// Dodaje punkty na wykres
        /// </summary>
        /// <param name="values">Punkty wykresu</param>
        /// <param name="nazwa">Nazwa danej linii na wykresie</param>
        /// <param name="brush">kolor linni na wykresie</param>
        private void addAfterAsync(ChartValues<ObservablePoint> values, string nazwa, SolidColorBrush brush)
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
        /// <summary>
        /// Usuwa spółke z wykresu
        /// </summary>
        /// <param name="nazwa">Nazwa spółki</param>
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
            UpdateChart();
        }
        /// <summary>
        /// Znajduję indeks równy lub późniejszy dla danej daty
        /// </summary>
        /// <param name="givenDate">Data dla, której szuka indeksu</param>
        /// <returns>zwraca indeks listy wszystkieDaty</returns>
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
                    return MinIndex;
                }
            }
            return MinIndex;
        }
        /// <summary>
        /// Znajduję indeks równy lub wczęśniejszy dla danej daty
        /// </summary>
        /// <param name="givenDate">Data dla, której szuka indeksu</param>
        /// <returns>zwraca indeks listy wszystkieDaty</returns>
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
                    return MaxIndex;
                }
            }
            return MaxIndex;
        }
    }
}