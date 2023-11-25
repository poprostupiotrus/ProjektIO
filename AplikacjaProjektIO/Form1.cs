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
using LiveCharts.Helpers;


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
            cartesianChart.AxisY.Add(new Axis
            {
                Title = "Wartość akcji"
            });
            cartesianChart.Series = new SeriesCollection()
            {
                new LineSeries
                {
                    Title = danespolek.ListaSpolek[0].Nazwa,
                    Values = danespolek.ListaSpolek[0].Notowania.Values.AsChartValues(),
                }
            };
            string[] Xaxis = new string[danespolek.ListaSpolek[0].Notowania.Count];
            int i = 0;
            foreach (KeyValuePair<DateTime, double> pair in danespolek.ListaSpolek[0].Notowania)
            {
                Xaxis[i] = pair.Key.ToString();
                i++;
            }
            cartesianChart.AxisX.Clear();
            cartesianChart.AxisX.Add(new Axis
            {
                Title = "Data",
                Labels = Xaxis
            });

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
                cartesianChart.Series = new SeriesCollection()
                {
                    new LineSeries
                    {
                        Title = button.Text,
                        Values = spolka.Notowania.Values.AsChartValues()
                    }
                };
                string[] Xaxis = new string[spolka.Notowania.Count];
                int i = 0;
                foreach (KeyValuePair<DateTime, double> pair in spolka.Notowania)
                {
                    Xaxis[i] = pair.Key.ToString();
                    i++;
                }
                cartesianChart.AxisX.Clear();
                cartesianChart.AxisX.Add(new Axis
                {
                    Title = "Data",
                    Labels = Xaxis
                });
            }
        }
    }
}
