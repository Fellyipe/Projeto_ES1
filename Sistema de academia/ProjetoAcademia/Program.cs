using System;
using System.Data.SQLite;

namespace ProjetoAcademia
{
    class Program
    {
        static void Main(string[] args)
        {
            var repository = RepositoryFactory.CreateRepository();

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
