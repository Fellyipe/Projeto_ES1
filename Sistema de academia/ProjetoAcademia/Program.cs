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

             while(true){
                //Console.Clear(); 
                Console.Write("[0] Fechar\n"+
                              "[1] Matricular Aluno\n"+
                              "[2] Atualizar Matricula\n"+
                              "[3] Deletar Matricula\n"+
                              "[4] Mostrar Matriculas");
                string ?op = Console.ReadLine();
                switch (op){
                    case "0":
                        Console.WriteLine("Programa Encerrado!");
                        Environment.Exit(0);
                        break;
                    case "1":
                    break;
                    case "2":
                    break;
                    case "3":
                    break;
                    case "4":
                    break;
                } 
            }
        }
    }
}
