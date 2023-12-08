using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using LiveCharts.Helpers;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;


namespace AplikacjaProjektIO
{
    public partial class MainForm : Form
    {
        List<CustomButton> listaPrzyciskow;
        List<CustomButton> przyciskiNastepnyIPoprzedni;
        DaneSpolek danespolek;
        ListaArtykulow listaArtykulow;
        string[] Xaxis;
        Artykul aktualnyArtykul;
        public MainForm()
        {
            InitializeComponent();
            cartesianChart.DisableAnimations = true;
            listaPrzyciskow = new List<CustomButton>();
            przyciskiNastepnyIPoprzedni = new List<CustomButton>();
            danespolek = new DaneSpolek();
            listaArtykulow = new ListaArtykulow();
            label2.Text = "";
            linkLabel1.Text = "";
            WygenerujPrzyciski();
            WygenerujPrzyciskiDlaArtykulow();
            cartesianChart.AxisY.Add(new Axis
            {
                Title = "Wartość akcji"
            });
            double[] notowania = new double[danespolek.ListaSpolek[0].Notowania.Values.Count];
            int i = 0;
            foreach (KeyValuePair<DateTime, double> pair in danespolek.ListaSpolek[0].Notowania)
            {
                notowania[i] = Math.Round(pair.Value, 2);
                i++;
            }
            cartesianChart.Series = new SeriesCollection()
            {
                new LineSeries
                {
                    Title = danespolek.ListaSpolek[0].Nazwa,
                    Values = notowania.AsChartValues(),
                }
            };
            Xaxis = new string[danespolek.ListaSpolek[0].Notowania.Count];
            i = 0;
            foreach (KeyValuePair<DateTime, double> pair in danespolek.ListaSpolek[0].Notowania)
            {
                Xaxis[i] = pair.Key.ToString("dd.MM.yyyy HH.mm");
                i++;
            }
            cartesianChart.AxisX.Clear();
            cartesianChart.AxisX.Add(new Axis
            {
                Title = "Data",
                Labels = Xaxis
            });
        }
        private void WygenerujPrzyciskiDlaArtykulow()
        {
            PrzyciskiDlaArtykulow button = new PrzyciskiDlaArtykulow();
            button.Text = "Poprzedni";
            button.Click += button2_Click;
            przewidywaniaPanel.Controls.Add(button);
            przyciskiNastepnyIPoprzedni.Add(button);
            button = new PrzyciskiDlaArtykulow();
            button.Text = "Nastepny";
            button.Click += button2_Click;
            przewidywaniaPanel.Controls.Add(button);
            przyciskiNastepnyIPoprzedni.Add(button);
        }
        private void WygenerujPrzyciski()
        {
            for(int i = danespolek.ListaSpolek.Count - 1; i >= 0; i--)
            {
                CustomButton button = new CustomButton();
                button.Text = danespolek.ListaSpolek[i].Nazwa;
                button.Dock = DockStyle.Top;
                button.Height = scrollablePanel.Height / danespolek.ListaSpolek.Count;
                button.Click += WygenerujWykres;
                scrollablePanel.Controls.Add(button);
                listaPrzyciskow.Add(button);
            }
        }
        private void scrollablePanelResize(object sender, EventArgs e)
        {
            foreach(CustomButton button in listaPrzyciskow)
            {
                button.Height = scrollablePanel.Height / danespolek.ListaSpolek.Count;
            }
        }
        private void WygenerujWykres(object sender, EventArgs e)
        {
            if(sender is Button)
            {
                Button button = (Button)sender;
                Spolka spolka = danespolek.ZnajdzSpolkePoNazwie(button.Text);
                double[] notowania = new double[spolka.Notowania.Values.Count];
                int i = 0;
                foreach(KeyValuePair<DateTime, double> pair in spolka.Notowania)
                {
                    notowania[i] = Math.Round(pair.Value,2);
                    i++;
                }
                cartesianChart.Series = new SeriesCollection()
                {
                    new LineSeries
                    {
                        Title = button.Text,
                        Values = notowania.AsChartValues()
                    }
                };
                Xaxis = new string[spolka.Notowania.Count];
                i = 0;
                foreach (KeyValuePair<DateTime, double> pair in spolka.Notowania)
                {
                    Xaxis[i] = pair.Key.ToString("dd.MM.yyyy HH.mm");
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
        private void cartesianChart_DataClick(object sender, ChartPoint chartPoint)
        {
            //Data naciśniętego punktu
            DateTime data = DateTime.ParseExact(Xaxis[(int)chartPoint.X], "dd.MM.yyyy HH.mm",CultureInfo.InvariantCulture);

            //Artykuł najbliższy do tej daty
            aktualnyArtykul = listaArtykulow.WyszukajArtykul(data);
            WyswietlDaneDlaArtykulu(aktualnyArtykul);
            foreach(PrzyciskiDlaArtykulow button in przyciskiNastepnyIPoprzedni)
            {
                button.Visible = true;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Po naciśnieciu na link otwiera strone
            System.Diagnostics.Process.Start(linkLabel1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //znajduje index artykułu i ustawia nowy
            int index = listaArtykulow.listaArtykulow.IndexOf(aktualnyArtykul);
            if (index != 0)
            {
                aktualnyArtykul = listaArtykulow.listaArtykulow[index - 1];
            }
            WyswietlDaneDlaArtykulu(aktualnyArtykul);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //znajduje index artykułu i ustawia nowy
            int index = listaArtykulow.listaArtykulow.IndexOf(aktualnyArtykul);
            if (index != listaArtykulow.listaArtykulow.Count - 1)
            {
                aktualnyArtykul = listaArtykulow.listaArtykulow[index + 1];
            }
            WyswietlDaneDlaArtykulu(aktualnyArtykul);
        }
        private void WyswietlDaneDlaArtykulu(Artykul artykul)
        {
            //Wyświetlenie tekstu artykułu
            label1.Text = aktualnyArtykul.Naglowek;
            label2.Text = aktualnyArtykul.Tresc;
            linkLabel1.Text = aktualnyArtykul.Link;

            //lista wyników llm
            ListaWynikow lista = new ListaWynikow(aktualnyArtykul, danespolek.ListaSpolek);
            StringBuilder ticker = new StringBuilder();
            StringBuilder gpt = new StringBuilder();
            StringBuilder bard = new StringBuilder();
            label6.Text = "Prawdopodobieństwo zmiany kursu na podstawie artykulu według LLM";
            ticker.Append("Ticker:\n");
            gpt.Append("ChatGPT:\n");
            bard.Append("Bard:\n");
            foreach (WynikiLLM wynikiLLM in lista.Lista)
            {
                ticker.Append(wynikiLLM.Ticker);
                ticker.Append(":\n");
                gpt.Append(wynikiLLM.WynikGPT);
                gpt.Append("\n");
                bard.Append(wynikiLLM.WynikBARD);
                bard.Append("\n");
            }
            label3.Text = ticker.ToString();
            label4.Text = gpt.ToString();
            label5.Text = bard.ToString();
        }
    }
}
