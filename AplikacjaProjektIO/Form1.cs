using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplikacjaProjektIO
{
    public partial class MainForm : Form
    {
        DaneSpolek danespolek;
        public MainForm()
        {
            InitializeComponent();
            danespolek = new DaneSpolek();
            WygenerujPrzyciski();
            
        }
        private void WygenerujPrzyciski()
        {
            foreach(Spolka element in danespolek.ListaSpolek)
            {
                Button button = new Button();
                button.Text = element.Nazwa;
                button.Dock = DockStyle.Top;
                button.Height = 70;
                button.Click += WygenerujWykres;
                scrollablePanel.Controls.Add(button);
            }
        }
        private void WygenerujWykres(object sender, EventArgs e)
        {
            if(sender is Button)
            {
                Button button = (Button)sender;
                Spolka spolka = danespolek.ZnajdzSpolkePoNazwie(button.Text);
                List<ObservablePoint> listaPunktow = new List<ObservablePoint>();
                foreach(KeyValuePair<DateTime, double> keyvalue in spolka.Notowania)
                {
                    listaPunktow.Add(new ObservablePoint(keyvalue.Key.ToOADate(), keyvalue.Value));
                }
                cartesianChart1.Series = new SeriesCollection()
                {
                    new LineSeries
                    {
                        Stroke = System.Windows.Media.Brushes.Orange,
                        StrokeThickness = 2,
                        Title = button.Text,
                        Values = new ChartValues<ObservablePoint>(listaPunktow),
                        LineSmoothness = 0
                    }
                };
            }
        }
    }
}
