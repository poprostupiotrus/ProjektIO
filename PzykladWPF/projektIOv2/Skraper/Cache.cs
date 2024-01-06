using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace projektIOv2.Skraper
{
    public class Cache
    {

        public Cache()
        {

            // Sprawdź, czy folder cache istnieje, jeśli nie, utwórz go.
            if (!Directory.Exists("cache"))
            {
                Directory.CreateDirectory("cache");
            }
        }

        public bool HasDate(DateTime expectedDate)
        {
            String file = expectedDate.ToString("yyyy.MM.dd");
            try
            {
                string filePath = Path.Combine("cache", file);
                return File.Exists(filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Wystąpił błąd podczas sprawdzania istnienia pliku: {ex.Message}");
                return false;
            }
        }

        public List<Artykul> GetListFromDate(DateTime expectedDate) {
            string file = expectedDate.ToString("yyyy.MM.dd");
            string filePath = Path.Combine("cache", file);
            string jsonString = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<Artykul>>(jsonString);

        }

        public void SaveList(List<Artykul> listToSave) {
            string file = listToSave.First(x => x.Data != null).Data.ToString("yyyy.MM.dd");
            string filePath = Path.Combine("cache", file);
            try
            {
                // Serializacja listy obiektów do formatu JSON
                string json = JsonConvert.SerializeObject(listToSave, Formatting.Indented);

                // Zapisanie JSON do pliku
                File.WriteAllText(filePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Wystąpił błąd podczas zapisywania do pliku JSON: {ex.Message}");
            }
        }

        public void UpdateArtykul(Artykul artykul)
        {
            string file = artykul.Data.ToString("yyyy.MM.dd");
            string filePath = Path.Combine("cache", file);
            if (!File.Exists(filePath)) return;
            string jsonString = File.ReadAllText(filePath);
            List<Artykul> listaartykulow= JsonConvert.DeserializeObject<List<Artykul>>(jsonString);
            listaartykulow.RemoveAll(x => x.Link==artykul.Link);
            listaartykulow.Add(artykul);
            try
            {
                // Serializacja listy obiektów do formatu JSON
                string json = JsonConvert.SerializeObject(listaartykulow, Formatting.Indented);

                // Zapisanie JSON do pliku
                File.WriteAllText(filePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Wystąpił błąd podczas zapisywania do pliku JSON: {ex.Message}");
            }
        }
    }
}