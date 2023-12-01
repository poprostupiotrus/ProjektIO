using System;
using MySql.Data.MySqlClient;

class Program
{
    static void Main()
    {
        
        
        string connectionString = "Server=localhost;Database=wiadomosci;User ID=test4;Password=123;";

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                Link link = new Link();
                for (int i = 1; i <= 90; i++)
                {
                    link.addApage(i);
                }
                
                foreach (var item in link.getLista)
                {
                    var art = new Tresc(item);
                    string insertQuery = "INSERT INTO t1 (link,h1,p,czas) VALUES (@link,@h1,@p,@czas)";

                    using (MySqlCommand cmd = new MySqlCommand(insertQuery, connection))
                    {
                        Console.WriteLine(art.Czas);
                        cmd.Parameters.AddWithValue("@link", item);
                        cmd.Parameters.AddWithValue("@h1", art.Tytul);
                        cmd.Parameters.AddWithValue("@p", art.Trescc);
                        cmd.Parameters.AddWithValue("@czas", art.Czas);
                        Console.WriteLine(item);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        Console.WriteLine($"Dodano {rowsAffected} rekordów.");
                    }
                }
                
                Console.WriteLine("Połączono z bazą danych.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd połączenia z bazą danych: {ex.Message}");
            }
        }
    }
}
