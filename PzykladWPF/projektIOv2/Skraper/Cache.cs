using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace projektIOv2.Skraper
{
    /// <summary>
    /// Klasa odpowiedzialna za cachowanie artykułów.
    /// </summary>
    public class Cache
    {
        /// <summary>
        /// Inicjalizuje nową instancję klasy Cache.
        /// </summary>
        public Cache()
        {

            // Sprawdź, czy folder cache istnieje, jeśli nie, utwórz go.
            if (!Directory.Exists("cache"))
            {
                Directory.CreateDirectory("cache");
            }
        }

        /// <summary>
        /// Sprawdza, czy istnieje plik w cache o określonej dacie.
        /// </summary>
        /// <param name="expectedDate">Oczekiwana data pliku w formacie yyyy.MM.dd.</param>
        /// <returns>True, jeśli plik istnieje; w przeciwnym razie false.</returns>
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
                //throw new Exception("BRAK UPRAWNIEN DO ODCZYTU CACHE");
                return false;
            }
        }

        /// <summary>
        /// Pobiera listę artykułów z pliku cache o określonej dacie.
        /// </summary>
        /// <param name="expectedDate">Oczekiwana data pliku w formacie yyyy.MM.dd.</param>
        /// <returns>Lista artykułów z pliku cache.</returns>
        public List<Artykul> GetListFromDate(DateTime expectedDate) {
            if (!HasDate(expectedDate)) return new List<Artykul>();
            string file = expectedDate.ToString("yyyy.MM.dd");
            string filePath = Path.Combine("cache", file);
            string jsonString = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<Artykul>>(jsonString);

        }

        /// <summary>
        /// Zapisuje listę artykułów do pliku cache.
        /// </summary>
        /// <param name="listToSave">Lista artykułów do zapisania.</param>
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
                //throw new Exception("BRAK UPRAWNIEN DO PLIKU CACHE");
                Console.WriteLine($"Wystąpił błąd podczas zapisywania do pliku JSON: {ex.Message}");
            }
        }

        /// <summary>
        /// Aktualizuje informacje o artykule w pliku cache.
        /// </summary>
        /// <param name="artykul">Artykuł do zaktualizowania.</param>
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
                //throw new Exception("BRAK UPRAWNIEN DO PLIKU CACHE");
                Console.WriteLine($"Wystąpił błąd podczas zapisywania do pliku JSON: {ex.Message}");
            }
        }
    }
}