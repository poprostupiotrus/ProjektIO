using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using LiveCharts.Helpers;


namespace AplikacjaProjektIO
{
    public partial class MainForm : Form
    {
        DaneSpolek danespolek;
        ListaArtykulow listaArtykulow;
        string[] Xaxis;
        Artykul aktualnyArtykul;
        public MainForm()
        {
            InitializeComponent();
            cartesianChart.DisableAnimations = true;
            danespolek = new DaneSpolek();
            listaArtykulow = new ListaArtykulow();
            label2.Text = "";
            linkLabel1.Text = "";
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
            Xaxis = new string[danespolek.ListaSpolek[0].Notowania.Count];
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
            button1.Visible = false;
            button2.Visible = false;
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
                Xaxis = new string[spolka.Notowania.Count];
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
        private void cartesianChart_DataClick(object sender, ChartPoint chartPoint)
        {
            //Data naciśniętego punktu
            DateTime data = DateTime.Parse(Xaxis[(int)chartPoint.X]);

            //Artykuł najbliższy do tej daty
            aktualnyArtykul = listaArtykulow.WyszukajArtykul(data);

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
            foreach(WynikiLLM wynikiLLM in lista.Lista)
            {
                ticker.Append(wynikiLLM.Ticker);
                ticker.Append(":\n");
                gpt.Append(wynikiLLM.WynikGPT);
                gpt.Append("\n");
                bard.Append(wynikiLLM.WynikBARD);
                bard.Append("\n");
            }
            label3.Text=ticker.ToString();
            label4.Text=gpt.ToString();
            label5.Text=bard.ToString();

            button1.Visible = true;
            button2.Visible = true;
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
            //Tak jak w dataclick event wyświetla nowy artykół
            label1.Text = aktualnyArtykul.Naglowek;
            label2.Text = aktualnyArtykul.Tresc;
            linkLabel1.Text = aktualnyArtykul.Link;
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

        private void button2_Click(object sender, EventArgs e)
        {
            //znajduje index artykułu i ustawia nowy
            int index = listaArtykulow.listaArtykulow.IndexOf(aktualnyArtykul);
            if (index != listaArtykulow.listaArtykulow.Count - 1)
            {
                aktualnyArtykul = listaArtykulow.listaArtykulow[index + 1];
            }
            //Tak jak w dataclick event wyświetla nowy artykół
            label1.Text = aktualnyArtykul.Naglowek;
            label2.Text = aktualnyArtykul.Tresc;
            linkLabel1.Text = aktualnyArtykul.Link;
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
