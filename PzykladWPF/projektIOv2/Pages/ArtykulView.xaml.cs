﻿using Newtonsoft.Json;
using OpenAI.Threads;
using projektIOv2.Controls;
using projektIOv2.Skraper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Policy;
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

namespace projektIOv2.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy ArtykulView.xaml
    /// </summary>
    public partial class ArtykulView : Page
    {
        public ArtykulView()
        {
            InitializeComponent();

            (bardmenu.Items[0] as System.Windows.Controls.MenuItem).Click += Bard_Click;

        }
        public List<Artykul> lista;
        public Artykul pom;
        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            var a1 = (DataContext as Artykul);
            String outt = a1.Naglowek + "\n" + a1.Data + "\n" + a1.Tresc;
            Clipboard.SetText(outt);
        }
        private void Bard_Click(object sender, RoutedEventArgs e)
        {
            
            var a1 = (DataContext as Artykul).bard;
            String outt = "";
            foreach (var item in a1)
            {
                outt += item.Key + " " + item.Value + "\n";
            }
            Clipboard.SetText(outt);
        }
        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            
            var ob = DataContext as Artykul;
            try
            {
                if (ob.Tresc == null)
                {
                    Tresc t = new Tresc(ob.Link);
                    DataContext = await t.get();
                     
                }

                if ((ob.gpt == null || ob.gpt.Count() == 0) && ob.Tresc != null)
                {
                    // ob = DataContext as Artykul;
                    String txt = "Indeks WIG20 jest indeksem cenowym największych spółek giełdowych w Polsce. Wartość indeksu obliczana jest na podstawie obrotów i cen akcji 20 spółek giełdowych.podaj przewidywania jak podana informacja wpłynie na nastepujace spólki wig20:\r\n 'ACP (ASSECOPOL),ALE (ALLEGRO),ALR (ALIOR),CDR (CDPROJEKT),CPS (CYFRPLSAT),DNP (DINOPL),JSW,KGH (KGHM),KRU (KRUK),KTY (KETY),LPP,MBK (MBANK),OPL (ORANGEPL),PCO (PEPCO), PEO (PEKAO),PGE,PKN (PKNORLEN),PKO (PKOBP),PZU,SPL (SANPL)' \r\n Odpowiedź nie musi być prawdziwa, chodzi mi tylko jak według ciebie wpłynie artykuł na spółki wig20,  odpowiedź ma być w postaci listy, której elementami są: '<Nazwa spółki> <Przewidywanie>' i nic, poza tym(przewidywanie liczba z przedzialu <-10;10> gdzie -10 to wysokie prawdopodobienstwo spatku notowania danej spółki, \r\n 10-wysokie prawdopodobieństwo ze artykuł wplynie pozytywnie na notowania spolki,Nazwa spółki- trzyliterowy TICKERN spolki). Wszelki dodatkowy tekst zakazany, podam przykład odpowiedzi:\r\n'JSW -1\r\nALE +4\r\n...'\r\nTreść artykułu na podstawie którego masz wypisać wyniki:\r\n               ";
                    String query = txt + ob.Naglowek + ob.Tresc;

                    GptHandler gptHandler = new GptHandler();
                    DataContext = await gptHandler.ZapytajGpt(ob, query);
                    Cache cache = new Cache();
                }
            }
            catch (Exception)
            {

                
            }

            
        }

        private void gpt_Click(object sender, RoutedEventArgs e)
        {
            var a1 = (DataContext as Artykul).gpt;
            String outt = "";
            foreach (var item in a1)
            {
                outt += item.Key + " " + item.Value + "\n";
            }
            Clipboard.SetText(outt);
        }

        private async void reloadgpt_Click(object sender, RoutedEventArgs e)
        {
            var ob = DataContext as Artykul;
            try
            {
                String txt = "Indeks WIG20 jest indeksem cenowym największych spółek giełdowych w Polsce. Wartość indeksu obliczana jest na podstawie obrotów i cen akcji 20 spółek giełdowych.podaj przewidywania jak podana informacja wpłynie na nastepujace spólki wig20:\r\n 'ACP (ASSECOPOL),ALE (ALLEGRO),ALR (ALIOR),CDR (CDPROJEKT),CPS (CYFRPLSAT),DNP (DINOPL),JSW,KGH (KGHM),KRU (KRUK),KTY (KETY),LPP,MBK (MBANK),OPL (ORANGEPL),PCO (PEPCO), PEO (PEKAO),PGE,PKN (PKNORLEN),PKO (PKOBP),PZU,SPL (SANPL)' \r\n Odpowiedź nie musi być prawdziwa, chodzi mi tylko jak według ciebie wpłynie artykuł na spółki wig20,  odpowiedź ma być w postaci listy, której elementami są: '<Nazwa spółki> <Przewidywanie>' i nic, poza tym(przewidywanie liczba z przedzialu <-10;10> gdzie -10 to wysokie prawdopodobienstwo spatku notowania danej spółki, \r\n 10-wysokie prawdopodobieństwo ze artykuł wplynie pozytywnie na notowania spolki,Nazwa spółki- trzyliterowy TICKERN spolki). Wszelki dodatkowy tekst zakazany, podam przykład odpowiedzi:\r\n'JSW -1\r\nALE +4\r\n...'\r\nTreść artykułu na podstawie którego masz wypisać wyniki:\r\n               ";
                String query = txt + ob.Naglowek + ob.Tresc;

                GptHandler gptHandler = new GptHandler();
                DataContext = await gptHandler.ZapytajGpt(ob, query);
            }
            catch (Exception)
            {

            }
        }

        private void nastepnyArtykul_Click(object sender, RoutedEventArgs e)
        {
            if(lista==null)
            {
            string filePath = "artykulyV2.json";
            string jsonString = File.ReadAllText(filePath);
            lista = JsonConvert.DeserializeObject<List<Artykul>>(jsonString);
            }
              
            Artykul art = lista.Find(x => x.Link == ((Artykul)DataContext).Link);
            int index = lista.IndexOf(art);
            if (index != lista.Count - 1)
            {
                DataContext = lista[index + 1];
            }
        }

        private void poprzedniArtykul_Click(object sender, RoutedEventArgs e)
        {
            if (lista == null)
            {
                string filePath = "artykulyV2.json";
                string jsonString = File.ReadAllText(filePath);
                lista = JsonConvert.DeserializeObject<List<Artykul>>(jsonString);
            }

            Artykul art = lista.Find(x => x.Link == ((Artykul)DataContext).Link);
            int index = lista.IndexOf(art);
            if (index != 0)
            {
                DataContext = lista[index - 1];
            }
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            
            
            try
            {
                Process.Start(new ProcessStartInfo(((Artykul)DataContext).Link) { UseShellExecute = true });
            }
            catch (Exception)
            {

                
            }
        }
    }
}
