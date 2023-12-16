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
        List<Spolka> listawykresow;
        public MainForm()
        {
            InitializeComponent();
            cartesianChart.DisableAnimations = true;

            listaPrzyciskow = new List<CustomButton>();
            przyciskiNastepnyIPoprzedni = new List<CustomButton>();
            danespolek = new DaneSpolek();
            listaArtykulow = new ListaArtykulow();
            listawykresow = new List<Spolka>();
            WszystkieDaty = new List<string>();
            WygenerujPrzyciski();
            WygenerujPrzyciskiDlaArtykulow();

            label2.Text = "";
            linkLabel1.Text = "";
            label6.Text = "Prawdopodobieństwo zmiany kursu na podstawie artykulu według LLM";
            

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
            if(!(sender is Button))
            {
                return;
            } 
            Button button = (Button)sender;
            Spolka spolkaButton = danespolek.ZnajdzSpolkePoNazwie(button.Text);
            DateTime pierwszaData = DateTime.ParseExact(WszystkieDaty[0], "dd.MM.yyyy HH.mm", CultureInfo.InvariantCulture);
            //Czy Shift był wciśniety przy kliknięciu
            if (ModifierKeys.HasFlag(Keys.Shift))
            {
                //Dodanie lub usunięcie spółki z listy spółek
                if (listawykresow.Contains(spolkaButton))
                {
                    //Jeśli jest tylko jeden wykres nic nie usuwaj
                    if (listawykresow.Count == 1)
                    {
                        return;
                    }
                    listawykresow.Remove(spolkaButton);
                    button.BackColor = Color.LightGray;
                }
                else
                {
                    listawykresow.Add(spolkaButton);
                    button.BackColor = Color.Aqua;
                }
            }
            else
            {
                listawykresow.Clear();
                listawykresow.Add(spolkaButton);
                foreach (Button button1 in listaPrzyciskow)
                {
                    button1.BackColor = Color.LightGray;
                }
                button.BackColor = Color.Aqua;
            }
            cartesianChart.Series.Clear();
            //Dodanie wykresu każdej spółki
            foreach (Spolka spolka in listawykresow)
            {
                List<ObservablePoint> listapunktow = new List<ObservablePoint>();
                double dzielnik;
                if (listawykresow.Count < 2)
                {
                    dzielnik = 1;
                }
                else
                {
                    dzielnik = 0.01 * spolka.Notowania[pierwszaData];
                }

                //Dla każdej daty sprawdź czy dla niej jest notowanie
                for (int i = 0; i < WszystkieDaty.Count; i++)
                {   
                    DateTime data = DateTime.ParseExact(WszystkieDaty[i], "dd.MM.yyyy HH.mm", CultureInfo.InvariantCulture);
                    if (spolka.Notowania.ContainsKey(data) && spolka.Notowania[data] != 0)
                    {
                        listapunktow.Add(new ObservablePoint(i, Math.Round(spolka.Notowania[data]/dzielnik, 2)));
                    }
                }

                //Dodanie wykresu
                cartesianChart.Series.Add(new LineSeries
                {
                    Title = spolka.Ticker,
                    Values = listapunktow.AsChartValues()
                });
            }

            //Ustawienie nazwy osi Y
            cartesianChart.AxisY.Clear();
            if (listawykresow.Count < 2)
            {
                cartesianChart.AxisY.Add(new Axis
                {
                    Title = "Wartość akcji [zł]"
                });
            }
            else
            {
                cartesianChart.AxisY.Add(new Axis
                {
                    Title = "Zmiana kursu akcji względem pierwszej dostępnej daty [%]"
                });
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
