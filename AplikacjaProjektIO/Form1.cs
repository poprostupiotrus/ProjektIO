using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using LiveCharts.Helpers;
using System.Globalization;
using System.Drawing;
using LiveCharts.Defaults;
using System.Linq;


namespace AplikacjaProjektIO
{
    public partial class MainForm : Form
    {
        List<CustomButton> listaPrzyciskow;
        List<CustomButton> przyciskiNastepnyIPoprzedni;
        DaneSpolek danespolek;
        ListaArtykulow listaArtykulow;
        List<string> WszystkieDaty;
        Artykul aktualnyArtykul;
        Dictionary<Spolka,LineSeries> listawykresow;
        public MainForm()
        {
            InitializeComponent();
            cartesianChart.DisableAnimations = true;

            listaPrzyciskow = new List<CustomButton>();
            przyciskiNastepnyIPoprzedni = new List<CustomButton>();
            danespolek = new DaneSpolek();
            listaArtykulow = new ListaArtykulow();
            listawykresow = new Dictionary<Spolka, LineSeries>();
            WszystkieDaty = new List<string>();
            WygenerujPrzyciski();
            WygenerujPrzyciskiDlaArtykulow();

            label2.Text = "";
            linkLabel1.Text = "";
            label6.Text = "Prawdopodobieństwo zmiany kursu na podstawie artykulu według LLM";
            cartesianChart.AxisY.Add(new Axis
            {
                Title = "Wartość akcji"
            });

            //Przygotowanie osi X
            foreach(Spolka spolka in danespolek.ListaSpolek)
            {
                foreach(KeyValuePair<DateTime,double> pair in spolka.Notowania)
                {
                    WszystkieDaty.Add(pair.Key.ToString("dd.MM.yyyy HH.mm"));
                }
            }
            WszystkieDaty = WszystkieDaty.Distinct().ToList();
            WszystkieDaty.Sort();
            cartesianChart.AxisX.Add(new Axis
            {
                Title = "Data",
                Labels = WszystkieDaty
            });

            //Wygeneruj domyślny wykres
            WygenerujWykres(listaPrzyciskow[listaPrzyciskow.Count-1],new EventArgs());
        }
        private void WygenerujPrzyciskiDlaArtykulow()
        {
            PrzyciskiDlaArtykulow button = new PrzyciskiDlaArtykulow();
            button.Text = "Poprzedni";
            button.Click += poprzedni_Click;
            przewidywaniaPanel.Controls.Add(button);
            przyciskiNastepnyIPoprzedni.Add(button);
            button = new PrzyciskiDlaArtykulow();
            button.Text = "Nastepny";
            button.Click += nastepny_Click;
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
            WypelnijLuke();
        }
        private void scrollablePanelResize(object sender, EventArgs e)
        {
            foreach(CustomButton button in listaPrzyciskow)
            {
                button.Height = scrollablePanel.Height / danespolek.ListaSpolek.Count;
            }
            WypelnijLuke();
        }
        private void WypelnijLuke()
        {
            for(int i = 0; i < scrollablePanel.Height%danespolek.ListaSpolek.Count; i++)
            {
                listaPrzyciskow[i].Height++;
            }
        }
        private void WygenerujWykres(object sender, EventArgs e)
        {
            if(sender is Button)
            {
                Button button = (Button)sender;
                Spolka spolka = danespolek.ZnajdzSpolkePoNazwie(button.Text);
                if (listawykresow.ContainsKey(spolka) && listawykresow[spolka]!=null)
                {
                    cartesianChart.Series.Remove(listawykresow[spolka]);
                    listawykresow[spolka] = null;
                    button.BackColor = Color.LightGray;
                }
                else
                {
                    List<ObservablePoint> listapunktow=new List<ObservablePoint>();
                    for(int i = 0;i<WszystkieDaty.Count;i++)
                    {
                        DateTime data = DateTime.ParseExact(WszystkieDaty[i], "dd.MM.yyyy HH.mm", CultureInfo.InvariantCulture);
                        if (spolka.Notowania.ContainsKey(data) &&spolka.Notowania[data]!=0)
                        {
                            listapunktow.Add(new ObservablePoint(i, Math.Round(spolka.Notowania[data],2)));
                        }
                    }
                    listawykresow[spolka] = new LineSeries{
                        Title = button.Text,
                        Values = listapunktow.AsChartValues()
                    };
                    cartesianChart.Series.Add(listawykresow[spolka]);              
                    button.BackColor = Color.Aqua;
                }
            }
        }
        private void cartesianChart_DataClick(object sender, ChartPoint chartPoint)
        {
            //Data naciśniętego punktu
            DateTime data = DateTime.ParseExact(WszystkieDaty[(int)chartPoint.X], "dd.MM.yyyy HH.mm",CultureInfo.InvariantCulture);

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

        private void poprzedni_Click(object sender, EventArgs e)
        {
            //znajduje index artykułu i ustawia nowy
            int index = listaArtykulow.listaArtykulow.IndexOf(aktualnyArtykul);
            if (index != 0)
            {
                aktualnyArtykul = listaArtykulow.listaArtykulow[index - 1];
            }
            WyswietlDaneDlaArtykulu(aktualnyArtykul);
        }

        private void nastepny_Click(object sender, EventArgs e)
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
