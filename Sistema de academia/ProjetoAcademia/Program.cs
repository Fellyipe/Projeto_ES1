using System;
using System.Data.SQLite;

namespace ProjetoAcademia
{
    class Program
    {
        static void Main(string[] args)
        {
            // Especifica a localização do banco de dados
            string connectionString = "Data Source=academia.db;Version=3;";

            // Cria uma nova conexão com o banco de dados
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                Console.WriteLine("Conexão com o banco de dados SQLite estabelecida com sucesso!");

                connection.Close();
            }
        }
    }
}
