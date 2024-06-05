using System;

namespace ProjetoAcademia
{
    class Program
    {
        private static Program _instance; // Singleton instance
        private MatriculaService _matriculaService; // Matricula service
        private PersonalService _personalService; // Personal service

        private Program(MatriculaService matriculaService, PersonalService personalService)
        {
            _matriculaService = matriculaService;
            _personalService = personalService;
        }

        public static Program Instance
        {
            get
            {
                if (_instance == null)
                {
                    // Create instance with services (assuming they are available)
                    _instance = new Program(new MatriculaService(), new PersonalService());
                }

                return _instance;
            }
        }

        static void Main(string[] args)
        {
            // Get the singleton instance
            var program = Program.Instance;

            // Start the application using the singleton instance
            program.MenuPrincipal();
        }

        private void MenuPrincipal()
        {
            while (true)
            {
                Console.WriteLine("[0] Fechar");
                Console.WriteLine("[1] Gerenciar Matrículas");
                Console.WriteLine("[2] Gerenciar Personal");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "0":
                        Console.WriteLine("Programa Encerrado!");
                        Environment.Exit(0);
                        break;
                    case "1":
                        GerenciarMatriculas();
                        break;
                    case "2":
                        GerenciarPersonal();
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }

        private void GerenciarMatriculas()
        {
            while (true)
            {
                Console.WriteLine("[0] Voltar");
                Console.WriteLine("[1] Matricular Aluno");
                Console.WriteLine("[2] Atualizar Matrícula");
                Console.WriteLine("[3] Cancelar Matrícula");
                Console.WriteLine("[4] Listar Matrículas");
                Console.WriteLine("[5] Buscar Matrícula");
                string opcaoMatricula = Console.ReadLine();

                switch (opcaoMatricula)
                {
                    case "0":
                        return;
                    case "1":
                        // Implement MatricularAluno logic
                        Console.WriteLine("Implementar MatricularAluno");
                        break;
                    case "2":
                        // Implement AtualizarMatricula logic
                        Console.WriteLine("Implementar AtualizarMatricula");
                        break;
                    case "3":
                        // Implement CancelarMatricula logic
                        Console.WriteLine("Implementar CancelarMatricula");
                        break;
                    case "4":
                        // Implement ListarMatriculas logic
                        Console.WriteLine("Implementar ListarMatriculas");
                        break;
                    case "5":
                        // Implement BuscarMatricula logic
                        Console.WriteLine("Implementar BuscarMatricula");
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }

       private void GerenciarPersonal()
{
    while (true)
    {
        Console.WriteLine("[0] Voltar");
        Console.WriteLine("[1] Cadastrar Personal");
        Console.WriteLine("[2] Atualizar Personal");
        Console.WriteLine("[3] Deletar Personal");
        Console.WriteLine("[4] Listar Personal");
        Console.WriteLine("[5] Buscar Personal");
        string opcaoPersonal = Console.ReadLine();

        switch (opcaoPersonal)
        {
            case "0":
                return;
            case "1":
                CadastrarPersonal();
                break;
            case "2":
                AtualizarPersonal();
                break;
            case "3":
                DeletarPersonal();
                break;
            case "4":
                ListarPersonal();
                break;
            case "5":
                BuscarPersonal();
                break;
            default:
                Console.WriteLine("Opção inválida. Tente novamente.");
                break;
        }
    }
}
    }
}